using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Projekt
{
    class Meal
    {
        //macronutrients
        public int Proteins { get; private set; }
        public int Carbs { get; private set; }
        public int Fat { get; private set; }
        public int Kcal { get; private set; }
        public int TotalGrams { get; private set; }

        public Meal(int dietType, double proteins, double fat, double carbs)
        {
            this.Proteins = (int)proteins;
            this.Fat = (int)fat;
            this.Carbs = (int)carbs;
            this.TotalGrams = Proteins + Fat + Carbs;
            this.Kcal = Proteins * 4 + Fat * 9 + Carbs * 4;

            Debug.WriteLine(
                $"\nProteins  {Proteins} g = {Proteins * 4} Kcal" +
                $"\nFat       {Fat} g = {Fat * 9} Kcal" +
                $"\nCarbs     {Carbs} g = {Carbs * 4} Kcal" +
                $"\nTotal     {TotalGrams} g = {Kcal} Kcal");
        }
    }
}
