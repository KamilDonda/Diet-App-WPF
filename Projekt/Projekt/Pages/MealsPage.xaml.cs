using Projekt.DAL.Entities;
using Projekt.DAL.Repositories;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Projekt.Pages
{
    public partial class MealsPage : Page
    {
        private static int? MealID = null;
        private static DAL.Entities.Meals MEAL;

        public MealsPage()
        {
            InitializeComponent();
            var mealsRepos = MealsRepos.GetAll();
            Meals_listview.ItemsSource = mealsRepos; 

            if(Login.LOGIN_STATUS)
                Meals_stackpanel.IsEnabled = true;       
        }

        private void Meals_Click(object sender, RoutedEventArgs e)
        {
            var index = (sender as ListView).SelectedIndex + 1;
            var ingredientsRepos = IngredientsRepos.GetByID(index);
            Ingredients_listview.ItemsSource = ingredientsRepos;

            if(Login.LOGIN_STATUS)
                Ingredient_stackpanel.IsEnabled = true;

            try
            {
                var selectedMeal = (sender as ListView).SelectedItem as DAL.Entities.Meals;
                if (selectedMeal != null && selectedMeal.ID > 34)
                {
                    MealID = Convert.ToInt32(selectedMeal.ID);
                    MEAL = selectedMeal;
                }

            }
            catch { }
        }

        private void Meal_button_Click(object sender, RoutedEventArgs e)
        {
            var name = MealName_textbox.Text;

            MealsRepos.Insert(new DAL.Entities.Meals(name, 0, 0, 0, 0, 0, "0"));
        }

        private void Ingredient_button_Click(object sender, RoutedEventArgs e)
        {
            if (MealID != null)
            {
                try
                {
                    var ingredientID = Convert.ToInt32(IngredientID_textbox.Text);
                    var ingredientWeight = Convert.ToDouble(IngredientWeight_textbox.Text);

                    ContainsRepos.Insert(new Contains(Convert.ToInt32(MealID), ingredientID, ingredientWeight));

                    MealsRepos.UpdateMeals();
                }
                catch { }
            }
        }

        private void NumberValidationInt(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.,]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
