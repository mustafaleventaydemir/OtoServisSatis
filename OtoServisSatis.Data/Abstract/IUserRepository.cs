using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data.Abstract
{
    public interface IUserRepository : IRepository<Kullanici>
    {
        Task<List<Kullanici>> GetCustomUserList(); //liste döndüren
        Task<List<Kullanici>> GetCustomUserList(Expression<Func<Kullanici, bool>> expression);
    }
}
