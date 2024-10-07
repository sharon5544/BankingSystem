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

namespace BankingProject
{
    /// <summary>
    /// Interaction logic for DashBoardWindow.xaml
    /// </summary>
    public partial class DashBoardWindow : Window
    {
        public DashBoardWindow()
        {
            InitializeComponent();
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            AccountConfig.depositWindow.Show();
        }

       

        private void btnManager_Click(object sender, RoutedEventArgs e)
        {
            AccountConfig.accountListWindow.Show();
        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            AccountConfig.withdrawWindow.Show();
        }

        private void Window_Closed_1(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
