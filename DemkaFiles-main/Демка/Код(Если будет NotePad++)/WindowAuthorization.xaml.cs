using NewTraining.Data;
using NewTraining.Windows;
using System;
using System.Linq;
using System.Windows;

namespace NewTraining
{
    /// <summary>
    /// Логика взаимодействия для WindowAuthorization.xaml
    /// </summary>
    public partial class WindowAuthorization : Window
    {
        NewEntities db = NewEntities.GetContext();
        public WindowAuthorization()
        {
            InitializeComponent();
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            //ПРОВЕРКА ПОЛЕЙ НА ПУСТЫЕ ЗНАЧЕНИЯ\\
            if(String.IsNullOrEmpty(tbLogin.Text) || String.IsNullOrEmpty(tbPassword.Text))
            { MessageBox.Show("Нужно заполнить все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            //ПРОВЕРКА ПОЛЕЙ НА ПУСТЫЕ ЗНАЧЕНИЯ\\


            var curUser = db.Users.Where(u => u.Login == tbLogin.Text && u.Password == tbPassword.Text).FirstOrDefault();

            if(db.Users.Any(u=>u.Login == curUser.Login && u.Password == curUser.Password))
            {
                if (db.Roles.Where(r=>r.Title == "Пользователь")
                    .FirstOrDefault().RoleID == curUser.RoleID)
                {
                    WindowClientProfile windowClient = new WindowClientProfile(curUser);
                    windowClient.Show();
                    this.Close();
                }
                else if (db.Roles.Where(r => r.Title == "Администратор")
                    .FirstOrDefault().RoleID == curUser.RoleID)
                {
                    WindowCheckRole window = new WindowCheckRole("Администратор");
                    window.Show();
                    this.Close();
                }
                else if (db.Roles.Where(r => r.Title == "Мастер")
                    .FirstOrDefault().RoleID == curUser.RoleID)
                {
                    WindowCheckRole window = new WindowCheckRole("Мастер");
                    window.Show();
                    this.Close();
                }

            }
            else { MessageBox.Show("Неверные учетные данные", "Ошибка аторизации", MessageBoxButton.OK, MessageBoxImage.Error); return; }
        }
    }
}
