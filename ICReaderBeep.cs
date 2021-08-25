using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librcic
{
    public class ICReaderBeep
    {
        public static void Beep(uint ms)
        {
            DllInstanceEntry.pcdbeep(ms);
        }
    }
}
