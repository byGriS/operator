using Service;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;

namespace Data {
  public class DataBase {

    private static string dbFileName = "logs.sqlite";
    private static SQLiteConnection dbConn = new SQLiteConnection();
    private static SQLiteCommand sqlCmd = new SQLiteCommand();

    public static void WriteLog(EventLog eventLog) {
      if (dbConn.State != ConnectionState.Open) {
        dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
        dbConn.Open();
        System.Threading.Thread.Sleep(500);
      } else {

      }
      sqlCmd.Connection = dbConn;
      sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS logs (id INTEGER PRIMARY KEY AUTOINCREMENT, timeStamp datetime, type int, source text, message text )";
      sqlCmd.ExecuteNonQuery();
      sqlCmd.CommandText = "INSERT INTO logs ('timeStamp', 'type', 'source', 'message') values ('" +
              eventLog.DateTime.ToString("yyyy-MM-dd HH:mm:ss") + "' , '" +
              (int)eventLog.EventLogType + "' , '" +
              eventLog.Source + "' , '" +
              eventLog.Message + "')";
      sqlCmd.ExecuteNonQuery();
    }

    public static void ReadNewLogs(ObservableCollection<EventLog> logs) {
      if (dbConn.State != ConnectionState.Open) return;
      if (logs.Count > 0) {
        sqlCmd.CommandText = "Select * From logs where id > " + logs[0].ID + ";";
      } else {
        sqlCmd.CommandText = "Select * From logs;";
      }
      SQLiteDataReader dataReader = sqlCmd.ExecuteReader();
      DataTable dt = new DataTable();
      dt.Load(dataReader);

      foreach (DataRow row in dt.Rows) {
        logs.Insert(0, new EventLog {
          ID = Convert.ToInt32(row.ItemArray[0]),
          DateTime = DateTime.Parse(row.ItemArray[1].ToString()),
          EventLogType = (EventLogType)Enum.Parse(typeof(EventLogType), row.ItemArray[2].ToString()),
          Source = row.ItemArray[3].ToString(),
          Message = row.ItemArray[4].ToString(),
          Brush = EventLog.GetBrush((EventLogType)Enum.Parse(typeof(EventLogType), row.ItemArray[2].ToString()))
        });
      }
    }
  }
}
