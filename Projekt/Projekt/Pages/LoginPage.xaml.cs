using Projekt.DAL;
using Projekt.Pages;
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


namespace Projekt
{
    public partial class LoginPage : Page
    {
        private string login;
        private string password;

        public LoginPage()
        {
            InitializeComponent();
            DBConnection.AdminLogin();
        }

        private void Next_button_Click(object sender, RoutedEventArgs e)
        {
            login = Login_textbox.Text;
            password = Password_textbox.Password;

            var hash = Login.HashPassword(password);
            var hashFromDB = Login.GetPassword(login);

            Debug.WriteLine(
                $"\nLogin     {login}" +
                $"\nPassword  {password}" +
                $"\nHash      {hash}" +
                $"\nHashDB    {hashFromDB}");

            SettingsPage newPage = new SettingsPage();

            if (Login.CheckPasswords(hash, hashFromDB))
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                        (window as MainWindow).SetVisibilityOn();
                }

                Login.LOGIN_STATUS = true;
                Login.UserLogin = login;

                NavigationService.Navigate(newPage);
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            NavigationService.Navigate(registerPage);
        }
    }
}
