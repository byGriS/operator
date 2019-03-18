using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace SPAControls {
  public partial class Valve : UserControl, INotifyPropertyChanged {
    public Valve() {
      InitializeComponent();
      this.DataContext = this;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string prop = "") {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    public string Title { get; set; }
    public int SPAFontSize { get; set; }

    private string valueText = "Закрыта";
    public string ValueText {
      get {return valueText; }
      set {
        valueText = value;
        OnPropertyChanged("ValueText");
      }
    }

    private int value = 1;
    public int Value {
      get { return this.value; }
      set {
        this.value = value;
        switch (value) {
          case 0:
            gridBG.Background = new SolidColorBrush(Colors.Green);
            ValueText = "Открыта";
            break;
          case 1:
            gridBG.Background = new SolidColorBrush(Colors.Blue);
            ValueText = "Закрыта";
            break;
          case 2:
            gridBG.Background = new SolidColorBrush(Colors.Red);
            ValueText = "Авария";
            break;
          case 3:
            gridBG.Background = new SolidColorBrush(Colors.Yellow);
            ValueText = "Процесс";
            break;
        }
      }
    }
  }
}
