using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.myDB;

namespace TaskManager.Patterns
{

    interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetList();
        void DeleteItem(string log);
        void Save();
    }
  
    
    class SqlUserRepository:IRepository<User>
    {
        private K_ProjectEntities db;

        public SqlUserRepository(K_ProjectEntities context)
        {
            this.db = context;
        }


        public void DeleteItem(string log)
        {
            User user = db.Users.Find(log);
            if (user != null)
                db.Users.Remove(user);
        }

        public IEnumerable<User> GetList()
        {
            return db.Users;
        }

        public void Save()
        {
            db.SaveChanges();
        }


        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~SqlUserRepository()
        {
            Dispose(false);
        }
    }
}
