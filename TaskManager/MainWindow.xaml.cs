using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TaskManager.myDB;
using System.Data;
using System.ComponentModel;
using System.Data.Entity;
namespace TaskManager
{

    public partial class MainWindow : Window
    {

        private static int index;
        public static BindingList<myDB.Task> GridInfo = new BindingList<myDB.Task>();
        private static BindingList<myDB.Task> SearchGridInfo = new BindingList<myDB.Task>();
        private static bool leaveChangeTheme= false;
        public static void AddNewTask(myDB.Task task)
        {

            GridInfo.Add(task);
        }

        

        public MainWindow()
        {
       
            InitializeComponent();
            styleBox.SelectionChanged += ThemeChange;
            
        }
        
 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

           
            GridInfo.Clear();
            using (K_ProjectEntities db = new K_ProjectEntities())
            {

                if (db.UserSettings.Any(n => n.login == Authorization.CurrentLogin))
                {
                    if (db.UserSettings.First(n => n.login == Authorization.CurrentLogin).theme == "blue")
                    {

                        styleBox.SelectedItem = dbl;
                    }
                    else if (db.UserSettings.First(n => n.login == Authorization.CurrentLogin).theme == "orange")
                    {

                        styleBox.SelectedItem = dor;
                    }
                   if(db.UserSettings.Find(Authorization.CurrentLogin).avatar!=null)
                    {
                        testIM.Source = new BitmapImage(new Uri(db.UserSettings.Find(Authorization.CurrentLogin).avatar));
                    }
                      
                    else
                        testIM.Source = new BitmapImage(new Uri(@"Avatars\incognito.png",UriKind.Relative));
                }
                

                IQueryable<myDB.Task> userTasks = db.Tasks.Where(n => n.login == Authorization.CurrentLogin);
                foreach (var item in userTasks)
                {
                    GridInfo.Add(item);
                }
            }

