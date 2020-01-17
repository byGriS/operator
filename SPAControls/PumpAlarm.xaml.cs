using Service;
using System;
using System.Windows.Controls;

namespace SPAControls {
  public partial class PumpAlarm : UserControl {
    public PumpAlarm() {
      InitializeComponent();
      elemAlarm.OnErrorTag += ElemAlarm_OnErrorTag;
      elemG20.OnErrorTag += ElemG20_OnErrorTag;
      elemG50.OnErrorTag += ElemG50_OnErrorTag;
    }

    private void ElemG50_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = "Насосная",
        Message = "Неисправность ДВК",
        EventLogType = EventLogType.Внимание,
        Brush = EventLog.GetBrush(EventLogType.Внимание),
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

    private void ElemAlarm_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = "Насосная",
        Message = "Пожарная сигнализация",
        EventLogType = EventLogType.Авария,
        Brush = EventLog.GetBrush(EventLogType.Авария),
        DateTime = DateTime.Now
      });
    }

    public delegate void ErrorTag(EventLog log);
    public event ErrorTag OnErrorTag;

    public void StartUpdate() {
      Fan.OnChangeValue += VA_OnChangeValue;
      Alarm.OnChangeValue += VB_OnChangeValue;
      G20.OnChangeValue += G20_OnChangeValue;
      G50.OnChangeValue += G50_OnChangeValue;
    }

    private void VA_OnChangeValue(Tag sender) {
      if (elemFan.Value != (int)sender.Value) {
        OnErrorTag?.Invoke(new EventLog {
          Source = "Вентиляция",
          Message = ((int)sender.Value == 0) ? "Включена" : "Выключена",
          EventLogType = EventLogType.ИзменениеСостояния,
          Brush = EventLog.GetBrush(EventLogType.ИзменениеСостояния),
          DateTime = DateTime.Now
        });
      }
      elemFan.Value = (int)sender.Value;

    }
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
