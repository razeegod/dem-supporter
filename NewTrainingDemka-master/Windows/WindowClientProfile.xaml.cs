using NewTraining.Data;
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

namespace NewTraining.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowClientProfile.xaml
    /// </summary>
    public partial class WindowClientProfile : Window
    {
        NewEntities db = NewEntities.GetContext();
        Users currentUser = new Users();
        public WindowClientProfile(Users curUser)
        {
            InitializeComponent();

            currentUser = curUser;

            tbkLastName.Text = curUser.LastName;
            tbkName.Text = curUser.Name;

            GetCurrentApplies();
        }

        private void btnRegisterApplication_Click(object sender, RoutedEventArgs e)
        {
            WindowRegisterApplication windowRegister = new WindowRegisterApplication(currentUser);
            windowRegister.ShowDialog();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            WindowAuthorization goAuthorization = new WindowAuthorization();
            goAuthorization.Show();
            this.Close();
        }

        public void GetCurrentApplies()
        {
            var appliList = db.Applications.Where(a => a.UserID == currentUser.UserID && a.StatusID != 3).ToList();

            var _appliList = appliList.Join(db.Status.ToList(), a => a.StatusID, s => s.StatusID, (a, s) => new
            {
                ApplicationID = a.ApplicationID,
                StatusNew = s.Title,
                Defect = a.Defect,
                EquipmentID = a.EquipmentID
            });

            var retAppliList = _appliList.Join(db.Equipment.ToList(), a => a.EquipmentID, e => e.EquipmentID, (a, e) => new
            {
                Equipment = e.Title,
                ApplicationID = a.ApplicationID,
                StatusNew = a.StatusNew,
                Defect = a.Defect
            });

            lvApplications.ItemsSource = retAppliList;
        }
    }
}