            TaskGrid.ItemsSource = GridInfo;
            GridInfo.ListChanged += GridInfo_ListChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void GridInfo_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemMoved)
            {



            }
        }



        private void TaskGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            index = TaskGrid.SelectedIndex;

        }

        private void TaskGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            try
            {

           
            TaskGrid.SelectedIndex = index;
            var a = TaskGrid.SelectedItem as myDB.Task;

            using (K_ProjectEntities db = new K_ProjectEntities())
            {
                myDB.Task task = db.Tasks.First(n => n.taskNumber == a.taskNumber);
                task.taskText = a.taskText;
                task.done = a.done;
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
            }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in GridInfo)
            {
                if(item.taskTime!=null)
                {
                    MessageBox.Show("First you need to finish the task for a while");
                    return;

                }
            }
            if (OwnedWindows.Count == 0)
            {
        
                
          
                TaskCreation taskWindow = new TaskCreation();
                taskWindow.Owner = this;
                taskWindow.Show();
            }
            
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            try
            {

           
            if (GridInfo.Count < 1)
            {
                MessageBox.Show("No task to delete");
                return;
            }
            if (TaskGrid.SelectedIndex == -1)
            {
                foreach (var item in GridInfo)
                {
                    if (item.taskTime != null)
                    {
                        TaskCreation.mark = true;
                        return;

                    }
                }
                MessageBox.Show("Select a task to delete");
                return;
            }

            if (TaskGrid.SelectedIndex == GridInfo.Count-1)
            {
                foreach (var item in GridInfo)
                {
                    if (item.taskTime != null)
                    {
                        TaskCreation.mark = true;
                        return;

                    }
                }
                
            }

            using (K_ProjectEntities db = new K_ProjectEntities())
            {
                
                db.Entry(TaskGrid.SelectedItem).State = EntityState.Deleted;
                db.SaveChanges();
                GridInfo.Remove((myDB.Task)TaskGrid.SelectedItem);
                SearchGridInfo.Remove((myDB.Task)TaskGrid.SelectedItem);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in GridInfo)
            {
                if (item.taskTime != null)
                {
                   
                    return;

                }
            }
            SearchGridInfo.Clear();

            foreach (var item in GridInfo)
            {

                if (item.category.ToLower().Contains(findTB.Text.ToLower()) || item.compleateDate.ToString().ToLower().Contains(findTB.Text.ToLower()) || item.priority.ToString().ToLower().Contains(findTB.Text.ToLower()) || item.taskText.ToLower().Contains(findTB.Text.ToLower()))
                {
                    SearchGridInfo.Add(item);
                }
            }

            TaskGrid.ItemsSource = SearchGridInfo;

            resBN.Visibility = Visibility.Visible;

        }

        private void findTB_LostFocus(object sender, RoutedEventArgs e)
        {
            foreach (var item in GridInfo)
            {
                if (item.taskTime != null)
                {
                    findTB.Text = "";
                    return;

                }
            }
            if (findTB.Text == "")
            {
                TaskGrid.ItemsSource = GridInfo;
                resBN.Visibility = Visibility.Hidden;
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            findTB.Text = "";
            TaskGrid.ItemsSource = GridInfo;
            resBN.Visibility = Visibility.Hidden;


        }

        private void findTB_GotFocus(object sender, RoutedEventArgs e)
        {
            foreach (var item in GridInfo)
            {
                if (item.taskTime != null)
                {
                    MessageBox.Show("First you need to finish the task for a while");
                    return;

                }
            }
            resBN.Visibility = Visibility.Hidden;
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in GridInfo)
            {
                if (item.taskTime != null)
                {
                    MessageBox.Show("First you need to finish the task for a while");
                    return;

                }
            }
            resBN2.Visibility = Visibility.Visible;

            SearchGridInfo.Clear();
            foreach (var item in GridInfo)
            {

                if (calend.SelectedDate.ToString() == item.compleateDate.ToString())
                {
                    SearchGridInfo.Add(item);


                }
            }
            TaskGrid.ItemsSource = SearchGridInfo;

        }

        private void resBN2_Click(object sender, RoutedEventArgs e)
        {
            TaskGrid.ItemsSource = GridInfo;
            resBN2.Visibility = Visibility.Hidden;
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            try
            {

           
            if (leaveChangeTheme)
            {
                var uri = new Uri(@"Themes\DarkBlue.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                leaveChangeTheme = false;
                return;
            }


            using (K_ProjectEntities db = new K_ProjectEntities())
            {

                if (db.UserSettings.Where(n => n.login == Authorization.CurrentLogin).Count() == 0)
                {
                    UserSetting setting = new UserSetting() { login = Authorization.CurrentLogin };


                    if (styleBox.SelectedItem.ToString().Contains("blue"))
                    {
                        var uri = new Uri(@"Themes\DarkBlue.xaml", UriKind.Relative);
                        ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                        Application.Current.Resources.Clear();
                        Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                        setting.theme = "blue";
                        db.UserSettings.Add(setting);
                        db.SaveChanges();

                    }
                    else if (styleBox.SelectedItem.ToString().Contains("orange"))
                    {

                        var uri = new Uri(@"Themes\DarkOrange.xaml", UriKind.Relative);
                        ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                        Application.Current.Resources.Clear();
                        Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                        setting.theme = "orange";
                        db.UserSettings.Add(setting);
                        db.SaveChanges();
                    }
                }
                else
                {

                    if (styleBox.SelectedItem.ToString().Contains("blue"))
                    {

                        if (db.UserSettings.First(n => n.login == Authorization.CurrentLogin).theme == "blue")
                        {

                            var uri = new Uri(@"Themes\DarkBlue.xaml", UriKind.Relative);
                            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                            Application.Current.Resources.Clear();
                            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                        }
                        else
                        {


                            db.Database.ExecuteSqlCommand($"UPDATE UserSettings SET theme='blue' WHERE login='{Authorization.CurrentLogin}'");
                            var uri = new Uri(@"Themes\DarkBlue.xaml", UriKind.Relative);
                            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                            Application.Current.Resources.Clear();
                            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                        }
                    }

                    if (styleBox.SelectedItem.ToString().Contains("orange"))
                    {

                        if (db.UserSettings.First(n => n.login == Authorization.CurrentLogin).theme == "orange")
                        {

                            var uri = new Uri(@"Themes\DarkOrange.xaml", UriKind.Relative);
                            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                            Application.Current.Resources.Clear();
                            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                        }
                        else
                        {
                            db.Database.ExecuteSqlCommand($"UPDATE UserSettings SET theme='orange' WHERE login='{Authorization.CurrentLogin}'");
                            var uri = new Uri(@"Themes\DarkOrange.xaml", UriKind.Relative);
                            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                            Application.Current.Resources.Clear();
                            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                        }
                    }


                }


            }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void DelAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {

           

            if (GridInfo.Count < 1)
            {
                MessageBox.Show("No existing tasks");
                return;
            }

            if (TaskGrid.ItemsSource == SearchGridInfo)
            {
                if(SearchGridInfo.Count<1)
                {
                    MessageBox.Show("No existing tasks");
                    return;
                }
                using (K_ProjectEntities db = new K_ProjectEntities())
                {
                    foreach (var item in SearchGridInfo)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                        GridInfo.Remove(item);
                    }
                    SearchGridInfo.Clear();
                    db.SaveChanges();
                    TaskCreation.mark = true;

                }

            }
            else
            {

                TaskCreation.mark = true;
                GridInfo.Clear();
                using (K_ProjectEntities db = new K_ProjectEntities())
                {
                    db.Database.ExecuteSqlCommand($"delete from Tasks WHERE login='{Authorization.CurrentLogin}'");
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }


        private void ExitAcc_Click(object sender, RoutedEventArgs e)
        {
            try
            {

          
            leaveChangeTheme = true;
            styleBox.SelectedItem = null;
            Authorization.SetNullLogin();
            TaskCreation.mark = true;
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            if (OwnedWindows.Count == 0)
            {
                AvatarComplete avatar = new AvatarComplete();
                avatar.Owner = this;
                avatar.Show();
            }
          
     
        }
           
        }
    }
