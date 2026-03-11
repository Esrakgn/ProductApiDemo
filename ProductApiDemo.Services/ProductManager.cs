using ProductApiDemo.Entities.Models;
using ProductApiDemo.Repositories.Contracts;
using ProductApiDemo.Services.Contracts;
using System;
using System.Collections.Generic;

namespace ProductApiDemo.Services
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductManager(IProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAll();
        }

        public Product? GetProductById(int id)
        {
            return _repository.GetById(id);
        }

        public Product AddProduct(Product product)
        {
            if (string.IsNullOrEmpty(product.Name))
                throw new ArgumentException("Product name cannot be null or empty.");

            if (product.Price < 0)
                throw new ArgumentException("Product price cannot be negative.");

            _repository.Add(product);
            return product;
        }

        public void UpdateProduct(int id, Product product)
        {
            var existingProduct = _repository.GetById(id);

            if (existingProduct == null)
                throw new KeyNotFoundException($"Product with id {id} not found.");

            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Product name cannot be null or empty.");

            if (product.Price <= 0)
                throw new ArgumentException("Product price cannot be negative.");


            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            _repository.Update(existingProduct);
        }


        public void DeleteProduct(int id)
        {
            var existingProduct = _repository.GetById(id);

            if (existingProduct == null)
                throw new Exception($"Product with id {id} was not found.");

            _repository.Delete(existingProduct);
        }
    }
}
//repository’ye doğrudan gitmeden önce kuralları kontrol ediyoruz.
