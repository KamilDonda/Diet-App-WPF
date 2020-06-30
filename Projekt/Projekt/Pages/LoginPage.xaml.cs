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
        }

        private void Next_button_Click(object sender, RoutedEventArgs e)
        {
            login = Login_textbox.Text;
            password = Password_textbox.Password;

            Debug.WriteLine(
                $"\nLogin     {login}" +
                $"\nPassword  {password}");

            // zmienić na główną stronę, ale ona jeszcze nie istnieje xd
            SettingsPage newPage = new SettingsPage();

            var hash = Login.HashPassword(password);
            //var hashFromDB = ;                               // <---- Hasło z bazy danych

            //if(Login.CheckPasswords(hash, hashFromDB))
                NavigationService.Navigate(newPage);
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            NavigationService.Navigate(registerPage);
        }
    }
}
