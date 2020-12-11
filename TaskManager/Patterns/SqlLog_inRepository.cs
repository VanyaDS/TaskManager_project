using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.myDB;

namespace TaskManager.Patterns
{
    class SqlLog_inRepository : IRepository<Log_in>
    {

        private K_ProjectEntities db;

        public SqlLog_inRepository(K_ProjectEntities context)
        {
            this.db = context;
        }
      

        public void DeleteItem(string log)
        {
            Log_in log_In = db.Log_in.Find(log);
            if (log_In != null)
                db.Log_in.Remove(log_In);
        }


        public IEnumerable<Log_in> GetList()
        {
            return db.Log_in;
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
        ~SqlLog_inRepository()
        {
            Dispose(false);
        }
    }

}

