using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Enums
{
    public enum VerifyType
    {
        [Description("Email验证")]
        EmailVerify = 0,
        [Description("手机注册验证")]
        MobileVerify = 1,
        [Description("修改手机发送验证码")]
        ChangePhone = 2,
        [Description("找回密码验证")]
        FindPassword = 10
    }

    public enum VerifyStatus
    {
        [Description("待验证")]
        WaitFor = 0,
        [Description("验证成功")]
        Success = 1,
        [Description("验证失败")]
        Failure = -1,
        [Description("过期")]
        Expired = -2,
    }
    public enum SMSStatus
    {
        /// <summary>
        /// 待发送
        /// </summary>
        [Description("待发送")]
        NoSend = 0,

        /// <summary>
        /// 已发送
        /// </summary>
        [Description("已发送")]
        Sended = 1
    }
    public enum SMSType
    {
        [Description("验证手机号")]
        VerifyPhone = 0,
        [Description("支付")]
        Payment = 1,
        [Description("找回密码")]
        FindPassword = 2,
        [Description("修改密码提示")]
        AlertUpdatePassword = 3,
        [Description("虚拟团购")]
        VirualGroupBuy = 4
    }
}
