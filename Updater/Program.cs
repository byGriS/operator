using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Updater {
  class Program {

    private static string EnvPath = "";

    static void Main(string[] args) {
      if (args.Length == 1)
        return;
      try {
        EnvPath = args[1];
      } catch { }
      Console.WriteLine("Обновление:");
      if (args[0] == "d") {
        try {
          CloseSpark();
          Console.WriteLine("10%");
          DeleteFile("Operator.exe");
          Console.WriteLine("55%");
          DownloadFile("Operator.exe");
          Console.WriteLine("95%");
          Process start = new Process();
          start.StartInfo.FileName = "Operator.exe";
          start.Start();
          Console.WriteLine("100%");
          Console.WriteLine("Обновление успешно завершено");
        } catch (Exception ex) {
          string s = DateTime.Now.ToString("########## dd.MM.yyyy HH:mm:ss");
          string path = Directory.GetCurrentDirectory();
          StreamWriter sw = new StreamWriter(path + "\\errors.txt", true, Encoding.Unicode);
          sw.WriteLine(s + "\n " + ex.Message + "\n" + ex.ToString());
          sw.Close();
        }
      }
    }

    static private void DownloadFile(string fileName) {
      string remoteUri = "http://spautomation.ru/operator/";
      string myStringWebResource = null;
      WebClient myWebClient = new WebClient();
      myWebClient.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
      myStringWebResource = remoteUri + fileName;
      myWebClient.DownloadFile(myStringWebResource, EnvPath + fileName);
    }

    static private void CloseSpark() {
      foreach (Process proc in Process.GetProcessesByName("Operator")) {
        proc.Kill();
      }
    }

    static private void DeleteFile(string fileName) {
      if (File.Exists(fileName)) {
        for (int i = 0; i < 10; i++) {
          try {
            File.Delete(EnvPath + fileName);
            break;
          } catch {
            Thread.Sleep(1000);
          }
        }
      }
    }
  }
}
