using Service;
using System;
using System.Windows.Controls;

namespace SPAControls {
  public partial class TanksAlarm : UserControl {
    public TanksAlarm() {
      InitializeComponent();
      elemG20.OnErrorTag += ElemG20_OnErrorTag;
      elemG50.OnErrorTag += ElemG50_OnErrorTag;
    }

    private void ElemG50_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = "РВС",
        Message = "Неисправность",
        EventLogType = EventLogType.Авария,
        Brush = EventLog.GetBrush(EventLogType.Авария),
        DateTime = DateTime.Now
      });
    }

    private void ElemG20_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = "",
        Message = "Загазованность",
        EventLogType = EventLogType.Авария,
        Brush = EventLog.GetBrush(EventLogType.Авария),
        DateTime = DateTime.Now
      });
    }

    public delegate void ErrorTag(EventLog log);
    public event ErrorTag OnErrorTag;

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
