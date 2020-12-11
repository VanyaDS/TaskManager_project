using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TaskManager.myDB;
using System.Security.Cryptography;
using System.Text;
using System;

namespace TaskManager
{

    public partial class Authorization : Window
    {
        private static bool mark = false;
        public static string CurrentLogin { get; private set; }

        public static void SetNullLogin()
        {
            CurrentLogin = null;
        }
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
            this.Close();
        }

        private void LoginBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {

           
            if (loginTB.Text==""||passTB.Password=="")
            {
                MessageBox.Show("Login AND password are required to enter!");
                return;
            }

            if(!mark)
            {
                MessageBox.Show("You will not be able to register until you correct the errors!\nPlease, try again");
                 passTB.Password = ""; loginTB.Text = "";
                
            }
            else
            {


                string hashPassword = GetHashString(passTB.Password);
                using (K_ProjectEntities db = new K_ProjectEntities() )
                {
                    if(db.Admins.Any(n=>n.admin_login==loginTB.Text && n.admin_password == hashPassword))
                    {
                        AdminWindow admin = new AdminWindow();
                        admin.Show();
                        this.Close();
                            mark = false;
                        return;
                    }


                    
                    if (db.Users.Any(n => n.login == loginTB.Text && n.password!= hashPassword))
                    {
                        MessageBox.Show("Invalid password for this account");
                            mark = false;
                        return;
                    }
                }




                string sqlExpression = $"INSERT INTO Log_in (login, password)  VALUES ('{loginTB.Text}','{GetHashString(passTB.Password)}')";
                using (K_ProjectEntities db = new K_ProjectEntities())
                {

                    if (!db.Users.Any(p => p.login == loginTB.Text && p.password == hashPassword))
                    {
                        MessageBox.Show("This user does not exist");
                            mark = false;
                    }
                    else
                    {

                        if (db.Log_in.Any(p => p.login == loginTB.Text && p.password == hashPassword))
                        {
                            CurrentLogin = loginTB.Text;
                            MainWindow window = new MainWindow();
                            window.Show();
                            this.Close();
                                mark = false;
                        }
                        else
                        {
                            CurrentLogin = loginTB.Text;
                           db.Database.ExecuteSqlCommand(sqlExpression);

                            MainWindow window = new MainWindow();
                            window.Show();
                            this.Close();
                                mark = false;
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

        private void loginTB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.Tab)
            {
                e.Handled = true;
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

        private void passTB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.Tab)
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

        private void Close_Click(object sender, RoutedEventArgs e)
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
