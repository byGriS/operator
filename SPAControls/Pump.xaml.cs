using Service;
using System.Windows.Controls;

namespace SPAControls {
  public partial class Pump : UserControl {
    public delegate void AllowPump(string pumpTitle, float value);
    public event AllowPump OnAllowPump;

    public Pump() {
      InitializeComponent();
      this.DataContext = this;
      PumpAllow.Value = 1;
    }

    public void StartUpdate() {
      T1p.OnChangeValue += T1p_OnChangeValue;
      V1p.OnChangeValue += V1p_OnChangeValue;
      T2p.OnChangeValue += T2p_OnChangeValue;
      V2p.OnChangeValue += V2p_OnChangeValue;
      T1m.OnChangeValue += T1m_OnChangeValue;
      V1m.OnChangeValue += V1n_OnChangeValue;
      T2m.OnChangeValue += T2m_OnChangeValue;
      V2m.OnChangeValue += V2m_OnChangeValue;
      PumpRun.OnChangeValue += PumpRun_OnChangeValue;
      PumpPower.OnChangeValue += PumpPower_OnChangeValue;
      PumpAllow.OnChangeValue += PumpAllow_OnChangeValue;
      PumpMaterial.OnChangeValue += PumpMaterial_OnChangeValue;
     // PumpHeat.OnChangeValue += PumpHeat_OnChangeValue;
      PumpLowL.OnChangeValue += PumpLowL_OnChangeValue;
      PumpHighL.OnChangeValue += PumpHighL_OnChangeValue;
    }
    public void StopUpdate() {
      T1p.OnChangeValue -= T1p_OnChangeValue;
      V1p.OnChangeValue -= V1p_OnChangeValue;
      T2p.OnChangeValue -= T2p_OnChangeValue;
      V2p.OnChangeValue -= V2p_OnChangeValue;
      T1m.OnChangeValue -= T1m_OnChangeValue;
      V1m.OnChangeValue -= V1n_OnChangeValue;
      T2m.OnChangeValue -= T2m_OnChangeValue;
      V2m.OnChangeValue -= V2m_OnChangeValue;
      PumpRun.OnChangeValue -= PumpRun_OnChangeValue;
      PumpPower.OnChangeValue -= PumpPower_OnChangeValue;
      PumpAllow.OnChangeValue -= PumpAllow_OnChangeValue;
      PumpMaterial.OnChangeValue -= PumpMaterial_OnChangeValue;
      //PumpHeat.OnChangeValue -= PumpHeat_OnChangeValue;
      PumpLowL.OnChangeValue -= PumpLowL_OnChangeValue;
      PumpHighL.OnChangeValue -= PumpHighL_OnChangeValue;
    }

    private void PumpRun_OnChangeValue(Tag sender) => elemRun.Value = (int)sender.Value;
    private void PumpPower_OnChangeValue(Tag sender) => elemPower.Value = (int)sender.Value;
    private void PumpAllow_OnChangeValue(Tag sender) => elemAllow.Value = (int)sender.Value;
    private void PumpMaterial_OnChangeValue(Tag sender) => elemMaterial.Value = (int)sender.Value;
    //private void PumpHeat_OnChangeValue(Tag sender) => elemHeat.Value = (int)sender.Value;

    private void PumpLowL_OnChangeValue(Tag sender) {
      pumpLevel.Value = PumpLowL.Value == 1 ? 0 : (PumpHighL.Value == 1 ? 2 : 1);
    }
    private void PumpHighL_OnChangeValue(Tag sender) {
      pumpLevel.Value = PumpLowL.Value == 1 ? 0 : (PumpHighL.Value == 1 ? 2 : 1);
    }

    private void T1p_OnChangeValue(Tag sender) {
      elemT1p.Value = sender.Value;
      elemT1p.Max = (float)(sender.Set + sender.Hysteresis / 2.0);
      elemT1p.Min = (float)(sender.Set - sender.Hysteresis / 2.0);
    }
    private void V1p_OnChangeValue(Tag sender) {
      elemV1p.Value = sender.Value;
      elemT1p.Max = (float)(sender.Set + sender.Hysteresis / 2.0);
      elemT1p.Min = (float)(sender.Set - sender.Hysteresis / 2.0);
    }
    private void T2p_OnChangeValue(Tag sender) {
      elemT2p.Value = sender.Value;
      elemT2p.Max = (float)(sender.Set + sender.Hysteresis / 2.0);
      elemT2p.Min = (float)(sender.Set - sender.Hysteresis / 2.0);
    }
    private void V2p_OnChangeValue(Tag sender) {
      elemV2p.Value = sender.Value;
      elemV2p.Max = (float)(sender.Set + sender.Hysteresis / 2.0);
      elemV2p.Min = (float)(sender.Set - sender.Hysteresis / 2.0);
    }
    private void T1m_OnChangeValue(Tag sender) {
      elemT1m.Value = sender.Value;
      elemT1m.Max = (float)(sender.Set + sender.Hysteresis / 2.0);
      elemT1m.Min = (float)(sender.Set - sender.Hysteresis / 2.0);
    }
    private void V1n_OnChangeValue(Tag sender) {
      elemV1m.Value = sender.Value;
      elemV1m.Max = (float)(sender.Set + sender.Hysteresis / 2.0);
      elemV1m.Min = (float)(sender.Set - sender.Hysteresis / 2.0);
    }
    private void T2m_OnChangeValue(Tag sender) {
      elemT2m.Value = sender.Value;
      elemT2m.Max = (float)(sender.Set + sender.Hysteresis / 2.0);
      elemT2m.Min = (float)(sender.Set - sender.Hysteresis / 2.0);
    }
    private void V2m_OnChangeValue(Tag sender) {
      elemV2m.Value = sender.Value;
      elemV2m.Max = (float)(sender.Set + sender.Hysteresis / 2.0);
      elemV2m.Min = (float)(sender.Set - sender.Hysteresis / 2.0);
    }

    public string Title { get; set; }
    public Tag T1p { get; set; } = new Tag();
    public Tag V1p { get; set; } = new Tag();
    public Tag T2p { get; set; } = new Tag();
    public Tag V2p { get; set; } = new Tag();
    public Tag T1m { get; set; } = new Tag();
    public Tag V1m { get; set; } = new Tag();
    public Tag T2m { get; set; } = new Tag();
    public Tag V2m { get; set; } = new Tag();

    private void AllowPump_Click(object sender, System.Windows.RoutedEventArgs e) {
      Button btn = sender as Button;
      btn.Content = PumpAllow.Value == 1 ? "Разрешить доступ" : "Запретить доступ";
      PumpAllow.Value = PumpAllow.Value == 1 ? 0 : 1;
      OnAllowPump?.Invoke(Title, PumpAllow.Value);
    }


    public Tag PumpRun { get; set; } = new Tag();
    public Tag PumpPower { get; set; } = new Tag();
    public Tag PumpAllow { get; set; } = new Tag();
    public Tag PumpMaterial { get; set; } = new Tag();
    public Tag PumpHeat { get; set; } = new Tag();
    public Tag PumpLowL { get; set; } = new Tag();
    public Tag PumpHighL { get; set; } = new Tag();
  }
}