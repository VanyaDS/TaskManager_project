using System;
using System.Collections.Generic;
using System.Data.Linq;
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
    public partial class Registration : Window
    {
        

        private string SelectedRadioButValue { get; set; }
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(AgeTextBox.Text) == 100)
                return;
            AgeTextBox.Text = (int.Parse(AgeTextBox.Text) + 1).ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (int.Parse(AgeTextBox.Text) == 1)
                return;
            AgeTextBox.Text = (int.Parse(AgeTextBox.Text) - 1).ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string sqlExpression = $"INSERT INTO Users (surname, name, age, gender, password, login)  VALUES ('{SurnameTB.Text}', '{NameTB.Text}',{AgeTextBox.Text},'{SelectedRadioButValue}' ,'{passTB.Password}','{loginTB.Text}')";
            using (K_ProjectEntities db = new K_ProjectEntities())
            {

               int a =  db.Database.ExecuteSqlCommand(sqlExpression);
                Authorization authorization = new Authorization();
                authorization.Show();
                this.Close();

            }
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton item)
            {
                SelectedRadioButValue = item.Content.ToString();
            }
        }
    }
}
