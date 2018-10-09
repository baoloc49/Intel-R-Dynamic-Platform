using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Intel_R__Dynamic_Platform
{
    class DeleteFile
    {
        public static void DeleteIMG()
        {
            DirectoryInfo drinfo = new DirectoryInfo(Capture.imagePath);
            if (!drinfo.Exists)
            {
                drinfo.Create();
            }
            FileInfo[] fiArr = drinfo.GetFiles();
            if (fiArr != null)
            {
                foreach (var item in fiArr)
                {
                    item.Delete();
                }
            }
            
        }
        public static void DeleteText()
        {
            string logName = "log";
            string logExtendtion = ".txt";
            string logNameToWrite = logName  + logExtendtion;
            FileInfo fi = new FileInfo(logNameToWrite);
            fi.Delete();
        }
    }
}
