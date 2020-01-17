using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace SPAControls {
  public partial class GasLamp : UserControl, INotifyPropertyChanged {
    public GasLamp() {
      InitializeComponent();
      DataContext = this;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string prop = "") {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    private string title = "Параметр";
    public string Title {
      get { return title; }
      set {
        title = value;
        OnPropertyChanged("Title");
      }
    }
    public int SPAFontSize { get; set; }


    private int value = 0;


    public int Value {
      get { return this.value; }
      set {
        this.value = value;
        switch (this.value) {
          case 0:
            Title = this.Name + ": Норма";
            lampGrid.Background = new SolidColorBrush(Colors.LightGreen);
            ErrorMessage = "";
            break;
          case 1:
            Title = this.Name + ": Внимание";
            lampGrid.Background = new SolidColorBrush(Colors.Yellow);
            ErrorMessage = "0|Превышен показатель в 20%";
            break;
          case 2:
            Title = this.Name + ": ГАЗ";
            lampGrid.Background = new SolidColorBrush(Colors.Red);
            ErrorMessage = "1|Превышен показатель в 50%";
            break;
          case 3:
            Title = this.Name + ": Ошибка";
            lampGrid.Background = new SolidColorBrush(Colors.Blue);
            ErrorMessage = "2|Неисправность датчика";
            break;
        }
      }
    }

    public delegate void ErrorTag(string errorMessage);
    public event ErrorTag OnErrorTag;
    private string errorMessage = "";
    public string ErrorMessage {
      get { return errorMessage; }
      set {
        if (errorMessage != value) {
          errorMessage = value;
          if (value != "")
            OnErrorTag?.Invoke(value);
        }
      }
    }

  }
}
