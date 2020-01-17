using Service;
using System;
using System.Windows.Controls;

namespace SPAControls {
  public partial class GasField : UserControl {

    public delegate void ErrorTag(EventLog log);
    public event ErrorTag OnErrorTag;

    public GasField() {
      InitializeComponent();
      this.DataContext = this;
    }
    public void StartUpdate() {
      Channel1.OnChangeValue += Channel1_OnChangeValue;
      Channel2.OnChangeValue += Channel2_OnChangeValue;
      Channel3.OnChangeValue += Channel3_OnChangeValue;
      Channel4.OnChangeValue += Channel4_OnChangeValue;
      Channel5.OnChangeValue += Channel5_OnChangeValue;
      Channel6.OnChangeValue += Channel6_OnChangeValue;
      Channel7.OnChangeValue += Channel7_OnChangeValue;
      Channel8.OnChangeValue += Channel8_OnChangeValue;
      Channel9.OnChangeValue += Channel9_OnChangeValue;
      Channel10.OnChangeValue += Channel10_OnChangeValue;
      Channel11.OnChangeValue += Channel11_OnChangeValue;
      Channel12.OnChangeValue += Channel12_OnChangeValue;
      Channel13.OnChangeValue += Channel13_OnChangeValue;
      Channel14.OnChangeValue += Channel14_OnChangeValue;
      Channel15.OnChangeValue += Channel15_OnChangeValue;
      Channel16.OnChangeValue += Channel16_OnChangeValue;
      Channel17.OnChangeValue += Channel17_OnChangeValue;
      Channel18.OnChangeValue += Channel18_OnChangeValue;
      Channel19.OnChangeValue += Channel19_OnChangeValue;
      Channel20.OnChangeValue += Channel20_OnChangeValue;
      Channel21.OnChangeValue += Channel21_OnChangeValue;
      Channel22.OnChangeValue += Channel22_OnChangeValue;
      Channel23.OnChangeValue += Channel23_OnChangeValue;
      Channel24.OnChangeValue += Channel24_OnChangeValue;
      Channel25.OnChangeValue += Channel25_OnChangeValue;
      Channel26.OnChangeValue += Channel26_OnChangeValue;
      Channel27.OnChangeValue += Channel27_OnChangeValue;
      Channel28.OnChangeValue += Channel28_OnChangeValue;
      Channel29.OnChangeValue += Channel29_OnChangeValue;
      Channel30.OnChangeValue += Channel30_OnChangeValue;
      Channel31.OnChangeValue += Channel31_OnChangeValue;
      Channel32.OnChangeValue += Channel32_OnChangeValue;
      Channel33.OnChangeValue += Channel33_OnChangeValue;
      Channel34.OnChangeValue += Channel34_OnChangeValue;
      Channel35.OnChangeValue += Channel35_OnChangeValue;
      Channel36.OnChangeValue += Channel36_OnChangeValue;
      Channel37.OnChangeValue += Channel37_OnChangeValue;
      Channel38.OnChangeValue += Channel38_OnChangeValue;
      Q1.OnErrorTag += Q1_OnErrorTag;
      Q2.OnErrorTag += Q2_OnErrorTag;
      Q3.OnErrorTag += Q3_OnErrorTag;
      Q4.OnErrorTag += Q4_OnErrorTag;
      Q5.OnErrorTag += Q5_OnErrorTag;
      Q6.OnErrorTag += Q6_OnErrorTag;
      Q7.OnErrorTag += Q7_OnErrorTag;
      Q8.OnErrorTag += Q8_OnErrorTag;
      Q9.OnErrorTag += Q9_OnErrorTag;
      Q10.OnErrorTag += Q10_OnErrorTag;
      Q11.OnErrorTag += Q11_OnErrorTag;
      Q12.OnErrorTag += Q12_OnErrorTag;
      Q13.OnErrorTag += Q13_OnErrorTag;
      Q14.OnErrorTag += Q14_OnErrorTag;
      Q15.OnErrorTag += Q15_OnErrorTag;
      Q16.OnErrorTag += Q16_OnErrorTag;
      Q17.OnErrorTag += Q17_OnErrorTag;
      Q18.OnErrorTag += Q18_OnErrorTag;
      Q19.OnErrorTag += Q19_OnErrorTag;
      Q20.OnErrorTag += Q20_OnErrorTag;
      Q21.OnErrorTag += Q21_OnErrorTag;
      Q22.OnErrorTag += Q22_OnErrorTag;
      Q23.OnErrorTag += Q23_OnErrorTag;
      Q24.OnErrorTag += Q24_OnErrorTag;
      Q25.OnErrorTag += Q25_OnErrorTag;
      Q26.OnErrorTag += Q26_OnErrorTag;
      Q27.OnErrorTag += Q27_OnErrorTag;
      Q28.OnErrorTag += Q28_OnErrorTag;
      Q29.OnErrorTag += Q29_OnErrorTag;
      Q30.OnErrorTag += Q30_OnErrorTag;
      Q31.OnErrorTag += Q31_OnErrorTag;
      Q32.OnErrorTag += Q32_OnErrorTag;
      Q33.OnErrorTag += Q33_OnErrorTag;
      Q34.OnErrorTag += Q34_OnErrorTag;
      Q35.OnErrorTag += Q35_OnErrorTag;
      Q36.OnErrorTag += Q36_OnErrorTag;
      Q37.OnErrorTag += Q37_OnErrorTag;
      Q38.OnErrorTag += Q38_OnErrorTag;
    }

