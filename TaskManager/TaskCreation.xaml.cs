using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using TaskManager.myDB;

namespace TaskManager
{

    public partial class TaskCreation : Window
    {
        private string selectedValue;
        public TaskCreation()
        {
            InitializeComponent();
        }

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {

           
            myDB.Task newTask = new myDB.Task();
            if (catCB.Text == "")
                catCB.SelectedItem = def;  
            newTask.category = catCB.Text;

            if (datePR.SelectedDate == null)
                newTask.compleateDate = DateTime.Now;
            else
            newTask.compleateDate = (DateTime)datePR.SelectedDate;
         if(taskTB.Text=="")
            {
                MessageBox.Show("You must fill in the task field");
                return;
            }
            newTask.taskText = taskTB.Text;
            if (selectedValue == null)
                newTask.priority = 1;
            else
            newTask.priority = Convert.ToInt32(selectedValue);
            newTask.done = false;

            
            newTask.login = Authorization.CurrentLogin;
            if (timeCB.Text == "")
            {
                using (K_ProjectEntities db = new K_ProjectEntities())
                {
                    MainWindow.AddNewTask(newTask);
                    db.Tasks.Add(newTask);
                    db.SaveChanges();


                }
            }
           else
            {
                newTask.taskTime = timeCB.Text;
                MainWindow.AddNewTask(newTask);
            }
            
            
            
            this.Close();
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
                selectedValue = item.Content.ToString();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            datePR.BlackoutDates.AddDatesInPast();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        

        private void datePR_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
            foreach (var item in MainWindow.GridInfo)
            {
                if (item.taskTime != null)
                    return;
            }

            if(((DateTime)datePR.SelectedDate).ToString("d")==DateTime.Now.ToString("d"))
            {
                timeLL.Visibility = Visibility.Visible;
                timeLL_Copy.Visibility = Visibility.Visible;
                timeLLmin.Visibility = Visibility.Visible;
                timeCB.Visibility = Visibility.Visible;
            }
            else
            {
                timeLL.Visibility = Visibility.Hidden;
                timeLLmin.Visibility = Visibility.Hidden;
                timeCB.Visibility = Visibility.Hidden;
                timeLL_Copy.Visibility = Visibility.Hidden;
            }
        }
        public static bool mark = false;
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {

            

            DispatcherTimer _timer=null;
            TimeSpan _time;
       
            if (timeCB.Text != "")
            {
               

                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).my_img.Visibility = Visibility.Visible;
                    }
                }
                ActivateTimer();
                
            }

            void ActivateTimer()
            {

            _time = TimeSpan.FromMinutes(int.Parse(timeCB.Text));
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                int index = MainWindow.GridInfo.Count - 1;
                if (mark)
                {
                    _timer.Stop();
                    if (MainWindow.GridInfo.Count == 0)
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                (window as MainWindow).my_img.Visibility = Visibility.Hidden;
                            }
                        }
                        mark = false;
                        return;
                    }
                    else
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                (window as MainWindow).my_img.Visibility = Visibility.Hidden;
                            }
                        }
                        MainWindow.GridInfo.RemoveAt(index);
                        mark = false;
                        return;
                    }
                }

                if(MainWindow.GridInfo[index].done==true)
                {
                    _timer.Stop();
                    MessageBox.Show("Hooray! You have time!");
                    MainWindow.GridInfo.RemoveAt(index);
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).my_img.Visibility = Visibility.Hidden;
                        }
                    }
                    mark = false;
                    return;
                }
                MainWindow.GridInfo[index].taskTime = _time.ToString("c");
                myDB.Task t = MainWindow.GridInfo[index];
               MainWindow.GridInfo.RemoveAt(index);

                MainWindow.GridInfo.Add(t);
                if (_time == TimeSpan.Zero)
                {
                    
                    _timer.Stop();
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).my_img.Visibility = Visibility.Hidden;
                        }
                    }
                    MessageBox.Show("You did not have time to complete the task");
                    MainWindow.GridInfo.RemoveAt(index);
                    mark = false;
                    

                }

                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();

            }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
