using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace SPAControls {
  public partial class Digital : UserControl, INotifyPropertyChanged {
    public Digital() {
      InitializeComponent();
      this.DataContext = this;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string prop = "") {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    public int SPAFontSize { get; set; }

    public float Max { get; set; }
    public float Min { get; set; }

    private float value = 0;
    public float Value {
      get { return this.value; }
      set {
        if (value < 0)
          this.value = 0;
        else
          this.value = (float)Math.Round(value, 1); 
        OnPropertyChanged("Value");
        ellipse.Fill = ((this.value > Max) || (this.value < Min)) ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Green);
        if (this.value > Max)
          ErrorMessage = "Аварийное высокое значение";
        else {
          if (this.value < Min)
            ErrorMessage = "Аварийное низкое значение";
          else
            ErrorMessage = "";
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
