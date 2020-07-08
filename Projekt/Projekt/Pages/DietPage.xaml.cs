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
    /// Logika interakcji dla klasy DietPage.xaml
    /// </summary>
    public partial class DietPage : Page
    {
        public DietPage()
        {
            InitializeComponent();
        }

        private void GenerateMeals_button_Click(object sender, RoutedEventArgs e)
        {
            Users user = Login.CurrentUser;

            Debug.WriteLine(user);

            var mealsCount = Convert.ToInt32(user.MealsCount);
            var dailyCalories = Convert.ToDouble(user.Kcal);
            var dietType = Convert.ToInt32(user.DietType);
            var goal = Convert.ToInt32(user.Goal);
            var weight = Convert.ToDouble(user.Weight);

            Meals meals = new Meals(mealsCount, dailyCalories,
                   dietType, goal, weight);

            //var ListOfMeal = MealsRepos.GetAll();

            //foreach (var meal in ListOfMeal)
            //{
            //    Debug.WriteLine(meal);
            //}

            //meals.ListOfMeals.Add(new Meal(0, 10, 10, 10));
            //meals.ListOfMeals.Add(new Meal(0, 0, 50, 100));
            var oneDay = meals.ListOfMeals;

            Debug.WriteLine("\n\n");
            var ListOfMeals = MealsRepos.GetAll();
            foreach (var meal in oneDay)
            {
                var result = MathOperations.GetMostSimilarMeal(meal, ListOfMeals);
                Debug.WriteLine(meal);
                Debug.WriteLine(result);
            }
            
        }
    }
}
