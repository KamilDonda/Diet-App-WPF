using Projekt.DAL.Repositories;
using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy IngredientsPage.xaml
    /// </summary>
    public partial class IngredientsPage : Page
    {
        private static List<string> listOfDietType()
        {
            List<string> list = new List<string>();

            list.Add(Properties.Resources.normal);
            list.Add(Properties.Resources.vegetarian);
            list.Add(Properties.Resources.vegan);

            return list;
        }

        public IngredientsPage()
        {
            InitializeComponent();
            var ingredientsRepos = IngredientsRepos.GetAllIngredients();
            Ingredients_listview.ItemsSource = ingredientsRepos;

            DietType_combobox.ItemsSource = listOfDietType();
        }
    }
}
