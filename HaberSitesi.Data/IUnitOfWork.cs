﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesi.Data
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void SaveChanges();
        void Rollback();
    }
}
