using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librcic
{
    public class Returncodes
    {
        public enum ReturnCode
        {
            REQUEST_OK = 0,
            REQUEST_ICCARD_NOTFOUND_ERR = 8,
            REQUEST_ICCARD_READ_SN_ERR = 9,
            REQUEST_ICCARD_SELECTCARD_ERR = 10,
            REQUEST_ICCARD_LOAD_PWD_ERR = 11,
            REQUEST_ICCARD_VERIFY_PWD_ERR = 12,
            REQUEST_ICCARD_READ_ERR = 13,
            REQUEST_ICCARD_WRITE_ERR = 14,
            ENVIRONMENT_DLL_NOTFOUND = 21,
            ENVIRONMENT_DRIVER_ERR = 22,
            ENVIRONMENT_DRIVER_NOTFOUND = 23,
            ENVIRONMENT_TIMEOUT = 24,
            ENVIRONMENT_TXSIZE_ERR = 25,
            ENVIRONMENT_TXCRC_ERR = 26,
            ENVIRONMENT_RXSIZE_ERR = 27,
            ENVIRONMENT_RXCRC_ERR = 28,
            ENVIRONMENT_UNKNOWN_ERR = -1
        }
        /*
         *             REQUEST 8//寻卡错误
            READSERIAL 9//读序列吗错误
            SELECTCARD 10//选卡错误
            LOADKEY 11//装载密码错误
            AUTHKEY 12//密码认证错误
            READ 13//读卡错误
            WRITE 14//写卡错误

            NONEDLL 21//没有动态库
            DRIVERORDLL 22//动态库或驱动程序异常
            DRIVERNULL 23//驱动程序错误或尚未安装
            TIMEOUT 24//操作超时，一般是动态库没有反映
            TXSIZE 25//发送字数不够
            TXCRC 26//发送的CRC错
            RXSIZE 27//接收的字数不够
            RXCRC 28//接收的CRC错
        */
    }
}
