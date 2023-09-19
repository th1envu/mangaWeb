using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTruyenTranh.Models;

namespace WebTruyenTranh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class timTruyenController : ControllerBase
    {
        [HttpGet]
        public List<TblTruyen> search(string tentruyen)
        {
            QltruyenContext db= new QltruyenContext();
            return db.TblTruyens.Where(x=>x.TenTruyen.Contains(tentruyen)).ToList();
        }
    }
}
