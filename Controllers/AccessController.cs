using Microsoft.AspNetCore.Mvc;
using WebTruyenTranh.Models;

namespace WebTruyenTranh.Controllers
{
    public class AccessController : Controller
    {
        QltruyenContext db = new QltruyenContext();
        [HttpGet]

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Login(TblUser user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var u = db.TblUsers.Where(x => x.UserName.Equals(user.UserName) && x.PassWord.Equals(user.PassWord)).FirstOrDefault();
                if (((u != null)&&(u.IsAdmin.Trim()=="0"))||(((u != null) && (u.IsAdmin.Trim() == ""))))
                {
                    HttpContext.Session.SetString("UserName", u.UserName.ToString());
                    return RedirectToAction("IndexAfterLogin", "Home");
                }
                if ((u != null) && (u.IsAdmin.Trim() == "1"))
                {
                    HttpContext.Session.SetString("UserName", u.UserName.ToString());
                    return RedirectToAction("index", "admin");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login", "Access");
        }

		[Route("ThemUser")]
		[HttpGet]
		public IActionResult ThemUser()
		{
			return View();
		}
		[Route("ThemUser")]
		[HttpPost]
		public IActionResult ThemUser(TblUser user)
		{
			if (ModelState.IsValid)
			{
				db.TblUsers.Add(user);
				db.SaveChanges();
				return RedirectToAction("login");
			}
			return View(user);
		}
	}
}
