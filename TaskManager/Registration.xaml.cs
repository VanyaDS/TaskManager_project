using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TaskManager.myDB;
using System.Security.Cryptography;
using System;

namespace TaskManager
{
    
    public partial class Registration : Window
    {
            
    public static string CurrentLogin { get; private set; }
        private static bool mark = false;

        private string SelectedRadioButValue { get; set; }
        public Registration()
        {
            InitializeComponent();
        }

        private void NumericUp_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(AgeTextBox.Text) == 100)
                return;
            AgeTextBox.Text = (int.Parse(AgeTextBox.Text) + 1).ToString();
        }

        private void NumericDown_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(AgeTextBox.Text) == 1 || int.Parse(AgeTextBox.Text)==0)
                return;
            AgeTextBox.Text = (int.Parse(AgeTextBox.Text) - 1).ToString();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (passTB.Password == "" || loginTB.Text == "")
                {
                    MessageBox.Show("Login AND password are required to enter!");
                    return;
                }

                if (!mark)
                {
                    MessageBox.Show("You will not be able to register until you correct the errors!\nPlease, try again");
                    SurnameTB.Text = ""; NameTB.Text = ""; AgeTextBox.Text = "0"; passTB.Password = ""; loginTB.Text = "";
                }
                else
                {


                    string sqlExpression = $"INSERT INTO Users (surname, name, age, gender, password, login)  VALUES ('{SurnameTB.Text}', '{NameTB.Text}',{AgeTextBox.Text},'{SelectedRadioButValue}' ,'{GetHashString(passTB.Password)}','{loginTB.Text}')";
                    using (K_ProjectEntities db = new K_ProjectEntities())
                    {

                        int a = db.Database.ExecuteSqlCommand(sqlExpression);
                        CurrentLogin = loginTB.Text;
                        AvatarComplete avatar = new AvatarComplete();
                        avatar.Show();
                        this.Close();
                        mark = false;
                    }
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }

}

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton item)
            {
                SelectedRadioButValue = item.Content.ToString();
            }
        }

        private void NameTB_PreviewKeyDown(object sender, KeyEventArgs e)
        {


            if (e.Key==Key.Space || e.Key==Key.Tab)  
            {
                e.Handled = true;
                return;

            }
            mark = true;
        }

        private void NameTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

           
            if (Regex.IsMatch(e.Text, @"\d{1}|\s{1}|\W{1}"))  
            {
                e.Handled = true;
                return;

            }
            mark = true;
        }
 
        private void NameTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if((sender as TextBox).Text=="")
            {
                mark = false;
                return;
            }
                      
                if ((sender as TextBox).Text.Length < 2)
                {
                    MessageBox.Show("The name and surname cannot contain less than two characters!");
                    
                mark = false;
                return;
                }

                if (!Regex.IsMatch((sender as TextBox).Text, @"^[A-ZА-Я]{1}\w*"))
                {
                    MessageBox.Show("The first letter of your NAME must be uppercase.\nPlease, check it");
                   
                mark = false;
                return;
                }
            mark = true;
            }
        private void loginTB_LostFocus(object sender, RoutedEventArgs e)
        {

            if ((sender as TextBox).Text == "")
            {
              
                mark = false;
                return;
            }

            if ((sender as TextBox).Text.Length < 2)
            {
                MessageBox.Show(" Login cannot contain less than two characters!");

                mark = false;
                return;
            }

            using(K_ProjectEntities db = new K_ProjectEntities())
            {
                if(db.Users.Any(n=>n.login==loginTB.Text))
                {
                    MessageBox.Show("User with this login is already registered!");
                    loginTB.Clear();
                    mark = false;
                    return;
                }
            }

            mark = true;
        }

        private void loginTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"\s{1}|\W{1}") && !Regex.IsMatch(e.Text, @"_"))
            {
                e.Handled = true;
                return;

            }
            mark = true;
        }

        private void passTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"\s{1}|\W{1}") && !Regex.IsMatch(e.Text, @"_"))
            {
                e.Handled = true;
                return;

            }
            mark = true;
        }

        private void passTB_LostFocus(object sender, RoutedEventArgs e)
        {

            if ((sender as PasswordBox).Password == "")
            {
             
                mark = false;
                return;
            }

            if ((sender as PasswordBox).Password.Length < 6)
            {
                MessageBox.Show(" Password cannot contain less than six characters!");

                mark = false;
                return;
            }

            if (!Regex.IsMatch((sender as PasswordBox).Password, @"\w*[A-ZА-Я]{1}\w*"))
            {
                MessageBox.Show("One character of your PASSWORD must be uppercase.\nPlease, check it");

                mark = false;
                return;
            }

            if (!Regex.IsMatch((sender as PasswordBox).Password, @"\w*[0-9]{1}\w*"))
            {
                MessageBox.Show("One character of your PASSWORD must be number.\nPlease, check it");

                mark = false;
                return;
            }

            mark = true;
        }

        private void MinWindowBut_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseBut_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider(); 
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = string.Empty;
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);
            return hash;
        }

    }
 }

