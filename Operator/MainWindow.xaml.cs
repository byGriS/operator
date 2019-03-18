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
    public SerialPort SerialPort { get; set; } = new SerialPort { PortName = "COM1", BaudRate = 9600, DataBits = 8, Parity = Parity.None, StopBits = StopBits.One };

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

    private bool isAdmin = false;
    public bool IsAdmin {
      get { return isAdmin; }
      set {
        isAdmin = value;
        if (isAdmin) {
          tbUser.Text = "Администратор";
        }else {
          tbUser.Text = "Оператор";
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
      AllowPump1.OnChangeValue += AllowPump1_OnChangeValue;
      AllowPump2.OnChangeValue += AllowPump2_OnChangeValue;
      if (!IsDemo) {
        System.Threading.Thread modbus = new System.Threading.Thread(ModbusRead);
        modbus.Start();
        tbDemo.Visibility = Visibility.Collapsed;
        tbUser.Visibility = Visibility.Visible;
      }
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
      Application.Current.Dispatcher.Invoke((Action)(() => {
        DataBase.ReadNewLogs(Logs);
      }));
    }

    private void ModbusRead() {
      Work.Work.Reading(devices);
    }

    #endregion

    #region Инициализация параметров программы

    private void InitDevices() {
      TRM138 pump1 = new TRM138 { Title = "Насос4", ModbusID = 8 };
      pump1.OnError += Device_OnError;
      devices.Add(pump1);
      TRM138 pump2 = new TRM138 { Title = "Насос5", ModbusID = 61 };
      pump2.OnError += Device_OnError;
      devices.Add(pump2);

      DeviceMapping();
    }

    private void Device_OnError(Device sender) {
      Application.Current.Dispatcher.Invoke((Action)(() => {
        EventLog eventLog = new EventLog {
        DateTime = DateTime.Now,
        EventLogType = EventLogType.Ошибка,
        Source = sender.Title,
        Message = sender.ErrorMessage,
        Brush = EventLog.GetBrush(EventLogType.Ошибка)
      };      
        DataBase.WriteLog(eventLog);
        Alarms.Add(eventLog);
      }));

    }

    private void DeviceMapping() {
      pumpMini1.T1p = TestFloat;
      pump1.T1p = TestFloat;
      pumpMini1.V1p = ((TRM138)GetDeviceByTitle("Насос4")).Input2;
      pump1.V1p = ((TRM138)GetDeviceByTitle("Насос4")).Input2;
      pumpMini1.T2p = ((TRM138)GetDeviceByTitle("Насос4")).Input3;
      pump1.T2p = ((TRM138)GetDeviceByTitle("Насос4")).Input3;
      pumpMini1.V2p = ((TRM138)GetDeviceByTitle("Насос4")).Input4;
      pump1.V2p = ((TRM138)GetDeviceByTitle("Насос4")).Input4;
      pumpMini1.T1m = ((TRM138)GetDeviceByTitle("Насос4")).Input5;
      pump1.T1m = ((TRM138)GetDeviceByTitle("Насос4")).Input5;
      pumpMini1.V1m = ((TRM138)GetDeviceByTitle("Насос4")).Input6;
      pump1.V1m = ((TRM138)GetDeviceByTitle("Насос4")).Input6;
      pumpMini1.T2m = ((TRM138)GetDeviceByTitle("Насос4")).Input7;
      pump1.T2m = ((TRM138)GetDeviceByTitle("Насос4")).Input7;
      pumpMini1.V2m = ((TRM138)GetDeviceByTitle("Насос4")).Input8;
      pump1.V2m = ((TRM138)GetDeviceByTitle("Насос4")).Input8;

      pumpMini2.T1p = ((TRM138)GetDeviceByTitle("Насос5")).Input1;
      pump2.V1p = ((TRM138)GetDeviceByTitle("Насос5")).Input2;
      pumpMini2.V1p = ((TRM138)GetDeviceByTitle("Насос5")).Input2;
      pump2.T2p = ((TRM138)GetDeviceByTitle("Насос5")).Input3;
      pumpMini2.T2p = ((TRM138)GetDeviceByTitle("Насос5")).Input3;
      pump2.V2p = ((TRM138)GetDeviceByTitle("Насос5")).Input4;
      pumpMini2.V2p = ((TRM138)GetDeviceByTitle("Насос5")).Input4;
      pump2.T1m = ((TRM138)GetDeviceByTitle("Насос5")).Input5;
      pumpMini2.T1m = ((TRM138)GetDeviceByTitle("Насос5")).Input5;
      pump2.V1m = ((TRM138)GetDeviceByTitle("Насос5")).Input6;
      pumpMini2.V1m = ((TRM138)GetDeviceByTitle("Насос5")).Input6;
      pump2.T2m = ((TRM138)GetDeviceByTitle("Насос5")).Input7;
      pumpMini2.T2m = ((TRM138)GetDeviceByTitle("Насос5")).Input7;
      pump2.V2m = ((TRM138)GetDeviceByTitle("Насос5")).Input8;
      pumpMini2.V2m = ((TRM138)GetDeviceByTitle("Насос5")).Input8;

      pump1.PumpAllow = AllowPump1;
      pump1.PumpRun = TestBool;
      pump1.PumpHighL = TestBool;
      tanks.Tank1L = TestFloat;
      tanksMini.Tank1L = TestFloat;
      tanks.Tank1P = TestFloat;
      tanksMini.Tank1P = TestFloat;
      tanks.Tank2F = TestBool;
      tanksMini.Tank2F = TestBool;
      pumpAlarm.G20 = TestBool;
      pumpAlarmMini.G20 = TestBool;
      pumpPower.VA = TestFloat;
      pumpPowerMain.VA = TestFloat;

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
      btnEvents.Background = new SolidColorBrush(Colors.LightGray);
      Button btn = sender as Button;
      btn.Background = new SolidColorBrush(Color.FromRgb(43, 137, 200));
      gridMain.Visibility = Visibility.Collapsed;
      gridRP.Visibility = Visibility.Collapsed;
      gridPump.Visibility = Visibility.Collapsed;
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
      pumpPowerMain.StartUpdate();
      tanksMini.StartUpdate();
      tankAlarmMini.StartUpdate();
      pumpAlarmMini.StartUpdate();
    }

    public void StopMain() {
      pumpMini1.StopUpdate();
      pumpPowerMain.StopUpdate();
      pumpAlarmMini.StopUpdate();
      tanksMini.StopUpdate();
      tankAlarmMini.StopUpdate();
    }

    public void StartPump() {
      pump1.StartUpdate();
      pumpPower.StartUpdate();
      pumpAlarm.StartUpdate();
    }

    public void StopPump() {
      pump1.StopUpdate();
      pumpPower.StopUpdate();
      pumpAlarm.StopUpdate();
    }

    public void StartTank() {
      tanks.StartUpdate();
      tanksAlarm.StartUpdate();
    }

    public void StopTank() {
      tanks.StopUpdate();
      tanksAlarm.StopUpdate();
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
      AllowPumpEvent("Насос5", sender.Value == 1 ? "Запуск насоса разрешен" : "Запуск насоса запрещен");
    }

    private void AllowPump1_OnChangeValue(Tag sender) {
      AllowPumpEvent("Насос4", sender.Value == 1 ? "Запуск насоса разрешен" : "Запуск насоса запрещен");
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
  }
}
