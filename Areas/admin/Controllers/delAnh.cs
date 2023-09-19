using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTruyenTranh.Models;

namespace WebTruyenTranh.Areas.admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class delAnh : ControllerBase
    {
        [HttpGet]
        public List<TblChuongHinhAnh> getIdAnh(int idchuong)
        {
            QltruyenContext db = new QltruyenContext();
            return db.TblChuongHinhAnhs.Where(x => x.IdChuong == idchuong).ToList();
        }
    }
}
