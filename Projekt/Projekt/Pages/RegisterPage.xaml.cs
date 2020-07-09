using Projekt.DAL.Repositories;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Projekt.Pages
{
    public partial class RegisterPage : Page
    {
        private string login;
        private string password;
        private string confirmPassword;
        private string hashPassword;

        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Next_button_Click(object sender, RoutedEventArgs e)
        {
            login = Login_textbox.Text;
            password = Password_textbox.Password;
            confirmPassword = ConfirmPassword_textbox.Password;

            LoginPage loginPage = new LoginPage();

            if (Login.IsPasswordCorrect(password, confirmPassword) &&
                Login.IsCorrectLogin(login))
            {
                hashPassword = Login.HashPassword(password);
                try
                {
                    UsersRepos.CreateUser(login, hashPassword);
                }
                catch
                {
                    MessageBox.Show(Properties.Resources.errorCreateUser, Properties.Resources.warning);
                    return;
                }

                NavigationService.Navigate(loginPage);
            }
        }
    }
}
