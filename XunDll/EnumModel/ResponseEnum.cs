using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XuDal.EnumModel
{
    /// <summary>
    /// 请求响应类型
    /// </summary>
    public enum ResponseEnum
    {
        //成功
        [Description("请求成功")]
        Prosperity =200,
        //失败
        [Description("请求失败")]
        Fail =500,
        //内部异常
        [Description("内部异常")]
        Exception =404,
    }
}
