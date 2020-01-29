using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace self_autoupdate.Classes.RegistryClasses
{
    public class RegistryModify
    {
        static RegistryKey BaseFolderPath = Registry.CurrentUser;
        static string subfolderPath = Globals.SubFolderPath;
        static string isUpdate = "isUPDATE";
        static string Version;

        public static void registryWrite(string txt, string key)
        {
            RegistryKey RegKey = BaseFolderPath;
            RegistryKey subKey = RegKey.CreateSubKey(subfolderPath);

            subKey.SetValue(key, txt);
        }

        public static string registryRead(string key)
        {
            RegistryKey RegKey = BaseFolderPath;
            RegistryKey subKey = RegKey.OpenSubKey(subfolderPath);

            return subKey.GetValue(key).ToString();
        }
    }
}
