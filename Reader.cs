using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static librcic.Returncodes;

namespace librcic
{
    public class Reader
    {
        public static ReturnPacket ReadCard(byte[] password, byte areaNumber, byte authMode = 1)
        {
            ReturnPacket rp = new ReturnPacket();
            if (password.Length != 6)
            {
                throw new Exception("Password only have 6 bits.");
            }
            byte status;//存放返回值
            byte myareano;//区号
            byte authmode;//密码类型，用A密码或B密码
            byte myctrlword;//控制字
            byte[] mypicckey = new byte[6];//密码
            byte[] mypiccserial = new byte[4];//卡序列号
            byte[] mypiccdata = new byte[48]; //卡数据缓冲
            //控制字指定,控制字的含义请查看本公司网站提供的动态库说明
            myctrlword = DllInstanceEntry.CONTROLWORD;

            //指定区号
            myareano = areaNumber;//指定为第8区
            //批定密码模式
            authmode = authMode;//大于0表示用A密码认证，推荐用A密码认证

            //指定密码
            mypicckey = password;

            status = DllInstanceEntry.piccreadex(myctrlword, mypiccserial, myareano, authmode, mypicckey, mypiccdata);
            //在下面设定断点，然后查看mypiccserial、mypiccdata，
            //调用完 piccreadex函数可读出卡序列号到 mypiccserial，读出卡数据到mypiccdata，
            //开发人员根据自己的需要处理mypiccserial、mypiccdata 中的数据了。
            //处理返回函数
            if (status == 0)
            {
                rp.retCode = ReturnCode.REQUEST_OK;
                rp.retData = mypiccdata;
                rp.retSerialNumber = mypiccserial;
            }
            else if (status == 8)
            {
                rp.retCode = ReturnCode.REQUEST_ICCARD_NOTFOUND_ERR;
                rp.retData = null;
                rp.retSerialNumber = null;
            }
            return rp;
        }
    }
}
