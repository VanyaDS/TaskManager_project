using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.myDB;

namespace TaskManager.Patterns
{
    class SqlTaskReoisitory: IRepository<myDB.Task>
    {
        private K_ProjectEntities db;

        public SqlTaskReoisitory(K_ProjectEntities context)
        {
            this.db = context;
        }


        public void DeleteItem(string log)
        {
            IQueryable<myDB.Task> userTasks = db.Tasks.Where(n => n.login == log);
            foreach (myDB.Task task in userTasks)
            {
                if (task != null)
                    db.Tasks.Remove(task);
            }
            
        }


        public IEnumerable<myDB.Task> GetList()
        {
            return db.Tasks;
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
        ~SqlTaskReoisitory()
        {
            Dispose(false);
        }
    }





}

