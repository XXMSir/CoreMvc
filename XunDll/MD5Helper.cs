using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using XuMvc;

namespace XuDal
{
    public class MD5Helper
    {
        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string MD5Encrypt32(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return null;
            }
            try
            {
                string cl = password;
                string pwd = "";
                //实例化一个md5对像
                MD5 md5 = MD5.Create();
                // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
                byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
                // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
                for (int i = 0; i < s.Length; i++)
                {
                    // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                    pwd = pwd + s[i].ToString("X");
                }
                return pwd;
            }
            catch (Exception e)
            {
                LogHelper.LogError(e.Message);
                return null;
            }
        }
    }
}
