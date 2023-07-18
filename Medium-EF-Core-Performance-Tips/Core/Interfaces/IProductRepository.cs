using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetAllAsync(int page, int pageSize);
        Task<Product?> GetByIdAsync(int id);
        Task<IEnumerable<Product?>> GetPopularProductsAsync();
        Task CreateAsync(Product product);
        IQueryable<Product> Where(Expression<Func<Product, bool>> expression);
        void Update(Product product);
        void Delete(Product product);
    }
}
