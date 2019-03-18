using System.ComponentModel;
using System.Windows.Controls;

namespace SPAControls {
  public partial class DigitalText : UserControl, INotifyPropertyChanged {
    public DigitalText() {
      InitializeComponent();
      this.DataContext = this;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string prop = "") {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    public string Title { get; set; }
    public int SPAFontSize { get; set; }

    private float value = 0;
    public float Value {
      get { return value; }
      set {
        this.value = value;
        OnPropertyChanged("Value");
      }
    }
  }
}
