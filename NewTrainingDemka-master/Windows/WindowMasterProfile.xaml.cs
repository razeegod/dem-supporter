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
    /// Логика взаимодействия для WindowMasterProfile.xaml
    /// </summary>
    public partial class WindowMasterProfile : Window
    {
        NewEntities db = NewEntities.GetContext();
        private readonly Users _curUser;
        public WindowMasterProfile(Users curUser) 
        {
            InitializeComponent();
            _curUser = curUser;

            foreach (var eq in db.Equipment)
            {
                lbEquipments.Items.Add(eq);
            }


            var applies = db.Applications.Where(a => a.MasterID == _curUser.UserID);
            foreach (var x in applies)
            {
                x.Equipment = db.Equipment.Find(x.EquipmentID);
            }
            lvApplications.ItemsSource = applies.ToList();

            tbFI.Text = _curUser.LastName + " " + _curUser.Name;
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = lbNoEquipments.SelectedItem;

            if (selectedItem != null)
            {
                lbNoEquipments.Items.Remove(selectedItem);
                lbEquipments.Items.Add(selectedItem);
            }
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = lbEquipments.SelectedItem;

            if (selectedItem != null)
            {
                lbEquipments.Items.Remove(selectedItem);
                lbNoEquipments.Items.Add(selectedItem);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var applies = db.Applications.Where(a => a.MasterID == _curUser.UserID);
            foreach(var x in applies)
            {
                x.Equipment = db.Equipment.Find(x.EquipmentID);
            }

            if (String.IsNullOrEmpty(tbSearch.Text))
            { lvApplications.ItemsSource = applies.ToList(); return; }

            lvApplications.ItemsSource = applies.Where(a => a.ApplicationID.ToString() == tbSearch.Text
            || a.Equipment.Title == tbSearch.Text
            || a.Defect == tbSearch.Text
            && a.MasterID == _curUser.UserID).ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            WindowAuthorization logOut = new WindowAuthorization();
            logOut.Show();
            this.Close();
        }

        private void CommentsButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = lvApplications.SelectedValuePath;
        }
    }
}
