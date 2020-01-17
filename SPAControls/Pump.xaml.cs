using Service;
using System.Windows.Controls;
using System;

namespace SPAControls {
  public partial class Pump : UserControl {
    public delegate void AllowPump(string pumpTitle, float value);
    public event AllowPump OnAllowPump;

    public Pump() {
      InitializeComponent();
      this.DataContext = this;
      PumpAllow.Value = 1;
      elemT1p.OnErrorTag += ElemT1p_OnErrorTag;
      elemV1p.OnErrorTag += ElemV1p_OnErrorTag;
      elemT2p.OnErrorTag += ElemT2p_OnErrorTag;
      elemV2p.OnErrorTag += ElemV2p_OnErrorTag;
      elemT1m.OnErrorTag += ElemT1m_OnErrorTag;
      elemV1m.OnErrorTag += ElemV1m_OnErrorTag;
      elemT2m.OnErrorTag += ElemT2m_OnErrorTag;
      elemV2m.OnErrorTag += ElemV2m_OnErrorTag;
    }

    public delegate void ErrorTag(EventLog log);
    public event ErrorTag OnErrorTag;

    private void ElemV2m_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = Title+".Вибрация 2 мотора" ,
        Message = errorMessage,
        EventLogType = EventLogType.Авария,
        Brush = EventLog.GetBrush(EventLogType.Авария),
        DateTime = DateTime.Now
      });
    }

    private void ElemT2m_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = Title + ".Температура 2 мотора",
        Message = errorMessage,
        EventLogType = EventLogType.Авария,
        Brush = EventLog.GetBrush(EventLogType.Авария),
        DateTime = DateTime.Now
      });
    }

    private void ElemV1m_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = Title + ".Вибрация 1 мотора",
        Message = errorMessage,
        EventLogType = EventLogType.Авария,
        Brush = EventLog.GetBrush(EventLogType.Авария),
        DateTime = DateTime.Now
      });
    }

    private void ElemT1m_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = Title + ".Температура 1 мотора",
        Message = errorMessage,
        EventLogType = EventLogType.Авария,
        Brush = EventLog.GetBrush(EventLogType.Авария),
        DateTime = DateTime.Now
      });
    }

    private void ElemV2p_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = Title + ".Вибрация 2 насоса",
        Message = errorMessage,
        EventLogType = EventLogType.Авария,
        Brush = EventLog.GetBrush(EventLogType.Авария),
        DateTime = DateTime.Now
      });
    }

    private void ElemT2p_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = Title + ".Температура 2 насоса",
        Message = errorMessage,
        EventLogType = EventLogType.Авария,
        Brush = EventLog.GetBrush(EventLogType.Авария),
        DateTime = DateTime.Now
      });
    }

    private void ElemV1p_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = Title + ".Вибрация 1 насоса",
        Message = errorMessage,
        EventLogType = EventLogType.Авария,
        Brush = EventLog.GetBrush(EventLogType.Авария),
        DateTime = DateTime.Now
      });
    }

    private void ElemT1p_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = Title + ".Температура 1 насоса",
        Message = errorMessage,
        EventLogType = EventLogType.Авария,
        Brush = EventLog.GetBrush(EventLogType.Авария),
        DateTime = DateTime.Now
      });
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
      PumpLowL1.OnChangeValue += PumpLowL1_OnChangeValue;
      PumpHighL1.OnChangeValue += PumpHighL1_OnChangeValue;
      PumpLowL2.OnChangeValue += PumpLowL2_OnChangeValue;
      PumpHighL2.OnChangeValue += PumpHighL2_OnChangeValue;
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
      PumpLowL1.OnChangeValue -= PumpLowL1_OnChangeValue;
      PumpHighL1.OnChangeValue -= PumpHighL1_OnChangeValue;
      PumpLowL2.OnChangeValue -= PumpLowL2_OnChangeValue;
      PumpHighL2.OnChangeValue -= PumpHighL2_OnChangeValue;
    }

    private void PumpRun_OnChangeValue(Tag sender) => elemRun.Value = (int)sender.Value;
    private void PumpPower_OnChangeValue(Tag sender) => elemPower.Value = (int)sender.Value;
    private void PumpAllow_OnChangeValue(Tag sender) => elemAllow.Value = (int)sender.Value;
    private void PumpMaterial_OnChangeValue(Tag sender) => elemMaterial.Value = (int)sender.Value;
    //private void PumpHeat_OnChangeValue(Tag sender) => elemHeat.Value = (int)sender.Value;

    private void PumpLowL1_OnChangeValue(Tag sender) {
      pumpLevel1.Value = PumpLowL1.Value == 1 ? 0 : (PumpHighL1.Value == 1 ? 2 : 1);
    }
    private void PumpHighL1_OnChangeValue(Tag sender) {
      pumpLevel1.Value = PumpLowL1.Value == 1 ? 0 : (PumpHighL1.Value == 1 ? 2 : 1);
    }
    private void PumpLowL2_OnChangeValue(Tag sender) {
      pumpLevel2.Value = PumpLowL2.Value == 1 ? 0 : (PumpHighL2.Value == 1 ? 2 : 1);
    }
    private void PumpHighL2_OnChangeValue(Tag sender) {
      pumpLevel2.Value = PumpLowL2.Value == 1 ? 0 : (PumpHighL2.Value == 1 ? 2 : 1);
    }

    private void T1p_OnChangeValue(Tag sender) {
      elemT1p.Max = (float)(sender.Set + sender.Hysteresis);
      elemT1p.Min = (float)(sender.Set - sender.Hysteresis);
      elemT1p.Value = sender.Value;
    }
    private void V1p_OnChangeValue(Tag sender) {
      elemV1p.Max = (float)(sender.Set + sender.Hysteresis);
      elemV1p.Min = float.MinValue;//(float)(sender.Set - sender.Hysteresis);
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

    private void AllowPump_Click(object sender, System.Windows.RoutedEventArgs e) {
      Button btn = sender as Button;
      btn.Content = PumpAllow.Value == 1 ? "Разрешить пуск" : "Запретить пуск";
      PumpAllow.Value = PumpAllow.Value == 1 ? 0 : 1;
      OnAllowPump?.Invoke(Title, PumpAllow.Value);
    }


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