using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ONELLOTARJANNEST10178800PROG6211POEP1
{
    public class Recipe
    {
        public string Name { get; set; }
        public Ingredient[] Ingredients { get; set; }
        public Step[] Steps { get; set; }

        public Recipe(string name, Ingredient[] ingredients, Step[] steps)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
        }

        public override string ToString()
        {
            string recipeString = $"Recipe: {Name}\n\nIngredients:\n";
            foreach (var ingredient in Ingredients)
            {
                recipeString += $"- {ingredient}\n";
            }
            recipeString += "\nSteps:\n";
            for (int i = 0; i < Steps.Length; i++)
            {
                recipeString += $"{i + 1}. {Steps[i]}\n";
            }
            return recipeString;
        }
        //Adjust Ingredient quantity
        public void AdjustQuantity(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }
        //Resets to initial Quantity
        public void ResetQuantity()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.ResetQuantity();
            }
        }

        public void ClearRecipe()
        {
            Array.Clear(Ingredients, 0, Ingredients.Length);
            Array.Clear(Steps, 0, Steps.Length);

        }
        //Method for adding new recipe
        public static Recipe AddNewRecipe()
        {
            Console.WriteLine("\nPlease enter the recipe details:");

            // Get recipe name from the user
            Console.Write("Recipe name: ");
            string recipeName = Console.ReadLine();

            // Get the number of ingredients
            Console.Write("Number of ingredients: ");
            int numIngredients;
            while (!int.TryParse(Console.ReadLine(), out numIngredients))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            // Initialize arrays for ingredients and steps
            Ingredient[] ingredients = new Ingredient[numIngredients];
            Step[] steps;

            // Get details for each ingredient in Recipe
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

                ingredients[i] = new Ingredient(ingredientName, quantity, unit);
            }

            // Get the number of steps
            Console.Write("\nNumber of steps: ");
            int numSteps;
            while (!int.TryParse(Console.ReadLine(), out numSteps))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            steps = new Step[numSteps];

            // Get details for each step
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"\nStep {i + 1}:");
                Console.Write("Description: ");
                string description = Console.ReadLine();

                steps[i] = new Step(description);
            }

            // Create and return the new recipe
            return new Recipe(recipeName, ingredients, steps);
        }

    }
}
