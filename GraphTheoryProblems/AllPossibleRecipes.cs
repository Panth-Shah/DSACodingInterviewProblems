using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    public class AllPossibleRecipes
    {
        private Dictionary<string, List<string>> ingredientRecipeMap = new Dictionary<string, List<string>>();
        private Dictionary<string, int> recipeIndegree = new Dictionary<string, int>();
        private Dictionary<string, int> ingredientRecipeIndexMap = new Dictionary<string, int>();
        private IList<string> result = new List<string>();
        private HashSet<string> recipeSet = new HashSet<string>();
        public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
        {
            //Build graph which will map all the recipes with it's respective ingredients
            for (int i = 0; i < recipes.Length; i++)
            {
                string recipe = recipes[i];
                List<string> ingredientList = (List<string>)ingredients[i];

                foreach (string ingredient in ingredientList)
                {
                    ingredientRecipeMap.TryAdd(ingredient, new List<string>());
                    ingredientRecipeMap[ingredient].Add(recipe);
                    ingredientRecipeIndexMap.TryAdd(ingredient, i);
                }
                //Number of incoming will be equal to the size of ingredientList
                recipeIndegree.TryAdd(recipe, ingredientList.Count());
                recipeSet.Add(recipe);
            }

            //Adding all the values for suppiles in the q which are not in the ingredientIndegree map because if the 
            //entry is in the incoming map they have dependencies and cannot be created just yet.
            //Also checking if the supply is listed in the ingredient map if not we will never use it.
            Queue<string> queue = new Queue<string>();

            foreach (string supply in supplies)
            {
                if (ingredientRecipeMap.ContainsKey(supply))
                {
                    queue.Enqueue(supply);
                }
            }

            while (queue.Count > 0)
            {
                int size = queue.Count();
                string type = queue.Dequeue();
                if (recipeSet.Contains(type))
                {
                    result.Add(type);
                }

                if (ingredientRecipeMap.ContainsKey(type))
                {
                    List<string> nextTypeSet = ingredientRecipeMap[type];
                    foreach (string nextType in nextTypeSet)
                    {
                        if (recipeIndegree.ContainsKey(nextType))
                        {
                            if (recipeIndegree[nextType] != 1)
                            {
                                recipeIndegree.Remove(nextType);
                                queue.Enqueue(nextType);
                            }
                            else
                            {
                                recipeIndegree[nextType] -= 1;
                            }
                        }
                    }
                }

            }

            return result;
        }
    }
}
