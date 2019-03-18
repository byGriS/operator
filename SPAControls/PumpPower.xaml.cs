using Service;
using System.Windows.Controls;

namespace SPAControls {
  public partial class PumpPower : UserControl {
    public PumpPower() {
      InitializeComponent();
    }

    public void StartUpdate() {
      VA.OnChangeValue += VA_OnChangeValue;
      VB.OnChangeValue += VB_OnChangeValue;
      VC.OnChangeValue += VC_OnChangeValue;
      CA.OnChangeValue += CA_OnChangeValue;
      CB.OnChangeValue += CB_OnChangeValue;
      CC.OnChangeValue += CC_OnChangeValue;
      PA.OnChangeValue += PA_OnChangeValue;
      PB.OnChangeValue += PB_OnChangeValue;
      PC.OnChangeValue += PC_OnChangeValue;
    }

    private void VA_OnChangeValue(Tag sender) => elemVA.Value = (int)sender.Value;
    private void VB_OnChangeValue(Tag sender) => elemVB.Value = (int)sender.Value;
    private void VC_OnChangeValue(Tag sender) => elemVC.Value = (int)sender.Value;
    private void CA_OnChangeValue(Tag sender) => elemCA.Value = (int)sender.Value;
    private void CB_OnChangeValue(Tag sender) => elemCB.Value = (int)sender.Value;
    private void CC_OnChangeValue(Tag sender) => elemCC.Value = (int)sender.Value;
    private void PA_OnChangeValue(Tag sender) => elemPA.Value = (int)sender.Value;
    private void PB_OnChangeValue(Tag sender) => elemPB.Value = (int)sender.Value;
    private void PC_OnChangeValue(Tag sender) => elemPC.Value = (int)sender.Value;

    public void StopUpdate() {
      VA.OnChangeValue -= VA_OnChangeValue;
      VB.OnChangeValue -= VB_OnChangeValue;
      VC.OnChangeValue -= VC_OnChangeValue;
      CA.OnChangeValue -= CA_OnChangeValue;
      CB.OnChangeValue -= CB_OnChangeValue;
      CC.OnChangeValue -= CC_OnChangeValue;
      PA.OnChangeValue -= PA_OnChangeValue;
      PB.OnChangeValue -= PB_OnChangeValue;
      PC.OnChangeValue -= PC_OnChangeValue;
    }

    public Tag VA { get; set; } = new Tag();
    public Tag VB { get; set; } = new Tag();
    public Tag VC { get; set; } = new Tag();
    public Tag CA { get; set; } = new Tag();
    public Tag CB { get; set; } = new Tag();
    public Tag CC { get; set; } = new Tag();
    public Tag PA { get; set; } = new Tag();
    public Tag PB { get; set; } = new Tag();
    public Tag PC { get; set; } = new Tag();
  }
}
