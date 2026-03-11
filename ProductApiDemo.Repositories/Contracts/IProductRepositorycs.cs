using ProductApiDemo.Entities.Models;
using System.Collections.Generic;

namespace ProductApiDemo.Repositories.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
