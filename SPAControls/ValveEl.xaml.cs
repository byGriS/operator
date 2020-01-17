using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace SPAControls {
  public partial class ValveEl : UserControl, INotifyPropertyChanged {

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string prop = "") {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    public ValveEl() {
      InitializeComponent();
      DataContext = this;
    }

    private string title = "Задвижка";
    public string Title {
      get { return title; }
      set {
        title = value;
        OnPropertyChanged("Value");
      }
    }

    private string state = "Закрыта";
    public string State {
      get { return state; }
      set {
        state = value;
        OnPropertyChanged("State");
      }
    }

    private int value = 0;
    public int Value {
      get { return this.value; }
      set {
        this.value = value;
        switch (this.value) {
          case 3:
            State = "Закрыта";
            ellipse.Fill = new SolidColorBrush(Colors.Yellow);
            ErrorMessage = "Закрыта";
            break;
          case 1:
            State = "Промежуточное\nположение";
            ellipse.Fill = new SolidColorBrush(Colors.Gray);
            ErrorMessage = "Промежуточное положение";
            break;
          case 2:
            State = "Открыта";
            ellipse.Fill = new SolidColorBrush(Colors.Green);
            ErrorMessage = "Открыта";
            break;
          case 4:
            State = "Муфта";
            ellipse.Fill = new SolidColorBrush(Colors.Red);
            ErrorMessage = "Сработала предохранительная муфта";
            break;
        }
      }
    }

    public delegate void ErrorTag(string title, string errorMessage);
    public event ErrorTag OnErrorTag;
    private string errorMessage = "";
    public string ErrorMessage {
      get { return errorMessage; }
      set {
        if (errorMessage != value) {
          errorMessage = value;
          if (value != "")
            OnErrorTag?.Invoke(Title, value);
        }
      }
    }

  }
}
