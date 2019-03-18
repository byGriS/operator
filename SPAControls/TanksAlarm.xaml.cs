using Service;
using System.Windows.Controls;

namespace SPAControls {
  public partial class TanksAlarm : UserControl {
    public TanksAlarm() {
      InitializeComponent();
    }

    public void StartUpdate() {
      VA.OnChangeValue += VA_OnChangeValue;
      VB.OnChangeValue += VB_OnChangeValue;
      G20.OnChangeValue += G20_OnChangeValue;
      G50.OnChangeValue += G50_OnChangeValue;
    }

    private void VA_OnChangeValue(Tag sender) => elemVA.Value = (int)sender.Value;
    private void VB_OnChangeValue(Tag sender) => elemVB.Value = (int)sender.Value;
    private void G20_OnChangeValue(Tag sender) => elemG20.Value = (int)sender.Value;
    private void G50_OnChangeValue(Tag sender) => elemG50.Value = (int)sender.Value;

    public void StopUpdate() {
      VA.OnChangeValue -= VA_OnChangeValue;
      VB.OnChangeValue -= VB_OnChangeValue;
      G20.OnChangeValue -= G20_OnChangeValue;
      G50.OnChangeValue -= G50_OnChangeValue;
    }

    public Tag VA { get; set; } = new Tag();
    public Tag VB { get; set; } = new Tag();
    public Tag G20 { get; set; } = new Tag();
    public Tag G50 { get; set; } = new Tag();
  }
}
