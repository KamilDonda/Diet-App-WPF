using System;
using Projekt.DAL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using Projekt.DAL.Entities;
using Projekt.DAL.Repositories;

namespace Projekt.Pages
{
    public partial class SettingsPage : Page
    {
        #region Properties

        public string Name       { get; set; }
        public string Surname    { get; set; }
        public bool Sex          { get; set; } // true = man | false = woman
        public uint Age          { get; set; }
        public double Height     { get; set; }
        public double Weight     { get; set; }
        public uint ActivityLevel { get; set; } // 0, 1, 2, 3, 4
        public uint Goal         { get; set; } // 0, 1, 2
        public uint DietType     { get; set; } // 0, 1, 2
        public uint MealCount    { get; set; } // 2, 3, 4, 5
        public double BMI        { get; set; }
        public int BMR           { get; set; }
        public int TMR           { get; set; }
        public int DailyCalories { get; set; }

        private static List<string> listOfActivities()
        {
            List<string> list = new List<string>();

            list.Add(Properties.Resources.activityLevel0);
            list.Add(Properties.Resources.activityLevel1);
            list.Add(Properties.Resources.activityLevel2);
            list.Add(Properties.Resources.activityLevel3);
            list.Add(Properties.Resources.activityLevel4);

            return list;
        }
        private static List<string> listOfGoals()
        {
            List<string> list = new List<string>();

            list.Add(Properties.Resources.goal0);
            list.Add(Properties.Resources.goal1);
            list.Add(Properties.Resources.goal2);

            return list;
        }
        private static List<int>    countOfMeals()
            => new List<int> { 2, 3, 4, 5 };

        #endregion

        public SettingsPage()
        {
            InitializeComponent();
            ActivityLevel_combobox.ItemsSource = listOfActivities();
            Goal_combobox.ItemsSource          = listOfGoals();
            MealsCount_combobox.ItemsSource    = countOfMeals();

            SetData();
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Name = Name_textbox.Text;
                Surname = Surname_textbox.Text;
                Sex = SexCheck;
                Age = Convert.ToUInt32(Age_textbox.Text);
                Height = Convert.ToDouble(Height_textbox.Text.Replace('.', ','));
                Weight = Convert.ToDouble(Weight_textbox.Text.Replace('.', ','));
                ActivityLevel = Convert.ToUInt32(ActivityLevel_combobox.SelectedIndex);
                Goal = Convert.ToUInt32(Goal_combobox.SelectedIndex);
                DietType = Convert.ToUInt32(DietCheck());
                MealCount = Convert.ToUInt32(MealsCount_combobox.SelectedItem);
                BMI = MathOperations.getBMI(Height, Weight);
                BMR = MathOperations.getBMR(Height, Weight, Convert.ToInt32(Age), Sex);
                TMR = MathOperations.getTMR(Convert.ToInt32(ActivityLevel), BMR);
                DailyCalories = MathOperations.getDailyCalories(Convert.ToInt32(Goal), TMR);

                BMI_textblock.Text = BMI.ToString("0.##");
                BMR_textblock.Text = BMR.ToString();
                TMR_textblock.Text = TMR.ToString();
                DailyCalories_textblock.Text = DailyCalories.ToString();

                Meals meals = new Meals(Convert.ToInt32(MealCount), DailyCalories, 
                    Convert.ToInt32(DietType), Convert.ToInt32(Goal), Weight);

                uint sex;
                if (Sex)
                    sex = 1;
                else
                    sex = 0;

                Users user = new Users(Login.UserLogin, Name, Surname, Age, Height, Weight, Goal, 
                    sex, ActivityLevel, DailyCalories, DietType, MealCount);

                UsersRepos.Update(user);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.errorEmptyDatas, Properties.Resources.warning);
            }
            show();
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

        private bool SexCheck 
            => man_radiobutton.IsChecked == true;

        private int DietCheck()
        {
            if (vegetarian_radiobutton.IsChecked == true)
                return 1;
            if (vegan_radiobutton.IsChecked == true)
                return 2;
            return 0;
        }

        private void show()
        {
            string s =
                $"\nName          {Name}" +
                $"\nSurname       {Surname}" +
                $"\nSex           {Sex}" +
                $"\nAge           {Age}" +
                $"\nHeight        {Height}" +
                $"\nWeight        {Weight}" +
                $"\nActivityLevel {ActivityLevel}" +
                $"\nGoal          {Goal}" +
                $"\nDietType      {DietType}" +
                $"\nMealCount     {MealCount}" +
                $"\nBMI           {BMI}" +
                $"\nBMR           {BMR}" +
                $"\nTMR           {TMR}" +
                $"\nDailyCalories {DailyCalories}";

            Debug.WriteLine(s);
        }

        private void SetData()
        {
            var UserList = UsersRepos.GetAll();

            Users User = null;

            foreach (var user in UserList)
            {
                if(Login.UserLogin == user.Login)
                {
                    User = new Users(user);
                    break;
                }
            }

            if(User != null)
            {
                Name_textbox.Text = User.Name;
                Surname_textbox.Text = User.Surname;
                Age_textbox.Text = User.Age.ToString();
                Height_textbox.Text = User.Height.ToString();
                Weight_textbox.Text = User.Weight.ToString();
                DailyCalories_textblock.Text = User.Kcal.ToString();
                MealsCount_combobox.SelectedItem = Convert.ToInt32(User.MealsCount);
                ActivityLevel_combobox.SelectedIndex = Convert.ToInt32(User.ActivityLevel);
                Goal_combobox.SelectedIndex = Convert.ToInt32(User.Goal);

                if (User.Sex == 0)
                {
                    woman_radiobutton.IsChecked = true;
                    Sex = false;
                }
                if (User.Sex == 1)
                {
                    man_radiobutton.IsChecked = true;
                    Sex = true;
                }

                if (User.DietType == 0)
                    normal_radiobutton.IsChecked = true;
                if (User.DietType == 1)
                    vegetarian_radiobutton.IsChecked = true;
                if (User.DietType == 2)
                    vegan_radiobutton.IsChecked = true;

                Height = Convert.ToDouble(User.Height);
                Weight = Convert.ToDouble(User.Weight);
                Age = Convert.ToUInt32(User.Age);
                ActivityLevel = Convert.ToUInt32(User.ActivityLevel);

                BMI = MathOperations.getBMI(Height, Weight);
                BMR = MathOperations.getBMR(Height, Weight, Convert.ToInt32(Age), Sex);
                TMR = MathOperations.getTMR(Convert.ToInt32(ActivityLevel), BMR);

                BMI_textblock.Text = BMI.ToString("0.##");
                BMR_textblock.Text = BMR.ToString();
                TMR_textblock.Text = TMR.ToString();

                Login.CurrentUser = User;
            }

        }
    }
}
