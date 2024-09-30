using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data.Abstract
{
    public interface IRepository<T> where T : class //tüm veritabanı classları için çalışabilmesi için T isimlendirmesi yaptık ve şart olarak T bir class olmalı 
    {
        List<T> GetAll(); //GetAll çağırılınca tüm kayıtlar gelecek
        List<T> GetAll(Expression<Func<T, bool>> expression); //filtre gönderirsek burası gelecek

        T Get(Expression<Func<T, bool>> expression);

        T Find(int id); //id ile eşleşen kaydı getirir.

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Save();

        // Asenkron Metotlar
        Task<T> FindAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task<int> SaveAsync();
    }
}
