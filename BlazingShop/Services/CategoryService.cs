using BlazingShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingShop.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _db;

        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category GetCategory(int categoryId)
        {
            return _db.Categories.FirstOrDefault(x => x.Id == categoryId);
        }

        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }

        public bool CreateCategory(Category categoryToCreate)
        {
            _db.Categories.Add(categoryToCreate);
            _db.SaveChanges();

            return true;
        }

        public bool UpdateCategory(Category categoryToUpdate)
        {
            var cat = _db.Categories.FirstOrDefault(x => x.Id == categoryToUpdate.Id);
            if (cat != null)
            {
                cat.Name = categoryToUpdate.Name;
                _db.SaveChanges();
                return true;
            }          

            return false;
        }

        public bool DeleteCategory(Category categoryToDelete)
        {
            var cat = _db.Categories.FirstOrDefault(x => x.Id == categoryToDelete.Id);
            if (cat != null)
            {
                _db.Categories.Remove(cat);
                _db.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
