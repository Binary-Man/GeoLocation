using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.IO;
using System.Reflection;

namespace GeoLocation
{
    public class LogHelper
    {
        public static log4net.ILog GetLogger([CallerFilePath] string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }

        private string _exePath = string.Empty;

        public void LogWrite(string logMessage)
        {
            // var path = Assembly.GetExecutingAssembly().Location;
            // Gave the wrong path. therefore using HttpContext.Current.Request.ApplicationPath instead
            
            var path = HttpContext.Current.Request.PhysicalApplicationPath;
            _exePath = Path.GetDirectoryName(path);
            try
            {
                using (StreamWriter w = File.AppendText(_exePath + "\\" + "log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception)
            {
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                txtWriter.WriteLine(" :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception)
            {
            }
        }

    }
}