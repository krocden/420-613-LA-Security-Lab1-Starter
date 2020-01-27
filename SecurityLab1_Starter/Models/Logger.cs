using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace SecurityLab1_Starter.Models
{
    public class Logger
    {
        public void eventLog(EventLogEntryType type, String text)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(text, type, 101, 1);
            }

        }
        public void writeLog(Exception e)
        {
            using (StreamWriter w = File.AppendText("C://Users//Kevin//Desktop//Log.txt"))
            {
                Log("TEST"+ e, w);
                Log("TEST2" + e, w);
            }

            using (StreamReader r = File.OpenText("C://Users//Kevin//Desktop//Log.txt"))
            {
                DumpLog(r);
            }

        }
        public void writeLogin(String e)
        {
            using (StreamWriter w = File.AppendText("C://Users//Kevin//Desktop//useraccess.txt"))
            {
                Log(e, w);
                Log(e, w);
            }

            using (StreamReader r = File.OpenText("C://Users//Kevin//Desktop//useraccess.txt"))
            {
                DumpLog(r);
            }

        }
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }

        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}