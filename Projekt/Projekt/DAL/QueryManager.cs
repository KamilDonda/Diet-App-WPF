using Projekt.DAL.Entities;
using Projekt.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL
{
    class QueryManager
    {
        public List<Ingredients> Ingredients
        {
            get => IngredientsRepos.GetAllIngredients();
        }
        public List<Meals> Meals
        {
            get => MealsRepos.GetAllMeals();
        }
    }
}
