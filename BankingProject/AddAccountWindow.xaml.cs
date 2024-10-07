using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
    /// Interaction logic for AddAccountWindow.xaml
    /// </summary>
    public partial class AddAccountWindow : Window
    {
        public AddAccountWindow()
        {
            InitializeComponent();
            this.DataContext = AccountConfig.VueModel;

        }
        public void WindowClose()
        {
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void CurrentRadioButton_Checked(object sender, RoutedEventArgs e)
        {

            AccountConfig.VueModel.NewAccount.AccType = (string)AccountConfig.newAccountWindow.CurrentRadioButton.Content;
        }

        private void SavingsRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            AccountConfig.VueModel.NewAccount.AccType = (string)AccountConfig.newAccountWindow.CurrentRadioButton.Content;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AccountConfig.VueModel.NewAccount.IsActive = true;
        }

       

      
    }
}
