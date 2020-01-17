using Service;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace Operator {
  public partial class ConnectionWindow : Window {
    ObservableCollection<Device> devices;
    public ConnectionWindow(ObservableCollection<Device> devices) {
      InitializeComponent();
      this.devices = devices;
    }

    private void Cancel_Click(object sender, RoutedEventArgs e) {
      this.Close();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e) {
      Refresh_Click(null, null);
    }

    private void Refresh_Click(object sender, RoutedEventArgs e) {
      l1.Content = devices[0].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l2.Content = devices[1].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l3.Content = devices[2].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l4.Content = devices[3].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l5.Content = devices[4].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l6.Content = devices[5].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l7.Content = devices[6].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l8.Content = devices[7].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l9.Content = devices[8].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l10.Content = devices[9].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l11.Content = devices[10].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l12.Content = devices[11].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l13.Content = devices[12].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l14.Content = devices[13].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l15.Content = devices[14].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l16.Content = devices[15].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l17.Content = devices[16].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l18.Content = devices[17].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l19.Content = devices[18].ErrorMessage == "" ? "связь Ок" : "нет связи";
      l20.Content = devices[19].ErrorMessage == "" ? "связь Ок" : "нет связи";

      l1.Foreground = devices[0].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l2.Foreground = devices[1].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l3.Foreground = devices[2].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l4.Foreground = devices[3].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l5.Foreground = devices[4].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l6.Foreground = devices[5].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l7.Foreground = devices[6].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l8.Foreground = devices[7].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l9.Foreground = devices[8].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l10.Foreground = devices[9].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l11.Foreground = devices[10].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l12.Foreground = devices[11].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l13.Foreground = devices[12].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l14.Foreground = devices[13].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l15.Foreground = devices[14].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l16.Foreground = devices[15].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l17.Foreground = devices[16].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l18.Foreground = devices[17].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l19.Foreground = devices[18].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
      l20.Foreground = devices[19].ErrorMessage == "" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
    }
  }
}
