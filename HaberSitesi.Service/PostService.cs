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
    public interface IPostService
    {
        void Insert(Post post);
        void Update(Post post);
        void Delete(Post post);
        void Delete(Guid id);
        Post Find(Guid id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAll(Expression<Func<Post, bool>> where);
    }

    public class PostService : IPostService
    {
        private readonly IRepository<Post> postRepository;
        private readonly IUnitOfWork unitOfWork;
        public PostService(IRepository<Post> postRepository, IUnitOfWork unitOfWork)
        {
            this.postRepository = postRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Delete(Post post)
        {
            postRepository.Delete(post);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var postToDelete = this.Find(id);
            if (postRepository != null)
            {
                this.Delete(postToDelete);
            }
        }

        public Post Find(Guid id)
        {
            return postRepository.Find(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return postRepository.GetAll();
        }

        public IEnumerable<Post> GetAll(Expression<Func<Post, bool>> where)
        {
            return postRepository.GetAll(where);
        }

        public void Insert(Post post)
        {
            postRepository.Insert(post);
            unitOfWork.SaveChanges();
        }

        public void Update(Post post)
        {
            var model = this.Find(post.Id);
            model.Title = post.Title;
            model.Description = post.Description;
            model.Body = post.Body;
            model.CategoryId = post.CategoryId;
            postRepository.Update(model);
            unitOfWork.SaveChanges();
        }
    }
}
