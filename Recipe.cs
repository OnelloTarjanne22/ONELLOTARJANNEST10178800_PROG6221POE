using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ONELLOTARJANNEST10178800PROG6211POEP1
{
    public delegate void CalorieWarningDelegate(string message);

    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
        public bool IsCleared { get; set; }
        public static event CalorieWarningDelegate CalorieWarning;


        public static List<Recipe> Recipes { get; } = new List<Recipe>();

        public Recipe(string name, List<Ingredient> ingredients, List<Step> steps)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
        }
        //Adds the recipe to app
        public static Recipe AddNewRecipe()
        {
            Console.Write("Recipe name: ");
            string recipeName = Console.ReadLine();

            Console.Write("Number of ingredients: ");
            int numIngredients;
            while (!int.TryParse(Console.ReadLine(), out numIngredients))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            List<Ingredient> ingredients = new List<Ingredient>();
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"\nIngredient {i + 1}:");
                Console.Write("Name: ");
                string ingredientName = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity;
                while (!double.TryParse(Console.ReadLine(), out quantity))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                Console.Write("Unit: ");
                string unit = Console.ReadLine();
                Console.Write("Calories: ");
                int calories;
                while (!int.TryParse(Console.ReadLine(), out calories))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                Console.Write("Food Group: ");
                string foodGroup = Console.ReadLine();

                ingredients.Add(new Ingredient(ingredientName, quantity, unit, calories, foodGroup));
            }

            Console.Write("\nNumber of steps: ");
            int numSteps;
            while (!int.TryParse(Console.ReadLine(), out numSteps))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            List<Step> steps = new List<Step>();
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"\nStep {i + 1}:");
                Console.Write("Description: ");
                string description = Console.ReadLine();
                steps.Add(new Step(description));
            }

            Recipe newRecipe = new Recipe(recipeName, ingredients, steps);
            Recipes.Add(newRecipe);
            return newRecipe;
        }



        // Resets the quantity of the recipe to the initial entered values

        public void ResetQuantity()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.ResetQuantity();
            }

            Console.WriteLine("\nQuantity reset successfully!");
            Console.WriteLine(this);
            Console.WriteLine("-----------------------------------------------");
        }


        //Scales up the selected Recipe
        public void ScaleRecipe(double factor)
        {
            if (factor <= 0)
            {
                Console.WriteLine("Invalid factor. Please enter a positive number.");
                return;
            }

            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }

            Console.WriteLine("\nRecipe scaled successfully!");
            Console.WriteLine(this);
            Console.WriteLine("-----------------------------------------------");
        }

        //Clears the recipes
        public static void ClearRecipe(string recipeName)
        {
            Recipe recipeToRemove = Recipes.Find(recipe => recipe.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipeToRemove != null)
            {
                Recipes.Remove(recipeToRemove);
                Console.WriteLine($"Recipe '{recipeName}' has been removed.");
            }
            else
            {
                Console.WriteLine($"Recipe '{recipeName}' not found.");
            }

        }
        //Clears all the entered recipes
        public static void ClearAllRecipes()
        {
            if (Recipes.Count == 0)
            {
                Console.WriteLine("No recipes available to clear.");
                return;
            }

            foreach (var recipe in Recipes.ToList())
            {
                Recipes.Remove(recipe);
            }

            Console.WriteLine("All recipes have been cleared.");
        }
        //  Calculates the total calories in the Recipe
        public int TotalCalories()
        {
            int totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Recipe: {Name}");
            sb.AppendLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }
            sb.AppendLine("Steps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                sb.AppendLine($"{i + 1}. {Steps[i]}");
            }
            int totalCalories = TotalCalories();
            sb.AppendLine($"Total Calories: {totalCalories}");
            if (totalCalories > 300)
            {
                CalorieWarning?.Invoke("Warning: This recipe exceeds 300 calories!");
            }
            return sb.ToString();
        }
        public static void DisplayAllRecipes()
        {
            if (Recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            List<Recipe> sortedRecipes = Recipes.OrderBy(recipe => recipe.Name).ToList();

            foreach (var recipe in sortedRecipes)
            {
                if (!recipe.IsCleared)
                {
                    Console.WriteLine(recipe);
                    Console.WriteLine("-----------------------------------------------");
                }
            }
        }

        //Displays the specific recipe user requests
        public static void DisplaySpecificRecipe()
        {
            if (Recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            Console.Write("Enter the name of the recipe to display: ");
            string recipeName = Console.ReadLine();

            Recipe selectedRecipe = Recipes.Find(recipe => recipe.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (selectedRecipe == null)
            {
                Console.WriteLine("Recipe not found.");
            }
            else
            {
                Console.WriteLine(selectedRecipe);
                Console.WriteLine("-----------------------------------------------");
            }
        }
    }
}


