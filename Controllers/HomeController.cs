using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebTruyenTranh.Models;
using WebTruyenTranh.Models.Authentication;
using X.PagedList;

namespace WebTruyenTranh.Controllers
{
    public class HomeController : Controller
    {
        QltruyenContext db = new QltruyenContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //[Authentication]
        public IActionResult Index(int? page)
        {
            int pageSize = 21;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lsttruyen = db.TblTruyens.AsNoTracking().OrderBy(x => x.TenTruyen);
            PagedList<TblTruyen> lst = new PagedList<TblTruyen>(lsttruyen, pageNumber, pageSize);
            return View(lst);
        }

        public IActionResult IndexAfterLogin(int? page)
        {
            int pageSize = 21;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lsttruyen = db.TblTruyens.AsNoTracking().OrderBy(x => x.TenTruyen);
            PagedList<TblTruyen> lst = new PagedList<TblTruyen>(lsttruyen, pageNumber, pageSize);
            return View(lst);
        }

        public IActionResult ChiTietTruyen(int matruyen)
        {
            var truyen = db.TblTruyens.SingleOrDefault(x => x.IdTruyen == matruyen);
            return View(truyen);
        }

        public IActionResult ChiTietAnh(int machuong)
        {
            var truyen = db.TblChuongs.SingleOrDefault(x => x.IdChuong == machuong);
            return View(truyen);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}