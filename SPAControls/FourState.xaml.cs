using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace SPAControls {
  public partial class FourState : UserControl, INotifyPropertyChanged {
    public FourState() {
      InitializeComponent();
      this.DataContext = this;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string prop = "") {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    private string title = "Норма";
    public string Title {
      get { return title; }
      set {
        title = value;
        OnPropertyChanged("Title");
      }
    }

    public int SPAFontSize { get; set; }

    private int value = 1;
    public int Value {
      get { return this.value; }
      set {
        this.value = value;
        switch (value) {
          case 0: 
          gridBG.Background = new SolidColorBrush(Colors.Red);
            Title = "Низкий";
            break;
          case 1:
          gridBG.Background = new SolidColorBrush(Colors.Gray);
            Title = "Норма";
            break;
          case 2:
            gridBG.Background = new SolidColorBrush(Colors.Yellow);
            Title = "90%";
            break;
          case 3:
            gridBG.Background = new SolidColorBrush(Colors.Red);
            Title = "95%";
            break;
        }
      }
    }
  }
}

