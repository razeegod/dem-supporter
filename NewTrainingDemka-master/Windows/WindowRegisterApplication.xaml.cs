using NewTraining.Data;
using System;
using System.Linq;
using System.Windows;

namespace NewTraining.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowRegisterApplication.xaml
    /// </summary>
    public partial class WindowRegisterApplication : Window
    {
        Users currentUser = new Users();
        NewEntities db = NewEntities.GetContext();
        public WindowRegisterApplication(Users curUser)
        {
            InitializeComponent();
            currentUser = curUser;

            cmbEquipment.ItemsSource = db.Equipment.ToList();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRegisterApplication_Click(object sender, RoutedEventArgs e)
        {
            Applications application = new Applications
            {
                DatePosting = DateTime.Now.Date,
                UserID = currentUser.UserID,
                MasterID = 1,
                StatusID = 1,
                EquipmentID = (int)cmbEquipment.SelectedValue,
                Defect = tbDefect.Text,
                DefectDescription = tbDescription.Text
            };

            db.Applications.Add(application);
            db.SaveChanges();

            MessageBox.Show("Успех!", "Заявка оформлена успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
