using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librcic
{
    public class GetSN
    {
        public static string ReadICCardSN()
        {
            byte[] devno = new byte[4];
            if (DllInstanceEntry.pcdgetdevicenumber(devno) == 0)
            {
                return System.Convert.ToString(devno[0]) + "-" + System.Convert.ToString(devno[1]) + "-" + System.Convert.ToString(devno[2]) + "-" + System.Convert.ToString(devno[3]);
                //ShowMessage(IntToStr(devno[0]) + "-" + IntToStr(devno[1]) + "-" + IntToStr(devno[2]) + "-" + IntToStr(devno[3]));
            }
            throw new Exception();
        }
    }
}
