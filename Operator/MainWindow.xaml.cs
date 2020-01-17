using Data;
using Service;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Operator {
  public partial class MainWindow : Window {
    private Timer time = new Timer(1000);
    private Timer readLogsTimer = new Timer(5000);
    private ObservableCollection<Device> devices = new ObservableCollection<Device>();
    private Tag AllowPump1 = new Tag { Value = 1 };
    private Tag AllowPump2 = new Tag { Value = 1 };

    private Tag TestBool = new Tag { Value = 0 };
    private Tag TestFloat = new Tag { Value = 0 };

    public bool IsDemo { get; set; } = true;

    public string AdminPass { get; set; } = "123";
    public SerialPort SerialPort { get; set; } = new SerialPort { PortName = "COM10", BaudRate = 9600, DataBits = 8, Parity = Parity.None, StopBits = StopBits.One };

    public MainWindow() {
      InitializeComponent();
      time.Elapsed += Time_Elapsed;
      readLogsTimer.Elapsed += ReadLogsTimer_Elapsed;
      this.DataContext = this;
      string[] data = (string[])WorkFile.Do("data.dat", WorkFileMode.ReadArrayString);
      AdminPass = data[0];
      SerialPort.PortName = data[1];
    }

    #region Параметры окна

    private bool isAdmin = true;
    public bool IsAdmin {
      get { return isAdmin; }
      set {
        isAdmin = value;
        if (isAdmin) {
          //tbUser.Text = "Администратор";
        }else {
          //tbUser.Text = "Оператор";
        }
      }
    }

    public ObservableCollection<EventLog> Logs { get; } = new ObservableCollection<EventLog>();
    public ObservableCollection<EventLog> Alarms { get; } = new ObservableCollection<EventLog>();

    #endregion

    #region Методы окна

    private void Window_Loaded(object sender, RoutedEventArgs e) {
      IsDemo = !License.CheckLicense();
      time.Start();
      readLogsTimer.Start();
      eventLogs.ItemsSource = Logs;
      eventLogsMini.ItemsSource = Alarms;
      DataBase.WriteLog(new EventLog { DateTime = DateTime.Now, EventLogType = EventLogType.Сообщение, Source = "ПО", Message = "Программа запустилась" });
      InitDevices();
      StartMain();
      StartPump();
      StartTank();
      StartGas();
      StartValve();


      AllowPump1.Value = AllowPump1.Value;
      AllowPump2.Value = AllowPump2.Value;
      if (!IsDemo) {
        System.Threading.Thread modbus = new System.Threading.Thread(ModbusRead);
        modbus.Start();
        tbDemo.Visibility = Visibility.Collapsed;
        tbTime.Visibility = Visibility.Visible;
      }else {
        tbTime.Visibility = Visibility.Collapsed;
      }
      AllowPump1.OnChangeValue += AllowPump1_OnChangeValue;
      AllowPump2.OnChangeValue += AllowPump2_OnChangeValue;



      //gasFiled.Channel1.Value = 1;
      //gasFiled.Channel5.Value = 2;
      //gasFiled.Channel7.Value = 3;
      //valves.Valve1_1.Value = 1;
      //valves.Valve1_2.Value = 0;
      //valves.Valve2_1.Value = 0;
      //valves.Valve2_2.Value = 1;
      //valves.Valve3_1.Value = 1;
      //valves.Valve3_2.Value = 1;
      //valves.Valve4_1.Value = 0;
      //valves.Valve4_2.Value = 0;
    } 

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
      DataBase.WriteLog(new Service.EventLog { DateTime = DateTime.Now, EventLogType = Service.EventLogType.Сообщение, Source = "ПО", Message = "Программа закрылась" });
      Work.Work.StopReading();
    }

    private void Time_Elapsed(object sender, ElapsedEventArgs e) {
      try {
        Application.Current.Dispatcher.Invoke((Action)(() => {
          tbTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }));
      }catch { }
    }
    
    private void ReadLogsTimer_Elapsed(object sender, ElapsedEventArgs e) {
      try {
        Application.Current.Dispatcher.Invoke((Action)(() => {
          DataBase.ReadNewLogs(Logs);
        }));
      } catch { }
    }

    private void ModbusRead() {
      Work.Work.Reading(devices, SerialPort, tbDemo, tbTime);
    }

    #endregion

    #region Инициализация параметров программы

    private void InitDevices() {
      TRM138 pump1 = new TRM138 { Title = "Насос3", ModbusID = 8 };//0
      pump1.OnError += Device_OnError;
      devices.Add(pump1);

      MK110_8D_4R pump1m1 = new MK110_8D_4R { Title = "Насос3м1", ModbusID = 32 };//1
      pump1m1.OnError += Device_OnError;
      devices.Add(pump1m1);

      MK110_8D_4R pump1m2 = new MK110_8D_4R { Title = "Насос3м2", ModbusID = 48 };//2
      pump1m2.OnError += Device_OnError;
      devices.Add(pump1m2);

      TRM138 pump2 = new TRM138 { Title = "Насос4", ModbusID = 88 };//3
      pump2.OnError += Device_OnError;
      devices.Add(pump2);

      MK110_8D_4R pump2m1 = new MK110_8D_4R { Title = "Насос4м1", ModbusID = 64 };//4
      pump2m1.OnError += Device_OnError;
      devices.Add(pump2m1);

      MK110_8D_4R pump2m2 = new MK110_8D_4R { Title = "Насос4м2", ModbusID = 80 };//5
      pump2m2.OnError += Device_OnError;
      devices.Add(pump2m2);

      ME110 me = new ME110 { Title = "МЭ", ModbusID = 220 };//6
      me.OnError += Device_OnError;
      devices.Add(me);

      MV110_8A tankP = new MV110_8A { Title = "РВС_P", ModbusID = 96 };//7
      tankP.OnError += Device_OnError;
      devices.Add(tankP);

      MK110_8D_4R tankL1 = new MK110_8D_4R { Title = "РВС_L1", ModbusID = 128 };//8
      tankL1.OnError += Device_OnError;
      devices.Add(tankL1);

      MK110_8D_4R tankL2 = new MK110_8D_4R { Title = "РВС_L2", ModbusID = 144 };//9
      tankL2.OnError += Device_OnError;
      devices.Add(tankL2);

      MK110_8D_4R tankL3 = new MK110_8D_4R { Title = "РВС_L3", ModbusID = 160 };//10
      tankL3.OnError += Device_OnError;
      devices.Add(tankL3);

      MK110_8D_4R tankL4 = new MK110_8D_4R { Title = "РВС_L4", ModbusID = 176 };//11
      tankL4.OnError += Device_OnError;
      devices.Add(tankL4);

      Orion orion = new Orion { Title = "Орион", ModbusID = 30 };//12
      orion.OnError += Device_OnError;
      devices.Add(orion);

      // далее изменения от октября
      //необходимо добавить все устройства и указать номер modbus

      TRM138 pistonTRM = new TRM138 { Title = "Поршневые насосы1", ModbusID = 24 };//13
      pistonTRM.OnError += Device_OnError;
      devices.Add(pistonTRM);

      MK110_8D_4R pistonMK = new MK110_8D_4R { Title = "Поршневые насосы МК", ModbusID = 56 };//14
      pistonMK.OnError += Device_OnError;
      devices.Add(pistonMK);

      MV110_8A valves1 = new MV110_8A { Title = "Задвижки1", ModbusID = 104 };//15
      valves1.OnError += Device_OnError;
      devices.Add(valves1);
      MV110_8A valves2 = new MV110_8A { Title = "Задвижки2", ModbusID = 112 };//16
      valves2.OnError += Device_OnError;
      devices.Add(valves2);

      UPES upes1 = new UPES { Title = "УПЭС1", ModbusID = 2 };
      upes1.OnError += Device_OnError;
      devices.Add(upes1);

      UPES upes2 = new UPES { Title = "УПЭС2", ModbusID = 3 };
      upes2.OnError += Device_OnError;
      devices.Add(upes2);

      UPES upes3 = new UPES { Title = "УПЭС3", ModbusID = 4 };
      upes3.OnError += Device_OnError;
      devices.Add(upes3);

      DeviceMapping();

    }

    private void Device_OnError(Device sender) {
      try {
        Application.Current.Dispatcher.Invoke((Action)(() => {
          EventLog eventLog = new EventLog {
            DateTime = DateTime.Now,
            EventLogType = EventLogType.Ошибка,
            Source = sender.Title,
            Message = sender.ErrorMessage,
            Brush = EventLog.GetBrush(EventLogType.Ошибка)
          };
          DataBase.WriteLog(eventLog);
          bool addAlarm = true;
          foreach (EventLog log in Alarms) {
            if (log.Message == eventLog.Message && log.Source == eventLog.Source)
              addAlarm = false;
          }
          if (addAlarm) {
            Alarms.Insert(0, eventLog);
          }
        }));
      } catch { }
    }

    private void Tag_OnErrorTag(EventLog log) {
      try {
        Application.Current.Dispatcher.Invoke((Action)(() => {
          DataBase.WriteLog(log);
          bool addAlarm = true;
          foreach (EventLog arg in Alarms) {
            if (log.Message == arg.Message && log.Source == arg.Source)
              addAlarm = false;
          }
          if (addAlarm)
            Alarms.Insert(0, log);
        }));
      } catch { }
    }

    private void DeviceMapping() {
      pumpMini1.T1p = ((TRM138)GetDeviceByTitle("Насос3")).Input1;
      pump1.T1p = ((TRM138)GetDeviceByTitle("Насос3")).Input1;
      pumpMini1.V1p = ((TRM138)GetDeviceByTitle("Насос3")).Input5;
      pump1.V1p = ((TRM138)GetDeviceByTitle("Насос3")).Input5;
      pumpMini1.T2p = ((TRM138)GetDeviceByTitle("Насос3")).Input2;
      pump1.T2p = ((TRM138)GetDeviceByTitle("Насос3")).Input2;
      pumpMini1.V2p = ((TRM138)GetDeviceByTitle("Насос3")).Input6;
      pump1.V2p = ((TRM138)GetDeviceByTitle("Насос3")).Input6;
      pumpMini1.T1m = ((TRM138)GetDeviceByTitle("Насос3")).Input3;
      pump1.T1m = ((TRM138)GetDeviceByTitle("Насос3")).Input3;
      pumpMini1.V1m = ((TRM138)GetDeviceByTitle("Насос3")).Input7;
      pump1.V1m = ((TRM138)GetDeviceByTitle("Насос3")).Input7;
      pumpMini1.T2m = ((TRM138)GetDeviceByTitle("Насос3")).Input4;
      pump1.T2m = ((TRM138)GetDeviceByTitle("Насос3")).Input4;
      pumpMini1.V2m = ((TRM138)GetDeviceByTitle("Насос3")).Input8;
      pump1.V2m = ((TRM138)GetDeviceByTitle("Насос3")).Input8;

      pumpMini2.T1p = ((TRM138)GetDeviceByTitle("Насос4")).Input1;
      pump2.T1p = ((TRM138)GetDeviceByTitle("Насос4")).Input1;
      pumpMini2.V1p = ((TRM138)GetDeviceByTitle("Насос4")).Input5;
      pump2.V1p = ((TRM138)GetDeviceByTitle("Насос4")).Input5;
      pumpMini2.T2p = ((TRM138)GetDeviceByTitle("Насос4")).Input2;
      pump2.T2p = ((TRM138)GetDeviceByTitle("Насос4")).Input2;
      pumpMini2.V2p = ((TRM138)GetDeviceByTitle("Насос4")).Input6;
      pump2.V2p = ((TRM138)GetDeviceByTitle("Насос4")).Input6;
      pumpMini2.T1m = ((TRM138)GetDeviceByTitle("Насос4")).Input3;
      pump2.T1m = ((TRM138)GetDeviceByTitle("Насос4")).Input3;
      pumpMini2.V1m = ((TRM138)GetDeviceByTitle("Насос4")).Input7;
      pump2.V1m = ((TRM138)GetDeviceByTitle("Насос4")).Input7;
      pumpMini2.T2m = ((TRM138)GetDeviceByTitle("Насос4")).Input4;
      pump2.T2m = ((TRM138)GetDeviceByTitle("Насос4")).Input4;
      pumpMini2.V2m = ((TRM138)GetDeviceByTitle("Насос4")).Input8;
      pump2.V2m = ((TRM138)GetDeviceByTitle("Насос4")).Input8;

      pumpPowerMain.VA = ((ME110)GetDeviceByTitle("МЭ")).Input1;
      pumpPowerMain.VB = ((ME110)GetDeviceByTitle("МЭ")).Input2;
      pumpPowerMain.VC = ((ME110)GetDeviceByTitle("МЭ")).Input3;
      pumpPowerMain.CA = ((ME110)GetDeviceByTitle("МЭ")).Input4;
      pumpPowerMain.CB = ((ME110)GetDeviceByTitle("МЭ")).Input5;
      pumpPowerMain.CC = ((ME110)GetDeviceByTitle("МЭ")).Input6;
      pumpPowerMain.PA = ((ME110)GetDeviceByTitle("МЭ")).Input7;
      pumpPowerMain.PB = ((ME110)GetDeviceByTitle("МЭ")).Input7;
      pumpPowerMain.PC = ((ME110)GetDeviceByTitle("МЭ")).Input7;
      pumpPower.VA = ((ME110)GetDeviceByTitle("МЭ")).Input1;
      pumpPower.VB = ((ME110)GetDeviceByTitle("МЭ")).Input2;
      pumpPower.VC = ((ME110)GetDeviceByTitle("МЭ")).Input3;
      pumpPower.CA = ((ME110)GetDeviceByTitle("МЭ")).Input4;
      pumpPower.CB = ((ME110)GetDeviceByTitle("МЭ")).Input5;
      pumpPower.CC = ((ME110)GetDeviceByTitle("МЭ")).Input6;
      pumpPower.PA = ((ME110)GetDeviceByTitle("МЭ")).Input7;
      pumpPower.PB = ((ME110)GetDeviceByTitle("МЭ")).Input7;
      pumpPower.PC = ((ME110)GetDeviceByTitle("МЭ")).Input7;

      tanks.Tank1P = ((MV110_8A)GetDeviceByTitle("РВС_P")).Input1;
      tanksMini.Tank1P = ((MV110_8A)GetDeviceByTitle("РВС_P")).Input1;
      tanks.Tank2P = ((MV110_8A)GetDeviceByTitle("РВС_P")).Input2;
      tanksMini.Tank2P = ((MV110_8A)GetDeviceByTitle("РВС_P")).Input2;
      tanks.Tank3P = ((MV110_8A)GetDeviceByTitle("РВС_P")).Input3;
      tanksMini.Tank3P = ((MV110_8A)GetDeviceByTitle("РВС_P")).Input3;
      tanks.Tank4P = ((MV110_8A)GetDeviceByTitle("РВС_P")).Input4;
      tanksMini.Tank4P = ((MV110_8A)GetDeviceByTitle("РВС_P")).Input4;
      tanks.Tank5P = ((MV110_8A)GetDeviceByTitle("РВС_P")).Input5;
      tanksMini.Tank5P = ((MV110_8A)GetDeviceByTitle("РВС_P")).Input5;
      tanks.Tank6P = ((MV110_8A)GetDeviceByTitle("РВС_P")).Input6;
      tanksMini.Tank6P = ((MV110_8A)GetDeviceByTitle("РВС_P")).Input6;
      tanks.Tank7P = ((MV110_8A)GetDeviceByTitle("РВС_P")).Input7;
      tanksMini.Tank7P = ((MV110_8A)GetDeviceByTitle("РВС_P")).Input7;
      tanks.Tank8P = ((MV110_8A)GetDeviceByTitle("РВС_P")).Input8;
      tanksMini.Tank8P = ((MV110_8A)GetDeviceByTitle("РВС_P")).Input8;

      tanks.Tank1L1 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L1")).DI1;
      tanks.Tank1L2 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L1")).DI2;
      tanks.Tank2L1 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L1")).DI3;
      tanks.Tank2L2 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L1")).DI5;
      tanks.Tank2L3 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L1")).DI6;
      tanks.Tank2L4 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L1")).DI7;
      tanks.Tank2L5 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L1")).DI8;
      tanks.Tank3L1 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L2")).DI1;
      tanks.Tank3L2 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L2")).DI3;
      tanks.Tank3L3 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L2")).DI4;
      tanks.Tank3L4 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L2")).DI5;
      tanks.Tank3L5 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L2")).DI6;
      tanks.Tank4L1 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L2")).DI7;
      tanks.Tank4L2 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L3")).DI1;
      tanks.Tank4L3 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L3")).DI2;
      tanks.Tank4L4 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L3")).DI3;
      tanks.Tank4L5 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L3")).DI4;
      tanks.Tank5L1 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L3")).DI5;
      tanks.Tank5L2 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L3")).DI6;
      tanks.Tank6L1 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L3")).DI7;
      tanks.Tank6L2 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L3")).DI8;
      tanks.Tank7L1 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L4")).DI1;
      tanks.Tank7L2 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L4")).DI2;
      tanks.Tank8L1 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L4")).DI3;
      tanks.Tank8L2 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L4")).DI4;

      tankAlarmMini.G20 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L4")).DI5;
      tanksAlarm.G20 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L4")).DI5;
      tankAlarmMini.G50 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L4")).DI7;
      tanksAlarm.G50 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L4")).DI7;

      tanksMini.Tank1L1 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L1")).DI1;
      tanksMini.Tank1L2 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L1")).DI2;
      tanksMini.Tank2L1 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L1")).DI3;
      tanksMini.Tank2L2 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L1")).DI5;
      tanksMini.Tank2L3 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L1")).DI6;
      tanksMini.Tank2L4 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L1")).DI7;
      tanksMini.Tank2L5 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L1")).DI8;
      tanksMini.Tank3L1 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L2")).DI1;
      tanksMini.Tank3L2 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L2")).DI3;
      tanksMini.Tank3L3 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L2")).DI4;
      tanksMini.Tank3L4 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L2")).DI5;
      tanksMini.Tank3L5 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L2")).DI6;
      tanksMini.Tank4L1 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L2")).DI7;
      tanksMini.Tank4L2 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L3")).DI1;
      tanksMini.Tank4L3 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L3")).DI2;
      tanksMini.Tank4L4 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L3")).DI3;
      tanksMini.Tank4L5 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L3")).DI4;
      tanksMini.Tank5L1 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L3")).DI5;
      tanksMini.Tank5L2 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L3")).DI6;
      tanksMini.Tank6L1 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L3")).DI7;
      tanksMini.Tank6L2 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L3")).DI8;
      tanksMini.Tank7L1 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L4")).DI1;
      tanksMini.Tank7L2 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L4")).DI2;
      tanksMini.Tank8L1 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L4")).DI3;
      tanksMini.Tank8L2 = ((MK110_8D_4R)GetDeviceByTitle("РВС_L4")).DI4;

      tanksMini.Tank1F = ((Orion)GetDeviceByTitle("Орион")).Input1;
      tanksMini.Tank2F = ((Orion)GetDeviceByTitle("Орион")).Input2;
      tanksMini.Tank3F = ((Orion)GetDeviceByTitle("Орион")).Input3;
      tanksMini.Tank4F = ((Orion)GetDeviceByTitle("Орион")).Input4;
      tanksMini.Tank5F = ((Orion)GetDeviceByTitle("Орион")).Input5;
      tanksMini.Tank6F = ((Orion)GetDeviceByTitle("Орион")).Input6;
      tanksMini.Tank7F = ((Orion)GetDeviceByTitle("Орион")).Input7;
      tanksMini.Tank8F = ((Orion)GetDeviceByTitle("Орион")).Input8;
      tanks.Tank1F = ((Orion)GetDeviceByTitle("Орион")).Input1;
      tanks.Tank2F = ((Orion)GetDeviceByTitle("Орион")).Input2;
      tanks.Tank3F = ((Orion)GetDeviceByTitle("Орион")).Input3;
      tanks.Tank4F = ((Orion)GetDeviceByTitle("Орион")).Input4;
      tanks.Tank5F = ((Orion)GetDeviceByTitle("Орион")).Input5;
      tanks.Tank6F = ((Orion)GetDeviceByTitle("Орион")).Input6;
      tanks.Tank7F = ((Orion)GetDeviceByTitle("Орион")).Input7;
      tanks.Tank8F = ((Orion)GetDeviceByTitle("Орион")).Input8;

      pumpAlarmMini.Alarm = ((MK110_8D_4R)GetDeviceByTitle("Насос3м1")).DI1;
      pumpMini1.PumpRun = ((MK110_8D_4R)GetDeviceByTitle("Насос3м1")).DI3;
      pumpMini1.PumpPower = ((MK110_8D_4R)GetDeviceByTitle("Насос3м1")).DI4;
      pumpAlarm.Alarm = ((MK110_8D_4R)GetDeviceByTitle("Насос3м1")).DI1;
      pump1.PumpRun = ((MK110_8D_4R)GetDeviceByTitle("Насос3м1")).DI3;
      pump1.PumpPower = ((MK110_8D_4R)GetDeviceByTitle("Насос3м1")).DI4;
      
      pumpMini2.PumpRun = ((MK110_8D_4R)GetDeviceByTitle("Насос4м1")).DI3;
      pumpMini2.PumpPower = ((MK110_8D_4R)GetDeviceByTitle("Насос4м1")).DI4;
      pump2.PumpRun = ((MK110_8D_4R)GetDeviceByTitle("Насос4м1")).DI3;
      pump2.PumpPower = ((MK110_8D_4R)GetDeviceByTitle("Насос4м1")).DI4;

      pumpMini1.PumpHighL1 = ((MK110_8D_4R)GetDeviceByTitle("Насос3м2")).DI1;
      pumpMini1.PumpHighL2 = ((MK110_8D_4R)GetDeviceByTitle("Насос3м2")).DI2;
      pumpMini1.PumpLowL1 = ((MK110_8D_4R)GetDeviceByTitle("Насос3м2")).DI3;
      pumpMini1.PumpLowL2 = ((MK110_8D_4R)GetDeviceByTitle("Насос3м2")).DI4;
      pumpAlarmMini.G20 = ((MK110_8D_4R)GetDeviceByTitle("Насос3м2")).DI7;
      pumpAlarmMini.G50 = ((MK110_8D_4R)GetDeviceByTitle("Насос3м2")).DI8;
      //pumpAlarmMini.Fan = ((MK110_8D_4R)GetDeviceByTitle("Насос3м2")).DI6;
      pumpMini1.PumpMaterial = ((MK110_8D_4R)GetDeviceByTitle("Насос3м2")).DI5;
      pump1.PumpHighL1 = ((MK110_8D_4R)GetDeviceByTitle("Насос3м2")).DI1;
      pump1.PumpHighL2 = ((MK110_8D_4R)GetDeviceByTitle("Насос3м2")).DI2;
      pump1.PumpLowL1 = ((MK110_8D_4R)GetDeviceByTitle("Насос3м2")).DI3;
      pump1.PumpLowL2 = ((MK110_8D_4R)GetDeviceByTitle("Насос3м2")).DI4;
      pumpAlarm.G20 = ((MK110_8D_4R)GetDeviceByTitle("Насос3м2")).DI7;
      pumpAlarm.G50 = ((MK110_8D_4R)GetDeviceByTitle("Насос3м2")).DI8;
      //pumpAlarm.Fan = ((MK110_8D_4R)GetDeviceByTitle("Насос3м2")).DI6;
      pump1.PumpMaterial = ((MK110_8D_4R)GetDeviceByTitle("Насос3м2")).DI5;

      pumpMini2.PumpHighL1 = ((MK110_8D_4R)GetDeviceByTitle("Насос4м2")).DI1;
      pumpMini2.PumpHighL2 = ((MK110_8D_4R)GetDeviceByTitle("Насос4м2")).DI2;
      pumpMini2.PumpLowL1 = ((MK110_8D_4R)GetDeviceByTitle("Насос4м2")).DI3;
      pumpMini2.PumpLowL2 = ((MK110_8D_4R)GetDeviceByTitle("Насос4м2")).DI4;
      pumpMini2.PumpMaterial = ((MK110_8D_4R)GetDeviceByTitle("Насос4м2")).DI5;
      pump2.PumpHighL1 = ((MK110_8D_4R)GetDeviceByTitle("Насос4м2")).DI1;
      pump2.PumpHighL2 = ((MK110_8D_4R)GetDeviceByTitle("Насос4м2")).DI2;
      pump2.PumpLowL1 = ((MK110_8D_4R)GetDeviceByTitle("Насос4м2")).DI3;
      pump2.PumpLowL2 = ((MK110_8D_4R)GetDeviceByTitle("Насос4м2")).DI4;
      pump2.PumpMaterial = ((MK110_8D_4R)GetDeviceByTitle("Насос4м2")).DI5;


      // далее изменения от октября
      //необходимо привязать все теги


      gasFiled.Channel1 = ((UPES)GetDeviceByTitle("УПЭС1")).Channel1;
      gasFiled.Channel2 = ((UPES)GetDeviceByTitle("УПЭС1")).Channel2;
      gasFiled.Channel3 = ((UPES)GetDeviceByTitle("УПЭС1")).Channel3;
      gasFiled.Channel4 = ((UPES)GetDeviceByTitle("УПЭС1")).Channel4;
      gasFiled.Channel5 = ((UPES)GetDeviceByTitle("УПЭС1")).Channel5;
      gasFiled.Channel6 = ((UPES)GetDeviceByTitle("УПЭС1")).Channel6;
      gasFiled.Channel7 = ((UPES)GetDeviceByTitle("УПЭС1")).Channel7;
      gasFiled.Channel8 = ((UPES)GetDeviceByTitle("УПЭС1")).Channel8;
      gasFiled.Channel9 = ((UPES)GetDeviceByTitle("УПЭС1")).Channel9;
      gasFiled.Channel10 = ((UPES)GetDeviceByTitle("УПЭС1")).Channel10;
      gasFiled.Channel11 = ((UPES)GetDeviceByTitle("УПЭС1")).Channel11;
      gasFiled.Channel12 = ((UPES)GetDeviceByTitle("УПЭС1")).Channel12;
      gasFiled.Channel13 = ((UPES)GetDeviceByTitle("УПЭС2")).Channel1;
      gasFiled.Channel14 = ((UPES)GetDeviceByTitle("УПЭС2")).Channel2;
      gasFiled.Channel15 = ((UPES)GetDeviceByTitle("УПЭС2")).Channel3;
      gasFiled.Channel16 = ((UPES)GetDeviceByTitle("УПЭС2")).Channel4;
      gasFiled.Channel17 = ((UPES)GetDeviceByTitle("УПЭС2")).Channel5;
      gasFiled.Channel18 = ((UPES)GetDeviceByTitle("УПЭС2")).Channel6;
      gasFiled.Channel19 = ((UPES)GetDeviceByTitle("УПЭС2")).Channel7;
      gasFiled.Channel20 = ((UPES)GetDeviceByTitle("УПЭС2")).Channel8;
      gasFiled.Channel21 = ((UPES)GetDeviceByTitle("УПЭС2")).Channel9;
      gasFiled.Channel22 = ((UPES)GetDeviceByTitle("УПЭС2")).Channel10;
      gasFiled.Channel23 = ((UPES)GetDeviceByTitle("УПЭС2")).Channel11;
      gasFiled.Channel24 = ((UPES)GetDeviceByTitle("УПЭС2")).Channel12;
      gasFiled.Channel25 = ((UPES)GetDeviceByTitle("УПЭС3")).Channel1;
      gasFiled.Channel26 = ((UPES)GetDeviceByTitle("УПЭС3")).Channel2;
      gasFiled.Channel27 = ((UPES)GetDeviceByTitle("УПЭС3")).Channel3;
      gasFiled.Channel28 = ((UPES)GetDeviceByTitle("УПЭС3")).Channel4;
      gasFiled.Channel29 = ((UPES)GetDeviceByTitle("УПЭС3")).Channel5;
      gasFiled.Channel30 = ((UPES)GetDeviceByTitle("УПЭС3")).Channel6;
      gasFiled.Channel31 = ((UPES)GetDeviceByTitle("УПЭС3")).Channel7;
      gasFiled.Channel32 = ((UPES)GetDeviceByTitle("УПЭС3")).Channel8;
      gasFiled.Channel33 = ((UPES)GetDeviceByTitle("УПЭС3")).Channel9;
      gasFiled.Channel34 = ((UPES)GetDeviceByTitle("УПЭС3")).Channel10;
      gasFiled.Channel35 = ((UPES)GetDeviceByTitle("УПЭС3")).Channel11;
      gasFiled.Channel36 = ((UPES)GetDeviceByTitle("УПЭС3")).Channel12;
      gasFiled.Channel37 = ((UPES)GetDeviceByTitle("УПЭС3")).Channel13;
      gasFiled.Channel38 = ((UPES)GetDeviceByTitle("УПЭС3")).Channel14;


      pistonPump.Pump1Press = ((TRM138)GetDeviceByTitle("Поршневые насосы1")).Input1;
      pistonPump.Pump1Run = ((MK110_8D_4R)GetDeviceByTitle("Поршневые насосы МК")).DI4;
      pistonPump.Pump2Press = ((TRM138)GetDeviceByTitle("Поршневые насосы1")).Input2;
      pistonPump.Pump2Run = ((MK110_8D_4R)GetDeviceByTitle("Поршневые насосы МК")).DI6;
      pistonPump.Pump5Press = ((TRM138)GetDeviceByTitle("Поршневые насосы1")).Input3;
      pistonPump.Pump5Run = ((MK110_8D_4R)GetDeviceByTitle("Поршневые насосы МК")).DI8;
      pumpAlarmMini.Fan = ((MK110_8D_4R)GetDeviceByTitle("Поршневые насосы МК")).DI2;
      pumpAlarm.Fan = ((MK110_8D_4R)GetDeviceByTitle("Поршневые насосы МК")).DI2;

      valves.Valve1 = ((MV110_8A)GetDeviceByTitle("Задвижки1")).Input1;
      valves.Valve2 = ((MV110_8A)GetDeviceByTitle("Задвижки1")).Input2;
      valves.Valve3 = ((MV110_8A)GetDeviceByTitle("Задвижки1")).Input3;
      valves.Valve4 = ((MV110_8A)GetDeviceByTitle("Задвижки1")).Input4;
      valves.Valve5 = ((MV110_8A)GetDeviceByTitle("Задвижки1")).Input5;
      valves.Valve6 = ((MV110_8A)GetDeviceByTitle("Задвижки2")).Input1;
      valves.Valve7 = ((MV110_8A)GetDeviceByTitle("Задвижки2")).Input2;
      valves.Valve8 = ((MV110_8A)GetDeviceByTitle("Задвижки2")).Input3;
      valves.Valve9 = ((MV110_8A)GetDeviceByTitle("Задвижки2")).Input4;
      valves.Valve10 = ((MV110_8A)GetDeviceByTitle("Задвижки2")).Input5;


      pump1.OnErrorTag += Tag_OnErrorTag;
      pump2.OnErrorTag += Tag_OnErrorTag;
      pumpPower.OnErrorTag += Tag_OnErrorTag;
      tanks.OnErrorTag += Tag_OnErrorTag;
      pump1.PumpAllow = AllowPump1;
      pump2.PumpAllow = AllowPump2;
      pumpMini1.PumpAllow = AllowPump1;
      pumpMini2.PumpAllow = AllowPump2;
      pumpAlarm.OnErrorTag += Tag_OnErrorTag;
      tanksAlarm.OnErrorTag += Tag_OnErrorTag;

      gasFiled.OnErrorTag += Tag_OnErrorTag;
      pistonPump.OnErrorTag += Tag_OnErrorTag;
      valves.OnErrorTag += Tag_OnErrorTag;

    }

    private Device GetDeviceByTitle(string title) {
      foreach (Device d in devices)
        if (d.Title == title)
          return d;
      return null;
    }

    #endregion

    #region Методы кнопок

    private void MenuBtn(object sender, RoutedEventArgs e) {
      btnMain.Background = new SolidColorBrush(Colors.LightGray);
      btnRP.Background = new SolidColorBrush(Colors.LightGray);
      btnPump.Background = new SolidColorBrush(Colors.LightGray);
      btnGas.Background = new SolidColorBrush(Colors.LightGray);
      btnEvents.Background = new SolidColorBrush(Colors.LightGray);
      btnValve.Background = new SolidColorBrush(Colors.LightGray);
      Button btn = sender as Button;
      btn.Background = new SolidColorBrush(Color.FromRgb(43, 137, 200));
      gridMain.Visibility = Visibility.Collapsed;
      gridRP.Visibility = Visibility.Collapsed;
      gridPump.Visibility = Visibility.Collapsed;
      gridGas.Visibility = Visibility.Collapsed;
      gridValve.Visibility = Visibility.Collapsed;
      gridEvents.Visibility = Visibility.Collapsed;
      switch (btn.Name) {
        case "btnMain":
          gridMain.Visibility = Visibility.Visible;
          break;
        case "btnRP":
          gridRP.Visibility = Visibility.Visible;
          break;
        case "btnPump":
          gridPump.Visibility = Visibility.Visible;
          break;
        case "btnGas":
          gridGas.Visibility = Visibility.Visible;
          break;
        case "btnValve":
          gridValve.Visibility = Visibility.Visible;
          break;
        case "btnEvents":
          gridEvents.Visibility = Visibility.Visible;
          break;

      }
    }

    private void MenuAccess_Click(object sender, RoutedEventArgs e) => new ChangeUserWindow(this).ShowDialog();

    private void Setting_Click(object sender, RoutedEventArgs e) {
      new SettingWindow(this).ShowDialog();
    }

    #endregion

    #region остальные методы

    public void StartMain() {
      pumpMini1.StartUpdate();
      pumpMini2.StartUpdate();
      pumpPowerMain.StartUpdate();
      tanksMini.StartUpdate();
      tankAlarmMini.StartUpdate();
      pumpAlarmMini.StartUpdate();
    }

    public void StopMain() {
      pumpMini1.StopUpdate();
      pumpMini2.StopUpdate();
      pumpPowerMain.StopUpdate();
      pumpAlarmMini.StopUpdate();
      tanksMini.StopUpdate();
      tankAlarmMini.StopUpdate();
    }

    public void StartPump() {
      pump1.StartUpdate();
      pump2.StartUpdate();
      pumpPower.StartUpdate();
      pumpAlarm.StartUpdate();
      pistonPump.StartUpdate();
    }

    public void StopPump() {
      pump1.StopUpdate();
      pump2.StopUpdate();
      pumpPower.StopUpdate();
      pumpAlarm.StopUpdate();
    }

    public void StartTank() {
      tanks.StartUpdate();
      tanksMini.StartUpdate();
      tanksAlarm.StartUpdate();
    }

    public void StopTank() {
      tanks.StopUpdate();
      tanksAlarm.StopUpdate();
    }

    public void StartGas() {
      gasFiled.StartUpdate();
    }

    public void StopGas() {
      gasFiled.StopUpdate();
    }

    public void StartValve() {
      valves.StartUpdate();
    }

    private void EventLogsMini_LostFocus(object sender, RoutedEventArgs e) {
      eventLogsMini.UnselectAll();
    }

    private void MenuItem_Click(object sender, RoutedEventArgs e) {
      if (eventLogsMini.SelectedItem == null) return;
      for (int i = 0; i < Alarms.Count; i++) {
        if (Alarms[i] == (EventLog)eventLogsMini.SelectedItem) {
          Alarms.Remove(Alarms[i]);
          return;
        }
      }
    }

    private void AllowPump2_OnChangeValue(Tag sender) {
      AllowPumpEvent("Насос4", sender.Value == 1 ? "Запуск насоса разрешен" : "Запуск насоса запрещен");
      Work.Work.WriteAllowPump(GetDeviceByTitle("Насос4м1"), sender.Value == 1);
    }

    private void AllowPump1_OnChangeValue(Tag sender) {
      AllowPumpEvent("Насос3", sender.Value == 1 ? "Запуск насоса разрешен" : "Запуск насоса запрещен");
      Work.Work.WriteAllowPump(GetDeviceByTitle("Насос3м1"), sender.Value == 1);

    }

    private void AllowPumpEvent(string source, string message) {
      EventLog eventLog = new EventLog {
        DateTime = DateTime.Now,
        EventLogType = EventLogType.Сообщение,
        Source = source,
        Message = message,
        Brush = EventLog.GetBrush(EventLogType.Сообщение)
      };
      DataBase.WriteLog(eventLog);
    }

    #endregion

    #region Update
    public void UpdateVersion() {
      Application.Current.Dispatcher.Invoke((Action)(() => {
        string version = "";
        try {
          HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://spautomation.ru/operator/version.txt");
          request.Timeout = 5000;
          HttpWebResponse response = (HttpWebResponse)request.GetResponse();
          if (response.StatusCode == HttpStatusCode.OK) {
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = null;
            if (response.CharacterSet == null) {
              readStream = new StreamReader(receiveStream);
            } else {
              readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
            }
            version = readStream.ReadToEnd();
            response.Close();
            readStream.Close();
          } else {
            new ServiceWindows.MessageView("Сервер обновлений недоступен", "", ServiceWindows.MessageViewMode.Attention).ShowDialog();
          }
        } catch {
          new ServiceWindows.MessageView("Сервер обновлений недоступен", "", ServiceWindows.MessageViewMode.Attention).ShowDialog();
        }
        if (version == "")
          return;
        string curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString().Substring(0,
           System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString().Length - 2);
        if (version != curVersion) {
          string remoteUri = "http://spautomation.ru/operator/";
          string fileName = "Updater.exe", myStringWebResource = null;
          WebClient myWebClient = new WebClient();
          myWebClient.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
          myStringWebResource = remoteUri + fileName;
          Uri url = new Uri(remoteUri + fileName);
          myWebClient.DownloadFileAsync(url, fileName);
          System.Threading.Thread.Sleep(500);
          System.Diagnostics.Process updater = new System.Diagnostics.Process();
          updater.StartInfo.FileName = "updater";
          updater.StartInfo.Arguments = "d \"" + Environment.CurrentDirectory + "\"\\";
          for (int i = 0; i < 10; i++) {
            if (File.Exists(Environment.CurrentDirectory + "\\" + "Updater.exe")) {
              try {
                updater.Start();
                break;
              } catch (Exception e) {
               // Service.Log.LogWrite(Core.Work.EnvPath, e.Message, e.ToString());
              }
            } else {
              System.Threading.Thread.Sleep(500);
            }
          }
        } else {
          new ServiceWindows.MessageView("Текущая версия актуальна", "", ServiceWindows.MessageViewMode.Message).ShowDialog();
        }
      }));
    }
    #endregion

    private void Connection_Click(object sender, RoutedEventArgs e) {
      ConnectionWindow cw = new ConnectionWindow(devices);
      cw.Owner = this;
      cw.ShowDialog();
    }

    private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e) {
      if (e.Key == System.Windows.Input.Key.F1) {
        System.Diagnostics.Process.Start("Reference.rtf");
      }
    }
  }
}
