using System.Windows.Controls;
using System.Windows.Media;

namespace SPAControls {
  public partial class LevelV : UserControl {
    public LevelV() {
      InitializeComponent();
    }

    private int value = 1;
    public int Value {
      get { return this.value; }
      set {
        this.value = value;
        switch (value) {
          case 0:
            gridL1.Background = new SolidColorBrush(Colors.Blue);
            gridL2.Background = new SolidColorBrush(Colors.LightGray);
            gridL3.Background = new SolidColorBrush(Colors.LightGray);
            gridL4.Background = new SolidColorBrush(Colors.LightGray);
            ErrorMessage = "Аварийное низкое значение";
            break;
          case 1:
            gridL2.Background = new SolidColorBrush(Colors.Green);
            gridL1.Background = new SolidColorBrush(Colors.LightGray);
            gridL3.Background = new SolidColorBrush(Colors.LightGray);
            gridL4.Background = new SolidColorBrush(Colors.LightGray);
            ErrorMessage = "";
            break;
          case 2:
            gridL3.Background = new SolidColorBrush(Colors.Yellow);
            gridL2.Background = new SolidColorBrush(Colors.LightGray);
            gridL1.Background = new SolidColorBrush(Colors.LightGray);
            gridL4.Background = new SolidColorBrush(Colors.LightGray);
            ErrorMessage = "Высокое значение";
            break;
          case 3:
            gridL4.Background = new SolidColorBrush(Colors.Red);
            gridL2.Background = new SolidColorBrush(Colors.LightGray);
            gridL3.Background = new SolidColorBrush(Colors.LightGray);
            gridL1.Background = new SolidColorBrush(Colors.LightGray);
            ErrorMessage = "Аварийное высокое значение";
            break;
          case 4:
            gridL1.Background = new SolidColorBrush(Colors.Red);
            gridL2.Background = new SolidColorBrush(Colors.Green);
            gridL3.Background = new SolidColorBrush(Colors.Yellow);
            gridL4.Background = new SolidColorBrush(Colors.Red);
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
