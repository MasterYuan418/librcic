using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librcic
{
    public class ReturnPacket
    {
        public Returncodes.ReturnCode retCode;
        public byte[] retData;
        public byte[] retSerialNumber;
    }
}
