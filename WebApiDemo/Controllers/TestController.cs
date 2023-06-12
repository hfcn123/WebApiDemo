using Microsoft.AspNetCore.Mvc;
using WebApiDemo.IServicrs;
using WebApiDemo.Models;
using WebApiDemo.Services;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly StuinfoContext _context;

        public TestController(StuinfoContext context)
        {
            _context = context;
        }

       

        [HttpGet]
        public string GetString() 
        {
         
            return "a"; 
        }
        /// <summary>
        /// 获取所有学生姓名
        /// </summary>
        /// <returns>学生姓名列表</returns>
        static readonly IStuManger stuManger = new StuManger();
        [HttpGet]
        public IEnumerable<Stuinfo> GetAllStuinfo()
        {
            return stuManger.GetAll();
        }
        [HttpGet]
        public Stuinfo GetStuinfo(string name) 
        { 
        var StuItem=stuManger.GetInfo(name);

            if (StuItem != null) { return StuItem.FirstOrDefault(); } else {
                throw new ArgumentNullException(nameof(name), $"学生信息不存在：{name}");
            }
        }
        [HttpPost]
        public int postid() 
        {
            return 1;

        }
    }
}
