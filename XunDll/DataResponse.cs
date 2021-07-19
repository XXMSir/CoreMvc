using System;
using System.Collections.Generic;
using System.Text;

namespace XuDal
{
    /// <summary>
    /// 单条数据返回
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataResponse<T>
    {
        public int Core{ get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }

    /// <summary>
    /// 多条数据返回
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataResponseList<T>
    {
        public int Core { get; set; }

        public string Message { get; set; }

        public List<T> Data { get; set; }
    }
}
