using WebApiDemo.IServicrs;
using WebApiDemo.Models;

namespace WebApiDemo.Services
{
    public class StuManger : IStuManger
    {
        
        StuinfoContext stu= new StuinfoContext();
        public IEnumerable<Stuinfo> GetAll()
        {
          return stu.Stuinfos.ToList();
        }

        public List<Stuinfo> GetInfo(string name)
        {
          
            var list= stu.Stuinfos.Where(x => x.Stuname.Equals(name)).ToList();
            if (list == null) 
            { 
                throw new ArgumentNullException(nameof(name), $"学生信息不存在：{name}"); 
            } 
            else 
            { 
                return list; 
            }

          
        }

      
    }
}
