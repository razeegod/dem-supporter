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
    /// Логика взаимодействия для WindowCheckRole.xaml
    /// </summary>
    public partial class WindowCheckRole : Window
    {
        public WindowCheckRole(string role)
        {
            InitializeComponent();

            tbkRole.Text = role;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowAuthorization goAuthorization = new WindowAuthorization();
            goAuthorization.Show();
            this.Close();
        }
    }
}
