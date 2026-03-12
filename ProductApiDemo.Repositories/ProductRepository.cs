using ProductApiDemo.Entities.Models;
using ProductApiDemo.Entities.RequestFeatures;
using ProductApiDemo.Repositories.Context;
using ProductApiDemo.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ProductApiDemo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Product> GetAll(ProductParameters productParameters)
        {
            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(productParameters.Name))
            {
                products = products.Where(p => p.Name.Contains(productParameters.Name)); // isim filtreleme 
            }

            if (productParameters.MinPrice.HasValue)
            {
                products = products.Where(p => p.Price >= productParameters.MinPrice.Value);
            }

            if (productParameters.MaxPrice.HasValue)
            {
                products = products.Where(p => p.Price <= productParameters.MaxPrice.Value);
            }

            return products
             .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)

             //pagination işlemi için Skip ve Take kullanarak sayfalama yapıyoruz.
             //Skip, belirtilen sayıda öğeyi atlar ve Take, belirtilen sayıda öğeyi alır.
             .Take(productParameters.PageSize) //pageSize kadar ürün alır
             .ToList();
        }



        public Product? GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
           _context.Products.Add(product);
              _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

       
       
        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
