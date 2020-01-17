using Service;
using System;
using System.Windows.Controls;

namespace SPAControls {
  public partial class ValvesList : UserControl {

    public delegate void ErrorTag(EventLog log);
    public event ErrorTag OnErrorTag;

    public ValvesList() {
      InitializeComponent();
      valve1.OnErrorTag += Valve1_OnErrorTag;
      valve2.OnErrorTag += Valve1_OnErrorTag;
      valve3.OnErrorTag += Valve1_OnErrorTag;
      valve4.OnErrorTag += Valve1_OnErrorTag;
      valve5.OnErrorTag += Valve1_OnErrorTag;
      valve6.OnErrorTag += Valve1_OnErrorTag;
      valve7.OnErrorTag += Valve1_OnErrorTag;
      valve8.OnErrorTag += Valve1_OnErrorTag;
      valve9.OnErrorTag += Valve1_OnErrorTag;
      valve10.OnErrorTag += Valve1_OnErrorTag;
    }

    private void Valve1_OnErrorTag(string title, string errorMessage) {
      if (errorMessage == "Сработала предохранительная муфта") {
        OnErrorTag?.Invoke(new EventLog {
          Source = title,
          Message = errorMessage,
          EventLogType = EventLogType.Авария,
          Brush = EventLog.GetBrush(EventLogType.Авария),
          DateTime = DateTime.Now
        });
      } else {
        OnErrorTag?.Invoke(new EventLog {
          Source = title,
          Message = errorMessage,
          EventLogType = EventLogType.ИзменениеСостояния,
          Brush = EventLog.GetBrush(EventLogType.ИзменениеСостояния),
          DateTime = DateTime.Now
        });
      }
    }

    public void StartUpdate() {
      Valve1.OnChangeValue += Valve1_OnChangeValue;
      Valve2.OnChangeValue += Valve2_OnChangeValue;
      Valve3.OnChangeValue += Valve3_OnChangeValue;
      Valve4.OnChangeValue += Valve4_OnChangeValue;
      Valve5.OnChangeValue += Valve5_OnChangeValue;
      Valve6.OnChangeValue += Valve6_OnChangeValue;
      Valve7.OnChangeValue += Valve7_OnChangeValue;
      Valve8.OnChangeValue += Valve8_OnChangeValue;
      Valve9.OnChangeValue += Valve9_OnChangeValue;
      Valve10.OnChangeValue += Valve10_OnChangeValue;
    }

    private void Valve1_OnChangeValue(Tag sender) => valve1.Value = (int)sender.Value;
    private void Valve2_OnChangeValue(Tag sender) => valve2.Value = (int)sender.Value;
    private void Valve3_OnChangeValue(Tag sender) => valve3.Value = (int)sender.Value;
    private void Valve4_OnChangeValue(Tag sender) => valve4.Value = (int)sender.Value;
    private void Valve5_OnChangeValue(Tag sender) => valve5.Value = (int)sender.Value;
    private void Valve6_OnChangeValue(Tag sender) => valve6.Value = (int)sender.Value;
    private void Valve7_OnChangeValue(Tag sender) => valve7.Value = (int)sender.Value;
    private void Valve8_OnChangeValue(Tag sender) => valve8.Value = (int)sender.Value;
    private void Valve9_OnChangeValue(Tag sender) => valve9.Value = (int)sender.Value;
    private void Valve10_OnChangeValue(Tag sender) => valve10.Value = (int)sender.Value;


    public Tag Valve1 { get; set; } = new Tag();
    public Tag Valve2 { get; set; } = new Tag();
    public Tag Valve3 { get; set; } = new Tag();
    public Tag Valve4 { get; set; } = new Tag();
    public Tag Valve5 { get; set; } = new Tag();
    public Tag Valve6 { get; set; } = new Tag();
    public Tag Valve7 { get; set; } = new Tag();
    public Tag Valve8 { get; set; } = new Tag();
    public Tag Valve9 { get; set; } = new Tag();
    public Tag Valve10 { get; set; } = new Tag();
  } 
}
