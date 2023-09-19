using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTruyenTranh.Models;

namespace WebTruyenTranh.Areas.admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class delTruyen : ControllerBase
    {
        [HttpGet]
        public List<TblChuong> getIdChuong(int idtruyen)
        {
            QltruyenContext db=new QltruyenContext();
            return db.TblChuongs.Where(x=>x.IdTruyen== idtruyen).ToList();
        }
        //[HttpDelete]
        //public bool Delete(int idt)
        //{
        //    try
        //    {
        //        QltruyenContext db = new QltruyenContext();
        //    }
        //}
    }
}
