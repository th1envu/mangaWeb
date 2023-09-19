using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebTruyenTranh.Models;
using WebTruyenTranh.Models.Authentication;
using X.PagedList;

namespace WebTruyenTranh.Areas.admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QltruyenContext db=new QltruyenContext();
        [Route("")]
        [Route("index")]
        [Authentication]
        public IActionResult Index()
        {
            return View();
        }
        [Route("listtruyen")]
        public IActionResult ListTruyen(int? page)
        {
            int pageSize = 21;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lsttruyen = db.TblTruyens.AsNoTracking().OrderBy(x => x.IdTruyen);
            PagedList<TblTruyen> lst = new PagedList<TblTruyen>(lsttruyen, pageNumber, pageSize);
            return View(lst);
        }
        [Route("listchuong")]
        public IActionResult ListChuong(int? page)
        {
            int pageSize = 21;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstchuong = db.TblChuongs.AsNoTracking().OrderBy(x => x.IdChuong);
            PagedList<TblChuong> lst = new PagedList<TblChuong>(lstchuong, pageNumber, pageSize);
            return View(lst);
		}
		[Route("listuser")]
		public IActionResult ListUser(int? page)
		{
			int pageSize = 21;
			int pageNumber = page == null || page < 0 ? 1 : page.Value;
			var lstuser = db.TblUsers.AsNoTracking().OrderBy(x => x.UserName);
			PagedList<TblUser> lst = new PagedList<TblUser>(lstuser, pageNumber, pageSize);
			return View(lst);
		}
		[Route("ThemTruyenMoi")]
        [HttpGet]
        public IActionResult ThemTruyenMoi()
        {
            ViewBag.IdNguon=new SelectList(db.TblNguonTruyens.ToList(),"IdNguon", "TenNguon");
            ViewBag.IdNxb = new SelectList(db.TblNxbs.ToList(), "IdNxb", "TenNxb");
            return View();
        }
        [Route("ThemTruyenMoi")]
        [HttpPost]
        public IActionResult ThemTruyenMoi(TblTruyen truyen) 
        {
            if(ModelState.IsValid)
            {
                db.TblTruyens.Add(truyen);
                db.SaveChanges();
                return RedirectToAction("listtruyen");   
            }
            return View(truyen); 
        }


        [Route("SuaTruyen")]
        [HttpGet]
        public IActionResult SuaTruyen(int idtruyen)
        {
            ViewBag.IdNguon = new SelectList(db.TblNguonTruyens.ToList(), "IdNguon", "TenNguon");
            ViewBag.IdNxb = new SelectList(db.TblNxbs.ToList(), "IdNxb", "TenNxb");
            var truyen=db.TblTruyens.Find(idtruyen);
            return View(truyen);
        }
        [Route("SuaTruyen")]
        [HttpPost]
        public IActionResult SuaTruyen(TblTruyen truyen)
        {
            if (ModelState.IsValid)
            {
                db.Update(truyen);
                db.SaveChanges();
                return RedirectToAction("listtruyen");
            }
            return View(truyen);
        }
        [Route("XoaTruyen")]
        [HttpGet]
        public IActionResult XoaTruyen(int idtruyen)
        {
            var truyen = db.TblTruyens.SingleOrDefault(x=>x.IdTruyen== idtruyen);
            var chuong = db.TblChuongs.Where(x=>x.IdTruyen== idtruyen).ToList();
            if (chuong != null)
            {
                foreach(var item in chuong)
                {
                    db.TblChuongs.Remove(item);
                    db.SaveChanges();
                }
            }
            db.TblTruyens.Remove(truyen);
            db.SaveChanges();
            return RedirectToAction("listtruyen");
        }

        [Route("ThemChuongMoi")]
        [HttpGet]
        public IActionResult ThemChuongMoi()
        {
            return View();
        }
        [Route("ThemChuongMoi")]
        [HttpPost]
        public IActionResult ThemChuongMoi(TblChuong chuong)
        {
            if (ModelState.IsValid)
            {
                db.TblChuongs.Add(chuong);
                db.SaveChanges();
                return RedirectToAction("listchuong");
            }
            return View(chuong);
        }
        [Route("SuaChuong")]
        [HttpGet]
        public IActionResult SuaChuong(int idchuong, int idtruyen, int sochuong)
        {
            var chuong = db.TblChuongs.Find(idchuong, idtruyen, sochuong);
            return View(chuong);
        }
        [Route("SuaChuong")]
        [HttpPost]
        public IActionResult SuaChuong(TblChuong chuong)
        {
            if (ModelState.IsValid)
            {
                db.Update(chuong);
                db.SaveChanges();
                return RedirectToAction("listchuong");
            }
            return View(chuong);
        }
        [Route("XoaChuong")]
        [HttpGet]
        public IActionResult XoaChuong(int idchuong)
        {
            var chuong = db.TblChuongs.SingleOrDefault(x => x.IdChuong == idchuong);
            db.TblChuongs.Remove(chuong);
            db.SaveChanges();
            return RedirectToAction("listchuong");
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
                return RedirectToAction("listuser");
            }
            return View(user);
        }
        [Route("SuaUser")]
        [HttpGet]
        public IActionResult SuaUser(string username)
        {
            var user = db.TblUsers.Find(username);
            return View(user);
        }
        [Route("SuaUser")]
        [HttpPost]
        public IActionResult SuaUser(TblUser user)
        {
            if (ModelState.IsValid)
            {
                db.Update(user);
                db.SaveChanges();
                return RedirectToAction("listuser");
            }
            return View(user);
        }
        [Route("XoaUser")]
        [HttpGet]
        public IActionResult XoaUser(string username)
        {
            var user = db.TblUsers.SingleOrDefault(x => x.UserName == username);
            db.TblUsers.Remove(user);
            db.SaveChanges();
            return RedirectToAction("listuser");
        }
    }
}
