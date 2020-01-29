using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace self_autoupdate
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void checkRegistryAndInstall()
        {
            if (Classes.RegistryClasses.RegistryModify.registryRead("isUPDATE") == "true")
            {
                Classes.RegistryClasses.RegistryModify.registryWrite("false", "isUPDATE");
                File.Delete(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\" + Classes.Globals.exeName + ".exe");
                MessageBox.Show("UPDATED!");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {  
            if(Classes.Globals.useRegistry == true)
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\" + Classes.Globals.SubFolderPath, "isUPDATE", null) == null)
                {
                    Classes.RegistryClasses.RegistryModify.registryWrite("false", "isUPDATE");
                    checkRegistryAndInstall();
                }
                else
                {
                    if (Registry.GetValue(@"HKEY_CURRENT_USER\" + Classes.Globals.SubFolderPath, "Version", null) == null)
                    {
                        Classes.RegistryClasses.RegistryModify.registryWrite("v0.1", "Version");
                        label2.Text = Classes.RegistryClasses.RegistryModify.registryRead("Version");
                        checkRegistryAndInstall();
                    }
                    else
                    {
                        label2.Text = Classes.RegistryClasses.RegistryModify.registryRead("Version");
                        checkRegistryAndInstall();
                    }


                }

                if (System.Reflection.Assembly.GetExecutingAssembly().GetName().Name != Classes.Globals.exeName + ".exe") //Rename file to original filename
                {
                    System.IO.File.Move(Path.GetFileName(Application.ExecutablePath), Classes.Globals.exeName + ".exe");
                }
            }
            else
            {
                if (File.Exists("isUPDATE"))
                {
                    File.Delete("isUPDATE");
                    label2.Text = Application.ProductVersion;
                    MessageBox.Show("UPDATED!");
                    File.Delete(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\" + Classes.Globals.exeName + ".exe");

                    if (System.Reflection.Assembly.GetExecutingAssembly().GetName().Name != Classes.Globals.exeName + ".exe") //Rename file to original filename
                    {
                        System.IO.File.Move(Path.GetFileName(Application.ExecutablePath), Classes.Globals.exeName + ".exe");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Classes.Globals.useRegistry == true)
            {
                Classes.AutoUpdate.checkReg();
            }
            else
            {
                Classes.AutoUpdate.checkUpdate();
            }
        }
    }
}
