using System.Text;
using System.Windows;

namespace Operator {
  public partial class ChangeUserWindow : Window {
    private MainWindow mainWindow = null;

    public ChangeUserWindow(MainWindow mainWindow) {
      InitializeComponent();
      this.mainWindow = mainWindow;
    }

    private void operator_Click(object sender, RoutedEventArgs e) {
      mainWindow.IsAdmin = false;
      this.Close();
    }

    private void admin_Click(object sender, RoutedEventArgs e) {
      StringBuilder pass = new StringBuilder();
      if (new ServiceWindows.MessageInput("Введите пароль администратора", "Пароль", pass, false).ShowDialog() == true) {
        if (pass.ToString() == mainWindow.AdminPass) {
          mainWindow.IsAdmin = true;
          this.Close();
        } else {
          new ServiceWindows.MessageView("Неверный пароль", "", ServiceWindows.MessageViewMode.Attention).ShowDialog();
        }
      }
    }

    private void Close_Click(object sender, RoutedEventArgs e) {
      this.Close();
    }
  }
}
