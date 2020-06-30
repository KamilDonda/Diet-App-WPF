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

            SettingsPage settingsPage = new SettingsPage();

            if (Login.IsPasswordCorrect(password, confirmPassword) &&
                Login.IsCorrectLogin(login))
            {
                var hash = Login.HashPassword(password);
                Debug.WriteLine($"Hash  {hash}");

                NavigationService.Navigate(settingsPage);
            }
        }
    }
}
