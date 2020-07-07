using Projekt.DAL.Entities;
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
    /// Logika interakcji dla klasy MealsPage.xaml
    /// </summary>
    public partial class MealsPage : Page
    {
        public MealsPage()
        {
            InitializeComponent();
            var mealsRepos = MealsRepos.GetAll();
            Meals_listview.ItemsSource = mealsRepos; 
        }

        private void Meals_Click(object sender, RoutedEventArgs e)
        {
            var index = (sender as ListView).SelectedIndex + 1;
            var ingredientsRepos = IngredientsRepos.GetByID(index);
            Ingredients_listview.ItemsSource = ingredientsRepos;

            //double Kcal = 0;
            //double Prot = 0;
            //double Fat = 0;
            //double Carbs = 0;
            //double Weight = 0;

            //for (int i = 0; i < ingredientsRepos.Count; i++)
            //{
            //    Kcal += ingredientsRepos[i].Kcal;
            //    Prot += ingredientsRepos[i].Protein;
            //    Fat += ingredientsRepos[i].Fat;
            //    Carbs += ingredientsRepos[i].Carbs;
            //    Weight += ingredientsRepos[i].Weight;
            //}

            //Debug.WriteLine($"{Kcal}, {Prot}, {Fat}, {Carbs}, {Weight}");
        }

        
    }
}
