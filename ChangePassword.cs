using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static librcic.Returncodes;

namespace librcic
{
    public class ChangePassword
    {
        public static ReturnCode ChangePwd(byte[] oldPassword, byte[] newPassword, byte areaNumber, byte authMode = 1)
        {
            if (oldPassword.Length != 6 || newPassword.Length != 6)
            {
                throw new Exception("Password length error");
            }
            byte status;//存放返回值
            byte myareano;//区号
            byte authmode;//密码类型，用A密码或B密码
            byte myctrlword;//控制字
            byte[] piccoldkey = new byte[6];//旧密码
            byte[] mypiccserial = new byte[4];//卡序列号
            byte[] piccnewkey = new byte[6]; //新密码.


            //控制字指定,控制字的含义请查看本公司网站提供的动态库说明
            myctrlword = 0;

            //指定区号
            myareano = areaNumber;
            //批定密码模式
            authmode = authMode;

            //指定旧密码
            piccoldkey = oldPassword;

            //指定新密码,注意：指定新密码时一定要记住，否则有可能找不回密码，导致该卡报废。
            piccnewkey = newPassword;

            status = DllInstanceEntry.piccchangesinglekey(myctrlword, mypiccserial, myareano, authmode, piccoldkey, piccnewkey);
            //在下面设定断点，然后查看mypiccserial、mypiccdata，
            //调用完 piccreadex函数可读出卡序列号到 mypiccserial，读出卡数据到mypiccdata，
            //开发人员根据自己的需要处理mypiccserial、mypiccdata 中的数据了。
            //处理返回函数
            switch (status)
            {
                case 0:
                    return (ReturnCode)0;
                //......
                case 8:
                    return (ReturnCode)8;

                default:
                    return (ReturnCode)status;

            }
        }
    }
}
