using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowService
{
    public class Utilities
    {
        public static void WriteLogError(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTimeOffset.Now.ToString("dd/MM/yyy") + ": " + ex.Source + "; " + ex.Message);
                sw.Flush();
                sw.Close();
            }
            catch (Exception e)
            {

            }
        }

        public static void WriteLogError(string message) 
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTimeOffset.Now.ToString("dd/MM/yyy") + ": " + message);
                sw.Flush();
                sw.Close();
            }
            catch (Exception e)
            {

            }
        }
    }
}
