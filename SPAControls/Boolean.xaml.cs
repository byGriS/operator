using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace SPAControls {
  public partial class Boolean : UserControl, INotifyPropertyChanged {
    public Boolean() {
      InitializeComponent();
      this.DataContext = this;
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
    public string TextValue1 { get; set; }
    public string TextValue2 { get; set; }
    public int SPAFontSize { get; set; }
    public bool IsRedGreen { get; set; }
    public bool IsGreenRed{ get; set; }
    public bool IsGrayRed { get; set; }
    public bool IsGrayBlue { get; set; }

    private int value = 0;


    public int Value {
      get { return this.value; }
      set {
        this.value = value;
        if (TextValue1 != null)
          Title = value == 1 ? TextValue1 : TextValue2;
        if (IsRedGreen) {
          ellipse.Fill = (value == 0) ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Green);
        }
        if (IsGreenRed) {
          ellipse.Fill = (value == 0) ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        }
        if (IsGrayBlue) {
          ellipse.Fill = (value == 0) ? new SolidColorBrush(Colors.Blue) : new SolidColorBrush(Colors.Gray);
        }
        if (IsGrayRed) {
          ellipse.Fill = (value != 1019 && value != 1) ? new SolidColorBrush(Colors.Gray) : new SolidColorBrush(Colors.Red);
          if (value == 1019 || value == 1) {
            ErrorMessage = "Пожарная сигнализация";
          } else {
            ErrorMessage = "";
          }
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