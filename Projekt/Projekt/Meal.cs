using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Projekt
{
    class Meal
    {
        //macronutrients
        public double Proteins     { get; private set; }
        public double Carbs        { get; private set; }
        public double Fat          { get; private set; }
        public double Kcal         { get; private set; }
        public double TotalGrams   { get; private set; }

        public Meal(int dietType, double proteins, double fat, double carbs)
        {
            this.Proteins = proteins;
            this.Fat = fat;
            this.Carbs = carbs;
            this.TotalGrams = Proteins + Fat + Carbs;
            this.Kcal = Proteins * 4 + Fat * 9 + Carbs * 4;

            Debug.WriteLine(
                $"\nProteins  {Proteins.ToString("0.##")} g = {(Proteins * 4).ToString("0.##")} Kcal" +
                $"\nFat       {Fat.ToString("0.##")} g = {(Fat * 9).ToString("0.##")} Kcal" +
                $"\nCarbs     {Carbs.ToString("0.##")} g = {(Carbs * 4).ToString("0.##")} Kcal" +
                $"\nTotalgram {TotalGrams.ToString("0.##")} g = {Kcal.ToString("0.##")} Kcal");
        }
    }
}
