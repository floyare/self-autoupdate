using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_autoupdate.Classes
{
    public class Globals
    {
        public static bool useRegistry = true; //Change to "false" if you do not want to interfere with the registry
        //WARNING: If you change the "useRegisty" value to "false" you must change the  the appearance of the saved version. Ex. From "v0.1" to "0.1.0.0" 
        //and change the product version after every update.

        public static string fileURL = "";//Type URL for file here.
        public static string verURL = ""; //Type URL for version txt here.
        public static string SubFolderPath = "myApp";
        public static string exeName = "self-autoupdate";
    }
}
