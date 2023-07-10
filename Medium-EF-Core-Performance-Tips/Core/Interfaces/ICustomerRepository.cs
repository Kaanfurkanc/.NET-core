using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task CreateAsync(Customer customer);
        IQueryable<Customer> Where(Expression<Func<Customer, bool>> expression);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
