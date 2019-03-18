using System.Windows.Controls;
using System.Windows.Media;

namespace SPAControls {
  public partial class ValveV : UserControl {
    public ValveV() {
      InitializeComponent();
    }
    private int value = 1;
    public int Value {
      get { return this.value; }
      set {
        this.value = value;
        switch (value) {
          case 0:
            gridL1.Background = new SolidColorBrush(Colors.Red);
            gridL2.Background = new SolidColorBrush(Colors.LightGray);
            gridL3.Background = new SolidColorBrush(Colors.LightGray);
            gridL4.Background = new SolidColorBrush(Colors.LightGray);
            break;
          case 1:
            gridL2.Background = new SolidColorBrush(Colors.Blue);
            gridL1.Background = new SolidColorBrush(Colors.LightGray);
            gridL3.Background = new SolidColorBrush(Colors.LightGray);
            gridL4.Background = new SolidColorBrush(Colors.LightGray);
            break;
          case 2:
            gridL3.Background = new SolidColorBrush(Colors.Green);
            gridL2.Background = new SolidColorBrush(Colors.LightGray);
            gridL1.Background = new SolidColorBrush(Colors.LightGray);
            gridL4.Background = new SolidColorBrush(Colors.LightGray);
            break;
          case 3:
            gridL4.Background = new SolidColorBrush(Colors.Yellow);
            gridL2.Background = new SolidColorBrush(Colors.LightGray);
            gridL3.Background = new SolidColorBrush(Colors.LightGray);
            gridL1.Background = new SolidColorBrush(Colors.LightGray);
            break;
        }
      }
    }
  }
}