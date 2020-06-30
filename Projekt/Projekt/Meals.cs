using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class Meals
    {
        private static double[][] mealsMatrix = new double[][]
        {
            new double[]{ 0.5, 0.5 },
            new double[]{ 0.3, 0.45, 0.25 },
            new double[]{ 0.25, 0.2, 0.3, 0.25 },
            new double[]{ 0.2, 0.15, 0.3, 0.15, 0.2 }
        };

        public List<Meal> ListOfMeals { get; private set; } = new List<Meal>();

        public Meals(int mealCount, int calories, int dietType, int goal)
        {
            int[] arr = calorieArray(mealCount, calories);

            for (int i = 0; i < mealCount; i++)
                ListOfMeals.Add(new Meal(arr[i], dietType, goal));
            
        }

        private int []calorieArray(int mealCount, int calories)
        {
            var arr = new int[mealCount];

            var n = mealCount - 2;

            for (int i = 0; i < mealCount; i++)
                arr[i] = (int)(mealsMatrix[n][i] * calories);

            return arr;
        }
    }
}
