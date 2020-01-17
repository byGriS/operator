using Service;
using System;
using System.Windows.Controls;

namespace SPAControls {
  public partial class PumpPower : UserControl {
    public PumpPower() {
      InitializeComponent();
      elemVA.OnErrorTag += ElemVA_OnErrorTag;
      elemVB.OnErrorTag += ElemVB_OnErrorTag;
      elemVC.OnErrorTag += ElemVC_OnErrorTag;
      elemCA.OnErrorTag += ElemCA_OnErrorTag;
      elemCB.OnErrorTag += ElemCB_OnErrorTag;
      elemCC.OnErrorTag += ElemCC_OnErrorTag;
      elemPA.OnErrorTag += ElemPA_OnErrorTag;
    }

    public delegate void ErrorTag(EventLog log);
    public event ErrorTag OnErrorTag;

    private void ElemPA_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = "Электросеть насосной.Частота сети",
        Message = errorMessage,
        EventLogType = EventLogType.Внимание,
        Brush = EventLog.GetBrush(EventLogType.Внимание),
        DateTime = DateTime.Now
      });
    }

    private void ElemCC_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = "Электросеть насосной.Ток фазы C",
        Message = errorMessage,
        EventLogType = EventLogType.Внимание,
        Brush = EventLog.GetBrush(EventLogType.Внимание),
        DateTime = DateTime.Now
      });
    }

    private void ElemCB_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = "Электросеть насосной.Ток фазы B",
        Message = errorMessage,
        EventLogType = EventLogType.Внимание,
        Brush = EventLog.GetBrush(EventLogType.Внимание),
        DateTime = DateTime.Now
      });
    }

    private void ElemCA_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = "Электросеть насосной.Ток фазы A",
        Message = errorMessage,
        EventLogType = EventLogType.Внимание,
        Brush = EventLog.GetBrush(EventLogType.Внимание),
        DateTime = DateTime.Now
      });
    }

    private void ElemVC_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = "Электросеть насосной.Напряжение фазы C",
        Message = errorMessage,
        EventLogType = EventLogType.Внимание,
        Brush = EventLog.GetBrush(EventLogType.Внимание),
        DateTime = DateTime.Now
      });
    }

    private void ElemVB_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = "Электросеть насосной.Напряжение фазы B",
        Message = errorMessage,
        EventLogType = EventLogType.Внимание,
        Brush = EventLog.GetBrush(EventLogType.Внимание),
        DateTime = DateTime.Now
      });
    }

    private void ElemVA_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = "Электросеть насосной.Напряжение фазы A",
        Message = errorMessage,
        EventLogType = EventLogType.Внимание,
        Brush = EventLog.GetBrush(EventLogType.Внимание),
        DateTime = DateTime.Now
      });
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
