using System;
using System.Collections.Generic;

namespace XuDb
{
    public class UserInfo
    {
        public string Id { get; set; }
        public string Account { get; set; }
        public string PassWord { get; set; }
        public string UseName { get; set; }
        public string Email { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? State { get; set; }
    }
}
