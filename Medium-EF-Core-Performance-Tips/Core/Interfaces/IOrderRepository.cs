using Core.Entities;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();

        Task<IEnumerable<Order>> UseEagerLoadingAsync();
        Task<IEnumerable<Product>> UseLazyLoadingAsync(int id);
        Task<Order> GetByIdAsync(int id);
        Task CreateAsync(Order order);
        IQueryable<Order> Where(Expression<Func<Order, bool>> expression);
        void Update(Order order);
        void Delete(Order order);
    }
}
