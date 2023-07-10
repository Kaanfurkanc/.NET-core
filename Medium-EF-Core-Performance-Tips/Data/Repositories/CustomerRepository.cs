using Core.Entity;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<Customer> customerSet;
        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            customerSet = _dataContext.Set<Customer>();
        }
        public async Task CreateAsync(Customer customer)
        {
            await customerSet.AddAsync(customer);
            await _dataContext.SaveChangesAsync();
        }

        public void Delete(Customer customer)
        {
            customerSet.Remove(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await customerSet.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await customerSet.FindAsync(id);
        }

        public void Update(Customer customer)
        {
            customerSet.Update(customer);
            _dataContext.SaveChanges();
        }

        public IQueryable<Customer> Where(Expression<Func<Customer, bool>> expression)
        {
            return customerSet.Where(expression);
        }
    }
}
Jwt ile iam service imi tamamladım . Ufak bir iki authorize işlemi kaldı . 
Şuan ef core performance tips üzerine araştırma yapıyorum . Araştırmalarımı medium da yayınlamak üzere makaleye döküyorum . Bitirdiğimde sizinle paylaşacağım 
Geçen hafta sizinle konuşmuştuk her hafta bir design pattern üzerine çalışma