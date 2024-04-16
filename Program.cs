using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;//ONELLO TARJANNE ST10178800 GROUP:3 //All code has been coded by myself and with use of sources listed in reference list
namespace ONELLOTARJANNEST10178800PROG6211POEP1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Recipe Library!");


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

            // Get details for each ingredient
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


            Recipe recipe = new Recipe(recipeName, ingredients, steps);

            // Display the recipe
            Console.WriteLine("\nRecipe entered successfully!");
            Console.WriteLine(recipe);

            //Menu
            while (true)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Scale Recipe");
                Console.WriteLine("2. Reset Quantity");
                Console.WriteLine("3. Clear Data");
                Console.WriteLine("4. Show Recipe");
                Console.WriteLine("5. Add new Recipe");
                Console.WriteLine("6. Exit");
                Console.WriteLine("-----------------------------------------------");
                Console.Write("Enter your choice (1-6): ");
                string choice = Console.ReadLine();
                Console.WriteLine("-----------------------------------------------");
                switch (choice)
                {
                    case "1":
                        // Scale up recipe Ingredients
                        Console.Write("Enter scale factor (0.5 for half, 2 for double, 3 for triple): ");
                        double factor;
                        while (!double.TryParse(Console.ReadLine(), out factor))
                        {
                            Console.WriteLine("Invalid factor. Please enter a valid number.");
                            Console.Write("Enter scale factor (0.5 for half, 2 for double, 3 for triple): ");
                        }
                        recipe.AdjustQuantity(factor);
                        Console.WriteLine("\nRecipe scaled successfully!");
                        Console.WriteLine(recipe);
                        Console.WriteLine("-----------------------------------------------");
                        break;


                    case "2":
                        //Reset recipe Quantities
                        recipe.ResetQuantity();
                        Console.WriteLine("\nQuantity reset successfully!");
                        Console.WriteLine(recipe);
                        Console.WriteLine("-----------------------------------------------");
                        break;

                    case "3":
                        // Clears Recipe
                        recipe.ClearRecipe();
                        Console.WriteLine("\nData cleared successfully!");
                        Console.WriteLine("-----------------------------------------------");
                        break;

                    case "4":
                        Console.WriteLine(recipe);
                        Console.WriteLine("-----------------------------------------------");
                        break;
                    case "5":
                        //Adds new Recipe
                        recipe = Recipe.AddNewRecipe();
                        Console.WriteLine("\nRecipe added successfully!");
                        Console.WriteLine("-----------------------------------------------");

                        break;
                    case "6":
                        // Option to exit Program
                        Console.WriteLine("\nExiting the program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }

        }
    }

}