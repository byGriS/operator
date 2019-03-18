using System.Collections.Generic;
using System.Management;
using System.IO;

namespace Operator {
  public class License {

    public static SystemData systemDataEx = new SystemData();

    public static bool CheckLicense() {
      GetSystemData();
      if (File.Exists("license.lic")) {
        string file = (string)Service.WorkFile.Do("license.lic", Service.WorkFileMode.ReadAllText);
        if (Decoder(file) == systemDataEx.lineResult)
          return true;
        else
          return false;
      } else {
        return false;
      }
     
    }

    public static bool WriteLicense() {
      GetSystemData();
      Service.WorkFile.Do("license.lic", Service.WorkFileMode.WriteNew, Coder(systemDataEx.lineResult));
      return true;
    }

    private static string Coder(string input) {
      char[] cArray = input.ToCharArray();
      for (var i = 0; i < cArray.Length; i++) {
        cArray[i] = (char)(cArray[i] + 1);
      }
      return new string(cArray);
    }

    private static string Decoder(string input) {
      char[] cArray = input.ToCharArray();
      for (var i = 0; i < cArray.Length; i++) {
        cArray[i] = (char)(cArray[i] - 1);
      }
      return new string(cArray);
    }

    private static void GetSystemData() {
      List<string[]> processor = SelectWMI("Win32_Processor", new string[] { "NumberOfCores", "ProcessorId", "Name", "SocketDesignation" });
      if ((processor.Count > 0) && (processor[0].Length == 4)) {
        systemDataEx.numberOfCores = processor[0][0];
        systemDataEx.processorID = processor[0][1];
        systemDataEx.name = processor[0][2];
        systemDataEx.socketDesignation = processor[0][3];
      }
      List<string[]> bios = SelectWMI("Win32_BIOS", new string[] { "Manufacturer", "Name", "Version" });
      if ((bios.Count > 0) && (bios[0].Length == 3)) {
        systemDataEx.biosManufacturer = bios[0][0];
        systemDataEx.biosName = bios[0][1];
        systemDataEx.biosVersion = bios[0][2];
      }
      List<string[]> board = SelectWMI("Win32_BaseBoard", new string[] { "Product" });
      if ((board.Count > 0) && (board[0].Length == 1)) {
        systemDataEx.baseBoard = board[0][0];
      }
      systemDataEx.lineResult = systemDataEx.numberOfCores +
         systemDataEx.processorID +
         systemDataEx.name +
         systemDataEx.socketDesignation +
         systemDataEx.biosManufacturer +
         systemDataEx.biosName +
         systemDataEx.biosVersion +
         systemDataEx.baseBoard;

    }

    #region работа с WMI
    private static List<string[]> SelectWMI(string table, string[] columns) {
      List<string[]> result = new List<string[]>();
      string query = "select * from " + table;
      ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
      try {
        foreach (ManagementObject arg in searcher.Get()) {
          string[] data = new string[columns.Length];
          for (int i = 0; i < columns.Length; i++) {
            try { data[i] = arg[columns[i]].ToString().Trim(); } catch { }
          }
          result.Add(data);
        }
      } catch { }
      return result;
    }

    private static List<string> AssociatorsWMI(string associator, string assocClass, string column) {
      List<string> result = new List<string>();
      string query = "associators of {" + associator + "} where AssocClass = " + assocClass;
      ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
      try {
        foreach (ManagementObject arg in searcher.Get()) {
          result.Add(arg[column].ToString().Trim());
        }
      } catch { }
      return result;
    }
    #endregion
  }

  public class SystemData {
    public string numberOfCores = "";
    public string processorID = "";
    public string name = "";
    public string socketDesignation = "";
    public string biosManufacturer = "";
    public string biosName = "";
    public string biosVersion = "";
    public string baseBoard = "";
    public string lineResult = "";
  }
}
