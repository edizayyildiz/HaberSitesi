using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        private DbContextTransaction transaction;
        public UnitOfWork(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void BeginTransaction()
        {
            transaction = db.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
