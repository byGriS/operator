using System;
using System.Collections.ObjectModel;
using Service;
using System.IO.Ports;
using Modbus.Device;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace Work {
  public class Work {
    //private static Timer reading = new Timer(2000);
    private static ObservableCollection<Device> devices;
    private static ModbusSerialMaster master;
    private static SerialPort serialPort;
    private static bool errorPort = false, errorShow = true;
    private static bool readingAllow = true;
    private static TextBlock tbTitle, tbTime;

    public static void Reading(ObservableCollection<Device> devices, SerialPort serial, TextBlock tbTitle, TextBlock tbTime) {
      Work.devices = devices;
      Work.serialPort = serial;
      Work.tbTitle = tbTitle;
      Work.tbTime = tbTime;
      SerialStart();
      //reading.Elapsed += Reading_Elapsed;
      //reading.Start();
      //reading.AutoReset = false;
      StartReading();
    }

    public static void StopReading() {
      //reading.Stop();
      readingAllow = false;
    }

    public static void SerialStart() {
      try {
        serialPort.Open();
        errorPort = false;
        master = ModbusSerialMaster.CreateRtu(serialPort);
        master.Transport.Retries = 0;
        master.Transport.WaitToRetryMilliseconds = 1000;
        errorShow = true;
        //readingAllow = true;
        Application.Current.Dispatcher.Invoke((Action)(() => {
          tbTitle.Visibility = Visibility.Collapsed;
          tbTime.Visibility = Visibility.Visible;
        }));
      } catch (Exception e) {
        if (errorShow) {
          Application.Current.Dispatcher.Invoke((Action)(() => {
            tbTitle.Text = "Нет связи с ЩА1";
            tbTitle.Visibility = Visibility.Visible;
            tbTime.Visibility = Visibility.Collapsed;
            new ServiceWindows.MessageView(e.Message, "Ошибка", ServiceWindows.MessageViewMode.Error).Show();
          }));
          errorShow = false;
        }

        errorPort = true;
      }
    }

    private static void StartReading() {
      while (readingAllow) {
        if (errorPort) {
          System.Threading.Thread.Sleep(1000);
          SerialStart();
          continue;
        }
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
            System.Threading.Thread.Sleep(250);
          } catch (Exception exception) {
            if (exception.Message == "Порт закрыт.") {
              errorPort = true;

            }
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

    private static int tryWrite = 3;

    public static void WriteAllowPump(Device device, bool value) {
      try {
        if (tryWrite < 0) {
          tryWrite = 3;
          return;
        }
        tryWrite--;
        System.Threading.Thread.Sleep(250);
        ushort[] holding_reg = master.ReadHoldingRegisters(device.ModbusID, 50, 1);
        string bitMask = Convert.ToString(holding_reg[0], 2);
        int countSym = bitMask.Length;
        for (int i = 0; i < 8 - countSym; i++) {
          bitMask = "0" + bitMask;
        }
        char[] buf = bitMask.ToCharArray();
        buf[4] = value ? '1' : '0';
        string resultS = "";
        for(int i = 0; i < 8; i++) {
          resultS += buf[i].ToString();
        }

        ushort[] result = new ushort[] { Convert.ToUInt16(resultS,2) };
        master.WriteMultipleRegisters(device.ModbusID, 50, result);

        //master.WriteSingleCoil(device.ModbusID, 4, value);
      } catch (Exception e) {
        System.Threading.Thread.Sleep(250);
        WriteAllowPump(device, value);
      }
    }

    /*private static void Reading_Elapsed(object sender, ElapsedEventArgs e) {
      if (errorPort) {
        System.Threading.Thread.Sleep(1000);
        SerialStart();

        return;
      }
      /*for (int i = 0; i < devices.Count; i++) {
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
          System.Threading.Thread.Sleep(200);
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
    }*/
  }
}