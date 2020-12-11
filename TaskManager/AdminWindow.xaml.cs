using System.Windows;
using TaskManager.myDB;
using System.ComponentModel;
using TaskManager.Patterns;
using System;

namespace TaskManager
{

    public partial class AdminWindow : Window
    {
        private static BindingList<User> GridInfo = new BindingList<myDB.User>();
        private static BindingList<User> SearchGridInfo = new BindingList<myDB.User>();
      
        public AdminWindow()
        {

            InitializeComponent();
        
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GridInfo.Clear();
            UnitOfWork admin = new UnitOfWork();
            var users = admin.Users.GetList();
           
            foreach (var item in users)
            {
                GridInfo.Add(item);
            }
            UserGrid.ItemsSource = GridInfo;
            admin.Dispose();
        }
        private void BlockBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            
            if (GridInfo.Count < 1)
            {
                MessageBox.Show("No user to block");
                return;
            }
            if (UserGrid.SelectedIndex == -1)
            {

                MessageBox.Show("Select any user to block");
                return;
            }

            UnitOfWork adminDel = new UnitOfWork();
            adminDel.Users.DeleteItem(((User)UserGrid.SelectedItem).login);
            adminDel.Log_ins.DeleteItem(((User)UserGrid.SelectedItem).login);
            adminDel.Tasks.DeleteItem(((User)UserGrid.SelectedItem).login);
            adminDel.Settings.DeleteItem(((User)UserGrid.SelectedItem).login); 
            adminDel.Save();
            adminDel.Dispose();
            GridInfo.Remove(((User)UserGrid.SelectedItem));
            SearchGridInfo.Remove(((User)UserGrid.SelectedItem));
            MessageBox.Show("Account destroyed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void findTB_LostFocus(object sender, RoutedEventArgs e)
        {

            if (findTB.Text == "")
            {
                UserGrid.ItemsSource = GridInfo;
                resBN.Visibility = Visibility.Hidden;
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            findTB.Text = "";
            UserGrid.ItemsSource = GridInfo;
            resBN.Visibility = Visibility.Hidden;


        }

        private void findTB_GotFocus(object sender, RoutedEventArgs e)
        {
           
            resBN.Visibility = Visibility.Hidden;
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitAcc_Click(object sender, RoutedEventArgs e)
        {
            Authorization.SetNullLogin();
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            
           SearchGridInfo.Clear();

            foreach (var item in GridInfo)
            {

                if (item.login.ToLower().Contains(findTB.Text.ToLower()) || item.name.ToString().ToLower().Contains(findTB.Text.ToLower()) || item.surname.ToString().ToLower().Contains(findTB.Text.ToLower()) || item.age.ToString().ToLower().Contains(findTB.Text.ToLower()))
                {
                    SearchGridInfo.Add(item);
                }
            }

            UserGrid.ItemsSource = SearchGridInfo;

            resBN.Visibility = Visibility.Visible;

        }
      
    }
}