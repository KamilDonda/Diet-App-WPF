using Projekt.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    static class MathOperations
    {
        public static double getBMI(double Height, double Weight)
            => Weight * 10000 / (Height * Height);

        public static int getBMR(double Height, double Weight, int Age, bool Sex)
        {
            var result = 10 * Weight + 6.25 * Height - 5 * Age + 5;

            if (!Sex)
                result -= 166;

            return (int)result;
        }

        public static int getTMR(int ActivityLevel, int BMR)
        {
            double k = 0;

            switch(ActivityLevel)
            {
                case 0:
                    k = 1.2; // very low or none
                    break;
                case 1:
                    k = 1.35; // low
                    break;
                case 2:
                    k = 1.5; // medium
                    break;
                case 3:
                    k = 1.725; // high
                    break;
                case 4:
                    k = 1.9; // very high
                    break;
            }

            return (int)(k * BMR);
}

        public static int getDailyCalories(int goal, int TMR)
        {
            if (goal == 0)
                return (int)(TMR * 0.9);
            if (goal == 2)
                return (int)(TMR * 1.1);
            return TMR;
        }

        public static DAL.Entities.Meals GetMostSimilarMeal(Meal x, List<DAL.Entities.Meals> ListOfMeals)
        {
            var P = new List<double>();
            var ListOfID = new List<int>();

            DAL.Entities.Meals meal = null;

            foreach (var y in ListOfMeals)
            {
                P.Add(GetDistance(x, y));
                ListOfID.Add(Convert.ToInt32(y.ID));
            }

            var sortedList = SortedList(ListOfID, P);

            foreach (var y in ListOfMeals)
            {
                if(y.ID == sortedList[0])
                {
                    meal = y;
                    break;
                }
            }

            return meal;

        }

        private static double GetDistance(Meal x, DAL.Entities.Meals y)
            =>  Math.Sqrt(
                Math.Pow(x.Carbs - Convert.ToDouble(y.Carbs), 2) +
                Math.Pow(x.Fat - Convert.ToDouble(y.Fat), 2) +
                Math.Pow(x.Kcal - Convert.ToDouble(y.Kcal), 2) +
                Math.Pow(x.Proteins - Convert.ToDouble(y.Protein), 2));

        private static List<int> SortedList(List<int> listToSort, List<double> p)
        {
            int n = p.Count;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (p[j] > p[j + 1])
                    {
                        var temp = p[j];
                        var Temp = listToSort[j];

                        p[j] = p[j + 1];
                        listToSort[j] = listToSort[j + 1];

                        p[j + 1] = temp;
                        listToSort[j + 1] = Temp;
                    }
            return listToSort;
        }

    }
}
