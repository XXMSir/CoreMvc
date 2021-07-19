using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XuDal.IDal;
using XuDal.Param;

namespace XuMvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserLog _userLog;

        public IActionResult Login()
        {
            return View();
        }

        public JsonResult Logins(LogParam param)
        {
            var a= _userLog.Log(param);
            return Json(a);
        }
    }
}
