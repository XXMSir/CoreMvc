using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace XuDal
{
    //枚举扩展属性
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            return value.GetType()
                .GetMember(value.ToString())
                .FirstOrDefault()?
                .GetCustomAttribute<DescriptionAttribute>()?
                .Description;
        }
    }
}
