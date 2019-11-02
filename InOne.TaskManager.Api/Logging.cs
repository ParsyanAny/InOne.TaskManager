using System.IO;

namespace InOne.TaskManager.Api
{
    public class Logging
    {
        public static void WriteLog(string strLog)
        {
            string logFilePath = @"C:\Users\Any\Desktop\Hey.txt";
            File.WriteAllText(logFilePath, strLog);
        }
    }
}