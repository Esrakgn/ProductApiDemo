using System;
using ProductApiDemo.Entities.Models;
using System.Collections.Generic;

namespace ProductApiDemo.Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product? GetProductById(int id);
        Product AddProduct(Product product);
        void UpdateProduct(int id, Product product);
        void DeleteProduct(int id);
    }
}
//Service katmanının ürünler için hangi işleri yapacağını tanımlıyor.