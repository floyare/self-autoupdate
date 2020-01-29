using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace self_autoupdate.Classes
{
    public class AutoUpdate
    {
        static WebClient Client = new WebClient();
        static string serverVersion = CallRequest.callRequest(Globals.verURL);
        static RegistryKey reg;

        public static void checkUpdate()
        {
            if(Globals.useRegistry == true)
            {
                if (serverVersion != RegistryClasses.RegistryModify.registryRead("Version"))
                {
                    try
                    {
                        RegistryClasses.RegistryModify.registryWrite(serverVersion, "Version");
                        RegistryClasses.RegistryModify.registryWrite("true", "isUPDATE");
                        string exe = RandomString.randomString(15) + ".exe";
                        Client.Proxy = null; //b!g anti fiddler protection
                        Client.DownloadFile(Globals.fileURL, exe); // download
                        System.Diagnostics.Process.Start(exe);
                        Application.Exit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                if(serverVersion != Application.ProductVersion)
                {
                    try
                    {
                        StreamWriter Writer = new StreamWriter("isUPDATE");
                        Writer.Write("");
                        Writer.Close();
                        string exe = RandomString.randomString(15) + ".exe";
                        Client.Proxy = null; //b!g anti fiddler protection
                        Client.DownloadFile(Globals.fileURL, exe); // download
                        System.Diagnostics.Process.Start(exe);
                        Application.Exit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        public static bool basefoldercheck()
        {
            try
            {
                reg = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, @"HKEY_CURRENT_USER\" + Globals.SubFolderPath);
                if (reg == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void checkReg()
        {
            if(basefoldercheck() == false)
            {
                RegistryClasses.RegistryModify.registryWrite("false", "isUPDATE");
                RegistryClasses.RegistryModify.registryWrite("v0.1", "Version");
                checkUpdate();
            }
            else
            {
                checkUpdate();
            }
        }
    }
}
