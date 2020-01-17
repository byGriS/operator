using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SPAControls {
  public partial class PistonPump : UserControl {

    public delegate void ErrorTag(EventLog log);
    public event ErrorTag OnErrorTag;

    public PistonPump() {
      InitializeComponent();
      this.DataContext = this;
      pump1P.OnErrorTag += Pump1P_OnErrorTag;
      pump2P.OnErrorTag += Pump2P_OnErrorTag;
      pump5P.OnErrorTag += Pump5P_OnErrorTag;
    }

    private void Pump1P_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = "Насос1.Давление",
        Message = errorMessage,
        EventLogType = EventLogType.Авария,
        Brush = EventLog.GetBrush(EventLogType.Авария),
        DateTime = DateTime.Now
      });
    }

    private void Pump2P_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = "Насос2.Давление",
        Message = errorMessage,
        EventLogType = EventLogType.Авария,
        Brush = EventLog.GetBrush(EventLogType.Авария),
        DateTime = DateTime.Now
      });
    }

    private void Pump5P_OnErrorTag(string errorMessage) {
      OnErrorTag?.Invoke(new EventLog {
        Source = "Насос5.Давление",
        Message = errorMessage,
        EventLogType = EventLogType.Авария,
        Brush = EventLog.GetBrush(EventLogType.Авария),
        DateTime = DateTime.Now
      });
    }
    public void StartUpdate() {
      Pump1Press.OnChangeValue += Pump1Press_OnChangeValue;
      Pump2Press.OnChangeValue += Pump2Press_OnChangeValue;
      Pump5Press.OnChangeValue += Pump5Press_OnChangeValue;
      Pump1Run.OnChangeValue += Pump1Run_OnChangeValue;
      Pump2Run.OnChangeValue += Pump2Run_OnChangeValue;
      Pump5Run.OnChangeValue += Pump5Run_OnChangeValue;
    }
    
    private void Pump1Press_OnChangeValue(Tag sender) {
      pump1P.Max = (float)(sender.Set + sender.Hysteresis);
      pump1P.Min = (float)-100.0;//(float)(sender.Set - sender.Hysteresis);
      pump1P.Value = sender.Value;      
    }

    private void Pump2Press_OnChangeValue(Tag sender) {
      pump2P.Max = (float)(sender.Set + sender.Hysteresis);
      pump2P.Min = (float)-100.0;// (float)(sender.Set - sender.Hysteresis);
      pump2P.Value = sender.Value;
    }

    private void Pump5Press_OnChangeValue(Tag sender) {
      pump5P.Max = (float)(sender.Set + sender.Hysteresis);
      pump5P.Min = (float)-100.0;// (float)(sender.Set - sender.Hysteresis);
      pump5P.Value = sender.Value;
    }

    private void Pump1Run_OnChangeValue(Tag sender) {
      if (pump1Run.Value != (int)sender.Value) {
        OnErrorTag?.Invoke(new EventLog {
          Source = "Насос1",
          Message = ((int)sender.Value == 0) ? "Включен" : "Выключен",
          EventLogType = EventLogType.ИзменениеСостояния,
          Brush = EventLog.GetBrush(EventLogType.ИзменениеСостояния),
          DateTime = DateTime.Now
        });
      }
      pump1Run.Value = (int)sender.Value;      
    }

    private void Pump2Run_OnChangeValue(Tag sender) {
      if (pump2Run.Value != (int)sender.Value) {
        OnErrorTag?.Invoke(new EventLog {
          Source = "Насос2",
          Message = ((int)sender.Value == 0) ? "Включен" : "Выключен",
          EventLogType = EventLogType.ИзменениеСостояния,
          Brush = EventLog.GetBrush(EventLogType.ИзменениеСостояния),
          DateTime = DateTime.Now
        });
      }
      pump2Run.Value = (int)sender.Value;
     
    }
    private void Pump5Run_OnChangeValue(Tag sender) {
      if (pump5Run.Value != (int)sender.Value) {
        OnErrorTag?.Invoke(new EventLog {
          Source = "Насос5",
          Message = ((int)sender.Value == 0) ? "Включен" : "Выключен",
          EventLogType = EventLogType.ИзменениеСостояния,
          Brush = EventLog.GetBrush(EventLogType.ИзменениеСостояния),
          DateTime = DateTime.Now
        });
      }
      pump5Run.Value = (int)sender.Value;
     
    }

    public Tag Pump1Run { get; set; } = new Tag();
    public Tag Pump1Press { get; set; } = new Tag();
    public Tag Pump2Run { get; set; } = new Tag();
    public Tag Pump2Press { get; set; } = new Tag();
    public Tag Pump5Run { get; set; } = new Tag();
    public Tag Pump5Press { get; set; } = new Tag();
  }
}
