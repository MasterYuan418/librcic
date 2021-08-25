using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librcic
{
    public class Writer
    {
        public static void WriteCard(byte[] password, byte areaNumber, byte[] data, byte authMode = 1)
        {
            ReturnPacket rp = new ReturnPacket();
            if (password.Length != 6)
            {
                throw new Exception("Password length only can equeals to 6");
            }
            byte i;
            byte status;//存放返回值
            byte myareano;//区号
            byte authmode;//密码类型，用A密码或B密码
            byte myctrlword;//控制字
            byte[] mypicckey = new byte[6];//密码
            byte[] mypiccserial = new byte[4];//卡序列号
            byte[] mypiccdata = new byte[48]; //卡数据缓冲
            if (data.Length != 48)
            {
                throw new Exception("Data only can be 48 bits");
            }
            mypiccdata = data;
            //控制字指定,控制字的含义请查看本公司网站提供的动态库说明

            myctrlword = DllInstanceEntry.CONTROLWORD;

            //指定区号
            myareano = areaNumber;
            //批定密码模式
            authmode = authMode;

            //指定密码
            mypicckey = password;
            //指定卡数据
            status = DllInstanceEntry.piccwriteex(myctrlword, mypiccserial, myareano, authmode, mypicckey, mypiccdata);
        }
    }
}
