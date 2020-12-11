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
using System.Windows.Shapes;
using TaskManager.myDB;

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public static string CurrentLogin { get; set; }
       
        public Authorization()
        {
            InitializeComponent();
        }

        private void regTextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            regTextBlock.Foreground = new SolidColorBrush(Colors.Aqua);
            regTextBlock.TextDecorations = TextDecorations.Underline;
        }

        private void regTextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            regTextBlock.Foreground = new SolidColorBrush(Colors.White);
            regTextBlock.TextDecorations = null ;
        }

       
        private void regTextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sqlExpression = $"INSERT INTO Log_in (login, password)  VALUES ('{loginTB.Text}','{passTB.Password}')";
            using (K_ProjectEntities db = new K_ProjectEntities())
            {
                int IsAnyOne = db.Users.Where(p => p.login == loginTB.Text && p.password == passTB.Password).Count();
                if(IsAnyOne==0)
                {
                    MessageBox.Show("Данного пользователя не существует");
                }
                else
                {
                    int a = db.Database.ExecuteSqlCommand(sqlExpression);
                    CurrentLogin = loginTB.Text;
                    MainWindow window = new MainWindow();
                    window.Show();
                    this.Close();
                }



                

            }
        }
    }
}
