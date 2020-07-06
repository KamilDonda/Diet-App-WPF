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
            get => IngredientsRepos.GetAll();
        }
        public List<Entities.Meals> Meals
        {
            get => MealsRepos.GetAll();
        }
    }
}