    private void Q1_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp1.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q2_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp2.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q3_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp3.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q4_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp4.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q5_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp5.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q6_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp6.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q7_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp7.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q8_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp8.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q9_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp9.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q10_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp10.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q11_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp11.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q12_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp12.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q13_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp13.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q14_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp14.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q15_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp15.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q16_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp16.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q17_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp17.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q18_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp18.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q19_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp19.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q20_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp20.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q21_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp21.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q22_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp22.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q23_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp23.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q24_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp24.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q25_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp25.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q26_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp26.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q27_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp27.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q28_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp28.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q29_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp29.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q30_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp30.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q31_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp31.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q32_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp32.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q33_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp33.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });

    }
    private void Q34_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp34.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q35_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp35.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q36_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp36.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q37_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp37.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }
    private void Q38_OnErrorTag(string errorMessage) {
      string[] data = errorMessage.Split('|');
      OnErrorTag?.Invoke(new EventLog {
        Source = "QEp38.Датчик загазованности",
        Message = data[1],
        EventLogType = (data[0] == "0") ? EventLogType.Внимание : ((data[0] == "1") ? EventLogType.Авария : EventLogType.Ошибка),
        Brush = (data[0] == "0") ? EventLog.GetBrush(EventLogType.Внимание) : ((data[0] == "1") ? EventLog.GetBrush(EventLogType.Авария) : EventLog.GetBrush(EventLogType.Ошибка)),
        DateTime = DateTime.Now
      });
    }

    private void Channel1_OnChangeValue(Tag sender) => Q1.Value = (int)sender.Value;
    private void Channel2_OnChangeValue(Tag sender) => Q2.Value = (int)sender.Value;
    private void Channel3_OnChangeValue(Tag sender) => Q3.Value = (int)sender.Value;
    private void Channel4_OnChangeValue(Tag sender) => Q4.Value = (int)sender.Value;
    private void Channel5_OnChangeValue(Tag sender) => Q5.Value = (int)sender.Value;
    private void Channel6_OnChangeValue(Tag sender) => Q6.Value = (int)sender.Value;
    private void Channel7_OnChangeValue(Tag sender) => Q7.Value = (int)sender.Value;
    private void Channel8_OnChangeValue(Tag sender) => Q8.Value = (int)sender.Value;
    private void Channel9_OnChangeValue(Tag sender) => Q9.Value = (int)sender.Value;
    private void Channel10_OnChangeValue(Tag sender) => Q10.Value = (int)sender.Value;
    private void Channel11_OnChangeValue(Tag sender) => Q11.Value = (int)sender.Value;
    private void Channel12_OnChangeValue(Tag sender) => Q12.Value = (int)sender.Value;
    private void Channel13_OnChangeValue(Tag sender) => Q13.Value = (int)sender.Value;
    private void Channel14_OnChangeValue(Tag sender) => Q14.Value = (int)sender.Value;
    private void Channel15_OnChangeValue(Tag sender) => Q15.Value = (int)sender.Value;
    private void Channel16_OnChangeValue(Tag sender) => Q16.Value = (int)sender.Value;
    private void Channel17_OnChangeValue(Tag sender) => Q17.Value = (int)sender.Value;
    private void Channel18_OnChangeValue(Tag sender) => Q18.Value = (int)sender.Value;
    private void Channel19_OnChangeValue(Tag sender) => Q19.Value = (int)sender.Value;
    private void Channel20_OnChangeValue(Tag sender) => Q20.Value = (int)sender.Value;
    private void Channel21_OnChangeValue(Tag sender) => Q21.Value = (int)sender.Value;
    private void Channel22_OnChangeValue(Tag sender) => Q22.Value = (int)sender.Value;
    private void Channel23_OnChangeValue(Tag sender) => Q23.Value = (int)sender.Value;
    private void Channel24_OnChangeValue(Tag sender) => Q24.Value = (int)sender.Value;
    private void Channel25_OnChangeValue(Tag sender) => Q25.Value = (int)sender.Value;
    private void Channel26_OnChangeValue(Tag sender) => Q26.Value = (int)sender.Value;
    private void Channel27_OnChangeValue(Tag sender) => Q27.Value = (int)sender.Value;
    private void Channel28_OnChangeValue(Tag sender) => Q28.Value = (int)sender.Value;
    private void Channel29_OnChangeValue(Tag sender) => Q29.Value = (int)sender.Value;
    private void Channel30_OnChangeValue(Tag sender) => Q30.Value = (int)sender.Value;
    private void Channel31_OnChangeValue(Tag sender) => Q31.Value = (int)sender.Value;
    private void Channel32_OnChangeValue(Tag sender) => Q32.Value = (int)sender.Value;
    private void Channel33_OnChangeValue(Tag sender) => Q33.Value = (int)sender.Value;
    private void Channel34_OnChangeValue(Tag sender) => Q34.Value = (int)sender.Value;
    private void Channel35_OnChangeValue(Tag sender) => Q35.Value = (int)sender.Value;
    private void Channel36_OnChangeValue(Tag sender) => Q36.Value = (int)sender.Value;
    private void Channel37_OnChangeValue(Tag sender) => Q37.Value = (int)sender.Value;
    private void Channel38_OnChangeValue(Tag sender) => Q38.Value = (int)sender.Value;

    public void StopUpdate() {
      
    }

    public Tag Channel1 { get; set; } = new Tag();
    public Tag Channel2 { get; set; } = new Tag();
    public Tag Channel3 { get; set; } = new Tag();
    public Tag Channel4 { get; set; } = new Tag();
    public Tag Channel5 { get; set; } = new Tag();
    public Tag Channel6 { get; set; } = new Tag();
    public Tag Channel7 { get; set; } = new Tag();
    public Tag Channel8 { get; set; } = new Tag();
    public Tag Channel9 { get; set; } = new Tag();
    public Tag Channel10 { get; set; } = new Tag();
    public Tag Channel11 { get; set; } = new Tag();
    public Tag Channel12 { get; set; } = new Tag();
    public Tag Channel13 { get; set; } = new Tag();
    public Tag Channel14 { get; set; } = new Tag();
    public Tag Channel15 { get; set; } = new Tag();
    public Tag Channel16 { get; set; } = new Tag();
    public Tag Channel17 { get; set; } = new Tag();
    public Tag Channel18 { get; set; } = new Tag();
    public Tag Channel19 { get; set; } = new Tag();
    public Tag Channel20 { get; set; } = new Tag();
    public Tag Channel21 { get; set; } = new Tag();
    public Tag Channel22 { get; set; } = new Tag();
    public Tag Channel23 { get; set; } = new Tag();
    public Tag Channel24 { get; set; } = new Tag();
    public Tag Channel25 { get; set; } = new Tag();
    public Tag Channel26 { get; set; } = new Tag();
    public Tag Channel27 { get; set; } = new Tag();
    public Tag Channel28 { get; set; } = new Tag();
    public Tag Channel29 { get; set; } = new Tag();
    public Tag Channel30 { get; set; } = new Tag();
    public Tag Channel31 { get; set; } = new Tag();
    public Tag Channel32 { get; set; } = new Tag();
    public Tag Channel33 { get; set; } = new Tag();
    public Tag Channel34 { get; set; } = new Tag();
    public Tag Channel35 { get; set; } = new Tag();
    public Tag Channel36 { get; set; } = new Tag();
    public Tag Channel37 { get; set; } = new Tag();
    public Tag Channel38 { get; set; } = new Tag();
  }
}
