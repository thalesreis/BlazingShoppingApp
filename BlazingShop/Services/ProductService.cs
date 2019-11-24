using BlazingShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Product GetProduct(int ProductId)
        {
            return _db.Products.Include(u => u.Category).FirstOrDefault(x => x.Id == ProductId);
        }

        public List<Product> GetProducts()
        {
            return _db.Products.Include(u => u.Category).ToList();
        }

        public List<Category> GetCategoryList()
        {
            return _db.Categories.ToList();
        }

        public bool CreateProduct(Product ProductToCreate)
        {
            _db.Products.Add(ProductToCreate);
            _db.SaveChanges();

            return true;
        }

        public bool UpdateProduct(Product ProductToUpdate)
        {
            var prod = _db.Products.FirstOrDefault(x => x.Id == ProductToUpdate.Id);
            if (prod != null)
            {
                if (ProductToUpdate.Image == null)
                {
                    ProductToUpdate.Image = prod.Image;
                }
                _db.Products.Update(ProductToUpdate);
                _db.SaveChanges();
                return true;
            }          

            return false;
        }

        public bool DeleteProduct(Product ProductToDelete)
        {
            var prod = _db.Products.FirstOrDefault(x => x.Id == ProductToDelete.Id);
            if (prod != null)
            {
                _db.Products.Remove(prod);
                _db.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
