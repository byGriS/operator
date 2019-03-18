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
        this.value = value;
        OnPropertyChanged("Value");
        ellipse.Fill = ((value > Max) || (value < Min)) ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Green);
      }
    }
  }
}
