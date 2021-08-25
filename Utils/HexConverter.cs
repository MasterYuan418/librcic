using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librcic.Utils
{
    public class HexConverter
    {
        public static string convertToHex(byte st)
        {
            return st.ToString("x8").Replace("0",string.Empty);
        }
        public static int convertToDec(string hex)
        {
            return System.Convert.ToInt32(hex, 16);
        }
    }
}
