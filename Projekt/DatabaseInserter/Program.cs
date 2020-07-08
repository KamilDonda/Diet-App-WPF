using MySql.Data.MySqlClient;
using System;
using Projekt.DAL.Entities;
using Projekt.DAL.Repositories;
using System.IO;
using System.Linq;

namespace DatabaseInserter
{
    class Program
    {
        static void Main(string[] args)
        {
            string ingredients = @"C:\Users\donda\Desktop\Ingredients.txt";
            string meals = @"C:\Users\donda\Desktop\Meals.txt";
            string contains = @"C:\Users\donda\Desktop\Contains.txt";

            //SetIngredients(ingredients);
            //SetMeals(meals);
            //SetContainers(contains);
            //UpdateMeals();
        }

        static void SetIngredients(string filename)
        {
            var lines = File.ReadAllLines(filename);
            for (var i = 0; i < lines.Length; i ++)
            {
                var line = lines[i];
                var value = line.Split(';');

                string name     = value[0];
                double kcal     = Convert.ToDouble(value[1].Replace('.', ','));
                double protein  = Convert.ToDouble(value[2].Replace('.', ','));
                double fat      = Convert.ToDouble(value[3].Replace('.', ','));
                double carbs    = Convert.ToDouble(value[4].Replace('.', ','));
                string type     = value[5];

                //Console.WriteLine($"{name};{kcal};{protein};{fat};{carbs};{type}");

                var newIngredient = new Ingredients(name, kcal, protein, fat, carbs, type);

                Console.WriteLine($"{i}.");

                IngredientsRepos.Insert(newIngredient);
            }
        }

        static void SetMeals(string filename)
        {
            var lines = File.ReadAllLines(filename);

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                //var value = line.Split(';');

                string name = line;
                Console.WriteLine(name);
                //string name = value[0];
                //double weight = Convert.ToDouble(value[1].Replace('.', ','));
                //double kcal = Convert.ToDouble(value[2].Replace('.', ','));
                //double protein = Convert.ToDouble(value[3].Replace('.', ','));
                //double fat = Convert.ToDouble(value[4].Replace('.', ','));
                //double carbs = Convert.ToDouble(value[5].Replace('.', ','));
                //string type = value[6];

                var newMeal = new Meals(name/*, weight, kcal, protein, fat, carbs, type*/);

                Console.WriteLine($"{i}.");

                MealsRepos.Insert(newMeal);
            }
        }

        static void SetContainers(string filename)
        {
            var lines = File.ReadAllLines(filename);

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var value = line.Split(';');

                int id_meals = Convert.ToInt32(value[0]);
                int id_ingredients = Convert.ToInt32(value[1]);
                double weight = Convert.ToDouble(value[2].Replace('.', ','));

                var newContain = new Contains(id_meals, id_ingredients, weight);

                Console.WriteLine($"{i}.");

                ContainsRepos.Insert(newContain);
            }
        }

        static void UpdateMeals()
        {
            var mealsRepos = MealsRepos.GetAll();

            foreach(var meal in mealsRepos)
            {
                var ingredientsRepos = IngredientsRepos.GetByID(meal.ID.Value);

                int n = ingredientsRepos.Count;

                int? ID = meal.ID;
                string Name = meal.Name;
                double Kcal = 0;
                double Prot = 0;
                double Fat = 0;
                double Carbs = 0;
                double Weight = 0;
                int[] Type = new int[n];

                Console.WriteLine($"Meal no. {meal.ID.Value} - {Name}");

                for (int j = 0; j < n; j++)
                {
                    var weight = ingredientsRepos[j].Weight;

                    Kcal += ingredientsRepos[j].Kcal * weight * 0.01;
                    Prot += ingredientsRepos[j].Protein * weight * 0.01;
                    Fat += ingredientsRepos[j].Fat * weight * 0.01;
                    Carbs += ingredientsRepos[j].Carbs * weight * 0.01;
                    Weight += ingredientsRepos[j].Weight;

                    var t = ingredientsRepos[j].Type;

                    if (t == Projekt.Properties.Resources.normal)
                        Type[j] = 0;
                    if (t == Projekt.Properties.Resources.vegetarian)
                        Type[j] = 1;
                    if (t == Projekt.Properties.Resources.vegan)
                        Type[j] = 2;
                    
                    //Console.WriteLine(Type[j]);
                }
                var type = Type.Min().ToString();

                //Console.WriteLine($"min: {type}");

                var newMeal = new Meals(Name, Weight, Kcal, Prot, Fat, Carbs, type);

                MealsRepos.Update(newMeal, ID);
            }
        }
    }
}
