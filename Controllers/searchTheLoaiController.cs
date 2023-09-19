using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTruyenTranh.Models;
using Newtonsoft.Json;

namespace WebTruyenTranh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class searchTheLoaiController : ControllerBase
    {
        [HttpGet]
        public List<TblTruyen> result(string tentl)
        {
            QltruyenContext db=new QltruyenContext();
            TblTheLoai idtheloai= db.TblTheLoais.FirstOrDefault(x=>x.TenTheLoai.Contains(tentl));
            return db.TblTruyens.Where(x=>x.IdTheLoai==idtheloai.IdTheLoai).ToList();
        }
    }
}
