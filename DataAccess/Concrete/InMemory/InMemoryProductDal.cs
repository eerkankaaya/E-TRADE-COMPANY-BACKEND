using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {

        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> 
            {

                new Product{ProductId=1, CategoryId=1 , ProductName="Erkan",UnitPrice=23,UnitsInStock=19},
                new Product{ProductId=2, CategoryId=1 , ProductName="Yağmur",UnitPrice=25,UnitsInStock=16},
                new Product{ProductId=3, CategoryId=2 , ProductName="Kar",UnitPrice=23,UnitsInStock=12},
                new Product{ProductId=4, CategoryId=2 , ProductName="Yemek",UnitPrice=25,UnitsInStock=13},
                new Product{ProductId=5, CategoryId=2 , ProductName="Su",UnitPrice=23,UnitsInStock=12}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            
           Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(product);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
         
        }
        
    }
}
