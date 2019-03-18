using System;
using System.Collections.ObjectModel;
using Service;
using System.IO.Ports;
using Modbus.Device;
using System.Timers;
using System.Windows;

namespace Work {
  public class Work {
    private static Timer reading = new Timer(1000);
    private static ObservableCollection<Device> devices;
    private static ModbusSerialMaster master;

    public static void Reading(ObservableCollection<Device> devices) {
      Work.devices = devices;
      reading.Elapsed += Reading_Elapsed;
      reading.Start();
      //reading.AutoReset = false;
      SerialStart();
    }

    public static void StopReading() {
      reading.Stop();
    }

    public static void SerialStart() {
      SerialPort serialPort = new SerialPort();
      serialPort.PortName = "COM8";
      serialPort.BaudRate = 9600;
      serialPort.DataBits = 8;
      serialPort.Parity = Parity.None;
      serialPort.StopBits = StopBits.One;
      serialPort.Open();
      master = ModbusSerialMaster.CreateRtu(serialPort);
      master.Transport.Retries = 0;
      master.Transport.WaitToRetryMilliseconds = 300;
      
    }

    private static void Reading_Elapsed(object sender, ElapsedEventArgs e) {

      for (int i = 0; i < devices.Count; i++) {
        try {
          if (!(devices[i].QuantityAddressHolding == 0)) {
            ushort[] holding_reg = master.ReadHoldingRegisters(devices[i].ModbusID, devices[i].StartAddressHolding, devices[i].QuantityAddressHolding);
            Application.Current.Dispatcher.Invoke((Action)(() => {
              devices[i].ResultHolding = holding_reg;
            }));
          }
          if (!(devices[i].QuantityAddressInput == 0)) {
            ushort[] input_reg = master.ReadInputRegisters(devices[i].ModbusID, devices[i].StartAddressInput, devices[i].QuantityAddressInput);
            Application.Current.Dispatcher.Invoke((Action)(() => {
              devices[i].ResultInput = input_reg;
            }));
          }
          devices[i].ErrorMessage = "";
        } catch (Exception exception) {
          if (exception.Message == "Время ожидания операции истекло.") {
            devices[i].ErrorMessage = "Время ожидания запроса истекло";
          }
          string strExcp = exception.ToString();
          int res = strExcp.IndexOf("Modbus");
          if (res > -1) {
            int pos = strExcp.IndexOf("Exception Code:");
            switch (strExcp.Substring(108, 1)) {
              case "1":
                devices[i].ErrorMessage = "ILLEGAL FUNCTION";
                break;
              case "2":
                devices[i].ErrorMessage = "ILLEGAL DATA ADRESS";
                break;
              case "3":
                devices[i].ErrorMessage = "ILLEGAL DATA VALUE";
                break;
              case "4":
                devices[i].ErrorMessage = "SLAVE DEVICE FAILURE";
                break;
              case "5":
                devices[i].ErrorMessage = "ACKNOWLEDGE";
                break;
              case "6":
                devices[i].ErrorMessage = "SLAVE DEVICE BUSY";
                break;
              case "8":
                devices[i].ErrorMessage = "MEMORY PARITY ERROR";
                break;
              case "0A":
                devices[i].ErrorMessage = "GATEWAY PATH UNAVAILABLE";
                break;
              case "0B":
                devices[i].ErrorMessage = "GATEWAY TARGET DEVICE FAILED TO RESPOND";
                break;
            }
          }
        }
      }
    }
  }
}