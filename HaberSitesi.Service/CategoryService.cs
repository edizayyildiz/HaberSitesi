using HaberSitesi.Data;
using HaberSitesi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesi.Service
{
    public interface ICategoryService
    {
        void Insert(Category category);
        void Update(Category category);
        void Delete(Category category);
        void Delete(Guid id);
        Category Find(Guid id);
        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetAll(Expression<Func<Category, bool>> where);
    }

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CategoryService(IRepository<Category> categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Delete(Category category)
        {
            categoryRepository.Delete(category);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var categoryToDelete = this.Find(id);
            if (categoryToDelete != null)
            {
                this.Delete(categoryToDelete);
            }
        }

        public Category Find(Guid id)
        {
            return categoryRepository.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public IEnumerable<Category> GetAll(Expression<Func<Category, bool>> where)
        {
            return categoryRepository.GetAll(where);
        }

        public void Insert(Category category)
        {
            categoryRepository.Insert(category);
            unitOfWork.SaveChanges();
        }

        public void Update(Category category)
        {
            var model = this.Find(category.Id);
            model.Name = category.Name;
            model.Description = category.Description;
            categoryRepository.Update(model);
            unitOfWork.SaveChanges();
        }
    }
}
