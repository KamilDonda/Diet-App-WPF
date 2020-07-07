using Projekt.DAL;
using Projekt.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy RegisterPage.xaml
    /// </summary>
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

            Debug.WriteLine(
                $"\nLogin     {login}" +
                $"\nPassword  {password}" +
                $"\nConfirm   {confirmPassword}");

            LoginPage loginPage = new LoginPage();

            if (Login.IsPasswordCorrect(password, confirmPassword) &&
                Login.IsCorrectLogin(login))
            {
                hashPassword = Login.HashPassword(password);
                Debug.WriteLine($"Hash  {hashPassword}");

                try
                {
                    UsersRepos.CreateUser(login, hashPassword);
                    Debug.WriteLine("OK");
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
