using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.myDB;


namespace TaskManager.Patterns
{
    class UnitOfWork
    {
        private K_ProjectEntities db = new K_ProjectEntities();
        private SqlUserRepository userRepository;
        private SqlLog_inRepository log_inRepository;
        private SqlSettingsRepository settingsRepository;
        private SqlTaskReoisitory taskReoisitory;

      public SqlTaskReoisitory Tasks
        {
            get
            {
                if (taskReoisitory == null)
                    taskReoisitory = new SqlTaskReoisitory(db);
                return taskReoisitory;
            }
        }

        public SqlSettingsRepository Settings
        {
            get
            {
                if (settingsRepository == null)
                    settingsRepository = new SqlSettingsRepository(db);
                return settingsRepository;
            }
        }


        public SqlUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new SqlUserRepository(db);
                return userRepository;
            }
        }

        public SqlLog_inRepository Log_ins
        {
            get
            {
                if (log_inRepository == null)
                    log_inRepository = new SqlLog_inRepository(db);
                return log_inRepository;
            }
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
        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
