using ProductApiDemo.Entities.Models;
using System.Collections.Generic;
using ProductApiDemo.Entities.RequestFeatures;

namespace ProductApiDemo.Repositories.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll(ProductParameters productParameters);
        // Artık boş gelmeyecek filtreleme ve pagination bilgilerini alacak 
        Product? GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
