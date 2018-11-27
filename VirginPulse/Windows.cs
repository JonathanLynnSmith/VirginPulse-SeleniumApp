using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace VirginPulse
{
    class Windows
    {

        public string Cmd { get; set; }
        public static string applicationPath = System.Reflection.Assembly.GetEntryAssembly().Location;
        public static string directoryPath = System.Environment.CurrentDirectory;
       public Windows()
        {
            Console.WriteLine("");
            Console.WriteLine("What time would you like this to run daily? ");
            Console.WriteLine("Format like this >> HH:MM (i.e. 09:00, 20:00)");
            Console.Write("Time: ");
            string time = Console.ReadLine();

            Cmd = $@"/C SchTasks /Create /SC DAILY /TN ""Virgin Pulse"" /TR ""{applicationPath} run"" /v1 /ST {time}";
        }

        public void CreateScheduledTask()
        {
            System.Diagnostics.Process.Start("CMD.exe", Cmd + "& Pause");
        }

        static public void Log(string message)
        {
            string logPath = $"{directoryPath}\\VP-Log.txt";

            using (StreamWriter f = File.AppendText(logPath))
            {
                var dateTime = DateTime.Now;
                f.WriteLine($"{dateTime}: {message}");
            }

            System.Diagnostics.Process.Start(logPath);
        }
    }
}
