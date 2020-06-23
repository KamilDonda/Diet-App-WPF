using Projekt.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
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

namespace Projekt
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MouseDown += Window_MouseDown;
        }

        private List<Object> PageList = new List<Object>();
        private string url = $"https://github.com/KamilDonda/Projekt-Semestralny";

        #region Buttons

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            if (PageList.Count > 1)
            {
                PageList.Remove(Main.Content);
                Main.Content = PageList.ElementAt(PageList.Count - 1);
                
                label.Content = PageList.Count;
            }
        }

        private void Login_button_Click(object sender, RoutedEventArgs e)
        {
            PageList.Add(Main.Content);
            Main.Content = new LoginPage();
            label.Content = PageList.Count;
        }

        private void Ingredients_button_Click(object sender, RoutedEventArgs e)
        {
            PageList.Add(Main.Content);
            Main.Content = new IngredientsPage();
            label.Content = PageList.Count;
        }

        private void Meals_button_Click(object sender, RoutedEventArgs e)
        {
            PageList.Add(Main.Content);
            Main.Content = new MealsPage();
            label.Content = PageList.Count;
        }

        private void Diet_button_Click(object sender, RoutedEventArgs e)
        {
            PageList.Add(Main.Content);
            Main.Content = new DietPage();
            label.Content = PageList.Count;
        }

        private void Settings_button_Click(object sender, RoutedEventArgs e)
        {
            PageList.Add(Main.Content);
            Main.Content = new SettingsPage();
            label.Content = PageList.Count;
        }

        private void GitHub_button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
        }

        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Minimize_button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        #endregion

        #region Moving window

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        #endregion

    }
}
