using System;
using System.Windows.Media;

namespace Service {
  public class EventLog {

    public int ID { get; set; }
    public DateTime DateTime { get; set; }
    public EventLogType EventLogType { get; set; }
    public string Message { get; set; }
    public string Source { get; set; }
    public Brush Brush { get; set; }

    public static Brush GetBrush(EventLogType type) {
      switch (type) {
        case EventLogType.Авария:
          return new SolidColorBrush(Colors.LightPink);
        case EventLogType.Внимание:
          return new SolidColorBrush(Colors.LightYellow);
        case EventLogType.Ошибка:
          return new SolidColorBrush(Colors.LightBlue);
        case EventLogType.ИзменениеСостояния:
          return new SolidColorBrush(Colors.Gray);
        default:
          return new SolidColorBrush(Colors.White);
      }
    }
  }
  public enum EventLogType {
    Сообщение = 1,
    Внимание = 2,
    Ошибка = 3,
    Авария = 4,
    ИзменениеСостояния = 5
  }
}
