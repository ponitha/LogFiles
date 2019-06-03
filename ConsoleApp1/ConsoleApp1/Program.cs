using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ErrorLoggingSample
{
    class Program
    {
        static void Main(string[] args)
        {
            int  result;
            int a = 12, b = 0;
          

            try
            {
                result = a / b;
                
            }
            catch (DivideByZeroException ex)
            {
               // throw ex;
                ErrorLogging(ex);
                ReadError();
            }

        }

        public static void ErrorLogging(Exception ex)
        {
            string strPath = @"C:\\Users\\u6072696\\Desktop\\New folder\\a.txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("===========End============= " + DateTime.Now);

            }
        }

        public static void ReadError()
        {
            string strPath = @"C:\\Users\\u6072696\\Desktop\\New folder\\a.txt";
            using (StreamReader sr = new StreamReader(strPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}