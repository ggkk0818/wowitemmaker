using System;
using System.Collections.Generic;
using System.Text;

namespace WOWItemMaker
{
    class Util
    {
        public static string to16(int i)
        {
            string r = Convert.ToString(i, 16);
            if (r.Length == 1)
                r = "0" + r;
            return r.ToUpper();
        }
    }
}
