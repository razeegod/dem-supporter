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
    /// Логика взаимодействия для WindowCommentsList.xaml
    /// </summary>
    public partial class WindowCommentsList : Window
    {
        private readonly Application _curAppli;
        public WindowCommentsList(Application curAppli)
        {
            InitializeComponent();
            _curAppli = curAppli;
        }
    }
}
