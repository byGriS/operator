using System.IO.Ports;
using System.Text;
using System.Windows;

namespace Operator {
  public partial class SettingWindow : Window {
    private MainWindow mainWindow = null;

    public SettingWindow(MainWindow mainWindow) {
      InitializeComponent();
      this.mainWindow = mainWindow;
      cbCOMPort.ItemsSource = SerialPort.GetPortNames();
      if ((mainWindow.SerialPort == null) && (cbCOMPort.Items.Count > 0))
        cbCOMPort.SelectedIndex = 0;
      else
        cbCOMPort.SelectedItem = mainWindow.SerialPort.PortName;
      btnOk.IsEnabled = !mainWindow.IsDemo;
      lVer.Content = "Версия " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString().Substring(0,
           System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString().Length - 2);
    }

    private void BindingPC_Click(object sender, RoutedEventArgs e) {
      StringBuilder pass = new StringBuilder();
      if (new ServiceWindows.MessageInput("Введите пароль разработчика", "Пароль", pass, false).ShowDialog() == true) {
        if (pass.ToString() == "nkspa14") {
          License.WriteLicense();
          new ServiceWindows.MessageView("ПО привязано к данному ПК", "", ServiceWindows.MessageViewMode.Message).ShowDialog();
        } else {
          new ServiceWindows.MessageView("Неверный пароль", "", ServiceWindows.MessageViewMode.Attention).ShowDialog();
        }
      }
    }

    private void NewPass_Click(object sender, RoutedEventArgs e) {
      if (tbOldPass.Text == mainWindow.AdminPass) {
        mainWindow.AdminPass = tbNewPass.Text;
        tbNewPass.Text = "";
        tbOldPass.Text = "";
        new ServiceWindows.MessageView("Пароль изменен", "", ServiceWindows.MessageViewMode.Message).ShowDialog();
      } else {
        new ServiceWindows.MessageView("Неверный пароль", "", ServiceWindows.MessageViewMode.Attention).ShowDialog();
      }
    }

    private void Cancel_Click(object sender, RoutedEventArgs e) {
      this.Close();
    }

    private void Ok_Click(object sender, RoutedEventArgs e) {
      if (cbCOMPort.SelectedItem != null)
        try {
          mainWindow.SerialPort.PortName = cbCOMPort.SelectedItem.ToString();
        } catch { }
      Service.WorkFile.Do("data.dat", Service.WorkFileMode.WriteNew, mainWindow.AdminPass + "\n" + cbCOMPort.SelectedItem.ToString());
      this.Close();
    }

    private void Button_Click(object sender, RoutedEventArgs e) {
      mainWindow.UpdateVersion();
    }
  }
}