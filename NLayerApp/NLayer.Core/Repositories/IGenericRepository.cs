using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository <T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        // ProductRepository.Where(x=>x.id>5).ToListAsync();
        // x = T
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T,bool>> expression);
        Task  AddAsync(T entity);
        Task AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);


        //public interface IGenericRepository<T> where T : class
        //{
        //    IEnumerable<T> GetAll();
        //    T GetById(int id);
        //    void Insert(T entity);
        //    void Update(T entity);
        //    void Delete(int id);
        //}
    
}
}
