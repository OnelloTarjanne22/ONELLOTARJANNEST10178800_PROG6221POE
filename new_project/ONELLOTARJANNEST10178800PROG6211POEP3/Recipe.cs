using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace ONELLOTARJANNEST10178800PROG6211POEP3
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
        public bool IsCleared { get; set; }

        public static List<Recipe> Recipes { get; } = new List<Recipe>();

        public Recipe(string name, List<Ingredient> ingredients, List<Step> steps)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
        }

        public void ResetQuantity()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.ResetQuantity();
            }
        }
        //Method to scale selected recipe

        public void ScaleRecipe(double factor)
        {
            if (factor <= 0)
            {
                throw new ArgumentException("Invalid factor. Please enter a positive number.");
            }

            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public int TotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories);
        }

        public string GetFormattedIngredients()
        {
            return string.Join(", ", Ingredients.Select(i => $"{i.Quantity} {i.Unit} {i.Name} ({i.FoodGroup}, {i.Calories} cal)"));
        }

        public string GetFormattedSteps()
        {
            return string.Join(", ", Steps.Select((s, index) => $"{index + 1}. {s.Description}"));
        }


        public static List<RecipeDetail> GetAllRecipesDetails()
        {
            return Recipes
                .OrderBy(recipe => recipe.Name)
                .Select(recipe => new RecipeDetail
                {
                    RecipeName = recipe.Name,
                    Ingredients = recipe.GetFormattedIngredients(),
                    Steps = recipe.GetFormattedSteps(),
                    TotalCalories = recipe.TotalCalories()
                }).ToList();
        }
        public static void DisplayAllRecipes(ListView recipeListView)
        {
            var sortedRecipes = GetAllRecipesDetails();
            recipeListView.ItemsSource = sortedRecipes;

            if (sortedRecipes.Count == 0)
            {
                MessageBox.Show("No recipes available to view.");
            }
        }


        //Method to clear all the recipes
        public static void ClearAllRecipes(ListView recipeListView)
        {
            if (Recipes.Count == 0)
            {
                MessageBox.Show("No recipes available to clear.");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Are you sure you want to clear all recipes?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Recipes.Clear();
                recipeListView.ItemsSource = null;
                MessageBox.Show("All recipes have been cleared.");
            }
        }


        //Method to search using the filters
      public static void ApplyFilters(ListView recipeListView, string ingredientName, string foodGroup, int maxCalories)
{
    var filteredRecipes = Recipes.Where(recipe =>
        (string.IsNullOrEmpty(ingredientName) || recipe.Ingredients.Any(i => i.Name.ToLower().Contains(ingredientName))) &&
        (foodGroup == "All" || recipe.Ingredients.Any(i => i.FoodGroup == foodGroup)) &&
        (maxCalories == 0 || recipe.TotalCalories() <= maxCalories)
    )
    .OrderBy(recipe => recipe.Name)  // Sorts the filtered recipes by name
    .Select(recipe => new RecipeDetail
    {
        RecipeName = recipe.Name,
        Ingredients = recipe.GetFormattedIngredients(),
        Steps = recipe.GetFormattedSteps(),
        TotalCalories = recipe.TotalCalories()
    })
    .ToList();

    recipeListView.ItemsSource = filteredRecipes;

    if (filteredRecipes.Count == 0)
    {
        MessageBox.Show("No recipes match the filter criteria.");
    }
}

        //Method to clear specific recipe using selection in dropdown
        public static void DeleteRecipe(string recipeName)
        {
            Recipe recipeToDelete = Recipes.FirstOrDefault(r => r.Name == recipeName);
            if (recipeToDelete != null)
            {
                Recipes.Remove(recipeToDelete);
            }
        }
    }

}
