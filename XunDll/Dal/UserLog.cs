using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;
using System.Data;
using XuDb;
using XuDal.IDal;
using XuDal.Dal;
using XuMvc;
using System.Security.Cryptography;
using XuDal.Param;
using XuModel.Db;
using XuDal.EnumModel;

namespace XuDal
{
    public class UserLog : BaseDal<UserInfo>, IUserLog
    {
        public UserLog(XuModel.Db.XuDbContext db, IDbConnection dbConnection) : base(db, dbConnection)
        {

        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public DataResponse<string> Register(RegisterParam param)
        {
            DataResponse<string> data = new DataResponse<string>();
            try
            {
                //对密码加密
                var pass = MD5Helper.MD5Encrypt32(param.PassWord);
                if (string.IsNullOrEmpty(pass))
                {
                    data.Message = "密码有误,请重新输入!";
                    data.Core = (int)ResponseEnum.Fail;
                }

                UserInfo user = new UserInfo()
                {
                    Id = Guid.NewGuid().ToString(),
                    Account = param.Account,
                    PassWord = param.PassWord,
                    UseName = param.UseName,
                    Email = param.Email,
                    CreateTime = DateTime.Now,
                    State = 1
                };

                _db.Add(user);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                data.Message = EnumExtensions.GetDescription(ResponseEnum.Exception);
                data.Core = (int)ResponseEnum.Exception;

                LogHelper.LogError(e.Message);
            }
            return data;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public DataResponse<string> Log(LogParam param)
        {
            DataResponse<string> data = new DataResponse<string>();

            try
            {
                var pass = MD5Helper.MD5Encrypt32(param.PassWord);
                var query = _db.UserInfos.Where(p=>p.Account== param.Account&&p.PassWord==pass).FirstOrDefault();

                if (query==null)
                {
                    data.Message = "用户不存在,请检查账号与密码!";
                    data.Core = (int)ResponseEnum.Prosperity;
                    return data;
                }

                data.Message = EnumExtensions.GetDescription(ResponseEnum.Prosperity);
                data.Core = (int)ResponseEnum.Prosperity;
            }
            catch (Exception e)
            {
                data.Message = EnumExtensions.GetDescription(ResponseEnum.Prosperity);
                data.Core = (int)ResponseEnum.Exception;

                LogHelper.LogError(e.Message);
            }

            return data;
        }
    }
}
