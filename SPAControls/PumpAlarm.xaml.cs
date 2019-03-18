using Service;
using System.Windows.Controls;

namespace SPAControls {
  public partial class PumpAlarm : UserControl {
    public PumpAlarm() {
      InitializeComponent();
    }

    public void StartUpdate() {
      Fan.OnChangeValue += VA_OnChangeValue;
      Alarm.OnChangeValue += VB_OnChangeValue;
      G20.OnChangeValue += G20_OnChangeValue;
      G50.OnChangeValue += G50_OnChangeValue;
    }

    private void VA_OnChangeValue(Tag sender) => elemFan.Value = (int)sender.Value;
    private void VB_OnChangeValue(Tag sender) => elemAlarm.Value = (int)sender.Value;
    private void G20_OnChangeValue(Tag sender) => elemG20.Value = (int)sender.Value;
    private void G50_OnChangeValue(Tag sender) => elemG50.Value = (int)sender.Value;

    public void StopUpdate() {
      Fan.OnChangeValue -= VA_OnChangeValue;
      Alarm.OnChangeValue -= VB_OnChangeValue;
      G20.OnChangeValue -= G20_OnChangeValue;
      G50.OnChangeValue -= G50_OnChangeValue;
    }

    public Tag Fan { get; set; } = new Tag();
    public Tag Alarm { get; set; } = new Tag();
    public Tag G20 { get; set; } = new Tag();
    public Tag G50 { get; set; } = new Tag();
}
}
