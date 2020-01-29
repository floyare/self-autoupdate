using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_autoupdate.Classes
{
    public class RandomString
    {
        public static string randomString(int length)
        {
            if (length > 35)
            {
                var minusLeng = length - 35;
                length = length - minusLeng;
            }

            string hS = "1a2b3c4d5e6f7g8h90ijklmnoprtstwuxyz";
            Random hR = new Random();
            StringBuilder hSB = new StringBuilder();
            for (int hI = 0; hI <= length; hI++)
            {
                int hIDX = hR.Next(0, hS.Count());
                hSB.Append(hS.Substring(hIDX, 1));
            }


            return hSB.ToString();
        }
    }
}
