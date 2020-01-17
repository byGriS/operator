using Service;
using System.Windows.Controls;

namespace SPAControls {
  public partial class PumpMini : UserControl {
    public PumpMini() {
      InitializeComponent();
      this.DataContext = this;
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
      //PumpHeat.OnChangeValue += PumpHeat_OnChangeValue;
      PumpLowL1.OnChangeValue += PumpLowL1_OnChangeValue;
      PumpHighL1.OnChangeValue += PumpHighL1_OnChangeValue;
      PumpLowL2.OnChangeValue += PumpLowL2_OnChangeValue;
      PumpHighL2.OnChangeValue += PumpHighL2_OnChangeValue;
    }

    private void PumpRun_OnChangeValue(Tag sender) => elemRun.Value = (int)sender.Value;
    private void PumpPower_OnChangeValue(Tag sender) => elemPower.Value = (int)sender.Value;
    private void PumpAllow_OnChangeValue(Tag sender) => elemAllow.Value = (int)sender.Value;
    private void PumpMaterial_OnChangeValue(Tag sender) => elemMaterial.Value = (int)sender.Value;
   // private void PumpHeat_OnChangeValue(Tag sender) => elemHeat.Value = (int)sender.Value;
    private void PumpLowL1_OnChangeValue(Tag sender) => elemLowL1.Value = (int)sender.Value;
    private void PumpHighL1_OnChangeValue(Tag sender) => elemHighL1.Value = (int)sender.Value;
    private void PumpLowL2_OnChangeValue(Tag sender) => elemLowL2.Value = (int)sender.Value;
    private void PumpHighL2_OnChangeValue(Tag sender) => elemHighL2.Value = (int)sender.Value;

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
      PumpLowL1.OnChangeValue -= PumpLowL1_OnChangeValue;
      PumpHighL1.OnChangeValue -= PumpHighL1_OnChangeValue;
      PumpLowL2.OnChangeValue -= PumpLowL2_OnChangeValue;
      PumpHighL2.OnChangeValue -= PumpHighL2_OnChangeValue;
    }

    private void T1p_OnChangeValue(Tag sender) {
      elemT1p.Max = (float)(sender.Set + sender.Hysteresis);
      elemT1p.Min = (float)(sender.Set - sender.Hysteresis);
      elemT1p.Value = sender.Value;
    }
    private void V1p_OnChangeValue(Tag sender) {
      elemV1p.Max = (float)(sender.Set + sender.Hysteresis);
      elemV1p.Min = float.MinValue; //(float)(sender.Set - sender.Hysteresis);
      elemV1p.Value = sender.Value;
    }
    private void T2p_OnChangeValue(Tag sender) {
      elemT2p.Max = (float)(sender.Set + sender.Hysteresis);
      elemT2p.Min = (float)(sender.Set - sender.Hysteresis);
      elemT2p.Value = sender.Value;
    }
    private void V2p_OnChangeValue(Tag sender) {
      elemV2p.Max = (float)(sender.Set + sender.Hysteresis);
      elemV2p.Min = float.MinValue; //(float)(sender.Set - sender.Hysteresis);
      elemV2p.Value = sender.Value;
    }
    private void T1m_OnChangeValue(Tag sender) {
      elemT1m.Max = (float)(sender.Set + sender.Hysteresis);
      elemT1m.Min = (float)(sender.Set - sender.Hysteresis);
      elemT1m.Value = sender.Value;
    }
    private void V1n_OnChangeValue(Tag sender) {
      elemV1m.Max = (float)(sender.Set + sender.Hysteresis);
      elemV1m.Min = float.MinValue; //(float)(sender.Set - sender.Hysteresis);
      elemV1m.Value = sender.Value;
    }
    private void T2m_OnChangeValue(Tag sender) {
      elemT2m.Max = (float)(sender.Set + sender.Hysteresis);
      elemT2m.Min = (float)(sender.Set - sender.Hysteresis);
      elemT2m.Value = sender.Value;
    }
    private void V2m_OnChangeValue(Tag sender) {
      elemV2m.Max = (float)(sender.Set + sender.Hysteresis);
      elemV2m.Min = float.MinValue; //(float)(sender.Set - sender.Hysteresis);
      elemV2m.Value = sender.Value;
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

    public Tag PumpRun { get; set; } = new Tag();
    public Tag PumpPower { get; set; } = new Tag();
    public Tag PumpAllow { get; set; } = new Tag();
    public Tag PumpMaterial { get; set; } = new Tag();
    public Tag PumpHeat { get; set; } = new Tag();
    public Tag PumpLowL1 { get; set; } = new Tag();
    public Tag PumpHighL1 { get; set; } = new Tag();
    public Tag PumpLowL2 { get; set; } = new Tag();
    public Tag PumpHighL2 { get; set; } = new Tag();
  }
}