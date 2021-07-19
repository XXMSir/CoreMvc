using System;
using System.Collections.Generic;
using System.Text;
using XuDal.Param;
using XuDb;

namespace XuDal.IDal
{
    public interface IUserLog : IBaseDal<UserInfo>
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        DataResponse<string> Register(RegisterParam param);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        DataResponse<string> Log(LogParam param);
    }
}
