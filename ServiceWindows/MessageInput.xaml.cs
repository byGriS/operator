using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace ServiceWindows {
  public partial class MessageInput : Window {

    private StringBuilder value;

    public MessageInput(string message, string caption, StringBuilder value, bool isOnlyDigit) {
      InitializeComponent();
      this.Title = caption;
      label.Content = message;
      this.value = value;
      if (isOnlyDigit)
        tb.PreviewTextInput += Tb_PreviewTextInput;
    }

    private void Tb_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e) {
      Regex regex = new Regex("[^0-9]+");
      e.Handled = regex.IsMatch(e.Text);
    }

    private void Close_Click(object sender, RoutedEventArgs e) {
      this.Close();
    }

    private void Ok_Click(object sender, RoutedEventArgs e) {
      value.Append(tb.Text);
      DialogResult = true;
      this.Close();
    }

    private void keyboard_Click(object sender, RoutedEventArgs e) {
      string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.System);
      Process.Start(path + @"\osk.exe");
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
      Process[] result = Process.GetProcessesByName("osk");
      if (result.Length > 0) {
        foreach (Process arg in result)
          arg.Kill();
      }
    }

    private void Window_Loaded(object sender, RoutedEventArgs e) {
      tb.Focus();
    }
  }
}
