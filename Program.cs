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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the Recipe Library!");
            Console.ResetColor();
            Recipe.CalorieWarning += DisplayCalorieWarning;

            List<Recipe> recipes = new List<Recipe>();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nPlease enter the recipe details:");

                Recipe recipe = Recipe.AddNewRecipe();
                recipes.Add(recipe);

                Console.WriteLine("\nRecipe entered successfully!");
                Console.WriteLine(recipe);
                Console.ForegroundColor = ConsoleColor.Blue;

                // Menu
                while (true)
                {
                    Console.WriteLine("\nChoose an action:");
                    Console.WriteLine("1. Scale Recipe");
                    Console.WriteLine("2. Reset Quantity");
                    Console.WriteLine("3. Clear All Recipes");
                    Console.WriteLine("4. Clear Specific Recipe");
                    Console.WriteLine("5. Show Recipe");
                    Console.WriteLine("6. Add new Recipe");
                    Console.WriteLine("7. List All Recipes");
                    Console.WriteLine("8. Exit");
                    Console.WriteLine("-----------------------------------------------");
                    Console.Write("Enter your choice (1-8): ");
                    string choice = Console.ReadLine();
                    Console.WriteLine("-----------------------------------------------");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Magenta;

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter the name of the recipe to scale up: ");
                            string recipeNameToScale = Console.ReadLine();
                            Recipe recipeToScale = Recipe.Recipes.FirstOrDefault(rec => rec.Name.Equals(recipeNameToScale, StringComparison.OrdinalIgnoreCase));
                            if (recipeToScale != null)
                            {
                                Console.Write("Enter scale factor (0.5 for half, 2 for double, 3 for triple): ");
                                double scaleFactor;
                                while (!double.TryParse(Console.ReadLine(), out scaleFactor) || scaleFactor <= 0)
                                {
                                    Console.WriteLine("Invalid factor. Please enter a valid positive number.");
                                    Console.Write("Enter scale factor (0.5 for half, 2 for double, 3 for triple): ");
                                }
                                recipeToScale.ScaleRecipe(scaleFactor);
                            }
                            else
                            {
                                Console.WriteLine($"Recipe '{recipeNameToScale}' not found.");
                            }
                            break;

                        case "2":
                            // Reset recipe Quantities
                            Console.Write("Enter the name of the recipe to reset quantity: ");
                            string recipeNameToReset = Console.ReadLine();
                            Recipe recipeToReset = Recipe.Recipes.FirstOrDefault(rec => rec.Name.Equals(recipeNameToReset, StringComparison.OrdinalIgnoreCase));
                            if (recipeToReset != null)
                            {
                                recipeToReset.ResetQuantity();
                            }
                            else
                            {
                                Console.WriteLine($"Recipe '{recipeNameToReset}' not found.");
                            }
                            break;

                        case "3":
                            // Clear all recipes
                            Console.Write("Are you sure you want to clear all recipes? (yes/no): ");
                            string confirmation = Console.ReadLine().ToLower();
                            if (confirmation == "yes")
                            {
                                Recipe.ClearAllRecipes();
                                recipes.Clear();
                                Console.WriteLine("All recipes have been cleared.");
                            }
                            else
                            {
                                Console.WriteLine("Operation cancelled.");
                            }
                            break;

                        case "4":
                            // Clear specific recipe
                            if (recipes.Count == 0)
                            {
                                Console.WriteLine("No recipes available to clear.");
                            }
                            else
                            {
                                Console.Write("Enter the name of the recipe to clear: ");
                                string recipeName = Console.ReadLine();
                                Recipe.ClearRecipe(recipeName);
         
                            }
                            Console.WriteLine("-----------------------------------------------");
                            break;

                        case "5":
                            Recipe.DisplaySpecificRecipe();
                            break;

                        case "6":
                            // Exit current loop to add new recipe
                            break;

                        case "7":
                            // List all recipes
                            Recipe.DisplayAllRecipes();
                            break;

                        case "8":
                            // Option to exit 
                            Console.WriteLine("\nExiting the program. Goodbye!");
                            return;

                        default:
                            Console.WriteLine("Invalid option. Please enter a number between 1 and 8.");
                            break;
                    }

                    if (choice == "6")
                        break;

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
            }
        }
       public static void DisplayCalorieWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;

        }
    }
}
