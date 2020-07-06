using Projekt.DAL.Entities;
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
            var ingredientsRepos = IngredientsRepos.GetAll();
            Ingredients_listview.ItemsSource = ingredientsRepos;

            DietType_combobox.ItemsSource = listOfDietType();
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            string name = Name_textbox.Text;
            double kcal = Convert.ToDouble(Kcal_textbox.Text.Replace('.', ','));
            double protein = Convert.ToDouble(Protein_textbox.Text.Replace('.', ','));
            double fat = Convert.ToDouble(Fat_textbox.Text.Replace('.', ','));
            double carbs = Convert.ToDouble(Carbs_textbox.Text.Replace('.', ','));
            string type = DietType_combobox.SelectedIndex.ToString();

            var newIngredient = new Ingredients(name, kcal, protein, fat, carbs, type);

            IngredientsRepos.Insert(newIngredient);
        }
    }
}
