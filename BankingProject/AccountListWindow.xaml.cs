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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankingProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AccountListWindow : Window
    {
        public AccountListWindow()
        {
            InitializeComponent();
            this.DataContext = AccountConfig.VueModel;

        }

        

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AccountConfig.newAccountWindow.Show();
            AddAccountWindow newAccountWindow = (AddAccountWindow)AccountConfig.newAccountWindow;
            AccountConfig.VueModel.NewWindowClose = newAccountWindow.WindowClose;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (grdAccounts.SelectedIndex == -1) 
            {
                var result = MessageBox.Show(messageBoxText: "Are you sure to update?",
                    caption: "Confirm",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Information);
                return;
            }
            AccountConfig.editAccountWindow.Show();

            EditAccountWindow newEditWindow = (EditAccountWindow)AccountConfig.editAccountWindow;
            AccountConfig.VueModel.EditWindowClose = newEditWindow.WindowClose;

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {

            if (grdAccounts.SelectedIndex == -1)
            {
                var result = MessageBox.Show(messageBoxText: "Please select an account",
                    caption: "Alert",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Information);
                return;
            }
            AccountConfig.accountViewWindow.Show();
        }
    }
}
