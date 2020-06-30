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
            var result = 10 * Weight + 6.25 * Height - 5 * Age;

            if (Sex)
                result += 5;
            else
                result -= 161;

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
    }
}
