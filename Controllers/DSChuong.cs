using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTruyenTranh.Models;

namespace WebTruyenTranh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DSChuong : ControllerBase
    {
        [HttpGet]
        public List<TblChuong> getListChuong(int idtruyen)
        {
            QltruyenContext db= new QltruyenContext();
            List<TblChuong> list = new List<TblChuong>();
            list=db.TblChuongs.Where(x=>x.IdTruyen==idtruyen).ToList();
            return list;
        }
    }
}
