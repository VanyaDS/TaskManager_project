using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.myDB;

namespace TaskManager.Patterns
{
    class SqlSettingsRepository: IRepository<UserSetting>
    {
        private K_ProjectEntities db;

        public SqlSettingsRepository(K_ProjectEntities context)
        {
            this.db = context;
        }


        public void DeleteItem(string log)
        {
            UserSetting setting = db.UserSettings.Find(log);
            if (setting != null)
                db.UserSettings.Remove(setting);
        }


        public IEnumerable<UserSetting> GetList()
        {
            return db.UserSettings;
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
        ~SqlSettingsRepository()
        {
            Dispose(false);
        }








    }
}
