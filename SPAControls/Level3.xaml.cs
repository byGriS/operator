using System.Windows.Controls;
using System.Windows.Media;

namespace SPAControls {
  public partial class Level3 : UserControl {
    public Level3() {
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
            break;
          case 1:
            gridL2.Background = new SolidColorBrush(Colors.Green);
            gridL1.Background = new SolidColorBrush(Colors.LightGray);
            gridL3.Background = new SolidColorBrush(Colors.LightGray);
            break;
          case 2:
            gridL3.Background = new SolidColorBrush(Colors.Red);
            gridL2.Background = new SolidColorBrush(Colors.LightGray);
            gridL1.Background = new SolidColorBrush(Colors.LightGray);
            break;
        }
      }
    }
  }
}
