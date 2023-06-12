using WebApiDemo.Models;

namespace WebApiDemo.IServicrs
{
    public interface IStuManger
    {
        #region 全部信息
        IEnumerable<Stuinfo> GetAll();
        #endregion
        List<Stuinfo> GetInfo(string name);

      

    }
}
