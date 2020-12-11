using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.myDB;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

using System.Data.Entity;

namespace TaskManager
{

    public partial class MainWindow : Window
    {
       private BindingList<myDB.Task> GridInfo;
        public MainWindow()
        {
            InitializeComponent();
           using(K_ProjectEntities db = new K_ProjectEntities())
            {
                //myDB.Task task = new myDB.Task { category = "csacsac", login = "go", priority = 1, taskText = "make kyrsa4", compleateDate = DateTime.Now };
                //db.Tasks.Add(task);
                //db.SaveChanges();

                //User user = db.Users.First(n => n.age == 4);
                //user.age = 10;
                //db.Entry(user).State = EntityState.Modified;
                //db.SaveChanges();



            }



        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TaskGrid.ItemsSource = GridInfo;
           // TaskGrid.ListChanged+= TaskGrid_ListChanged;
        }


        private void TaskGrid_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemMoved)
            {

               

            }
        }


    }
}
