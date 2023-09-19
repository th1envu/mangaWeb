using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTruyenTranh.Models;

namespace WebTruyenTranh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisplayChapterImg : ControllerBase
    {
        [HttpGet]
        public List<TblChuongHinhAnh> getListImg(int idchuong)
        {
            QltruyenContext db= new QltruyenContext();
            List<TblChuongHinhAnh> list = new List<TblChuongHinhAnh>();
            list=db.TblChuongHinhAnhs.Where(x=>x.IdChuong==idchuong).OrderBy(x => x.SoAnh).ToList();
            return list;
        }
    }
}
