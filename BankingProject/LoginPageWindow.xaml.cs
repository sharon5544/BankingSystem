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
    /// Interaction logic for LoginPageWindow.xaml
    /// </summary>
    public partial class LoginPageWindow : Window
    {
        public LoginPageWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "neha" && txtPassword.Password == "2001")
            {
                AccountConfig.dashBoardWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(messageBoxText: $"Invalid username or password",
                   caption: "Warning",
                   button: MessageBoxButton.OK,
                   icon: MessageBoxImage.Warning);
                return;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
