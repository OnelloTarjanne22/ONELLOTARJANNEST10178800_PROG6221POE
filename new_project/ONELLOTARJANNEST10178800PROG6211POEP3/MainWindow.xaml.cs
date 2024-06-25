using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ONELLOTARJANNEST10178800PROG6211POEP3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text;
            if (string.IsNullOrEmpty(recipeName))
            {
                MessageBox.Show("Please enter a recipe name.");
                return;
            }

            // Parse ingredients
            List<Ingredient> ingredients = new List<Ingredient>();
            string[] ingredientLines = IngredientNameTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in ingredientLines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 5)
                {
                    if (double.TryParse(parts[0].Trim(), out double quantity))
                    {
                        string name = parts[2].Trim();
                        string unit = parts[1].Trim();
                        if (int.TryParse(parts[3].Trim(), out int calories))
                        {
                            string foodGroup = parts[4].Trim();
                            ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid number for calories.");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid number for quantity.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter ingredients in the correct format: quantity, unit, name, calories, food group");
                    return;
                }
            }


            // Parse steps
            List<Step> steps = new List<Step>();
            string[] stepLines = StepsTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string stepDescription in stepLines)
            {
                steps.Add(new Step(stepDescription));
            }

            // Create and save the recipe
            Recipe newRecipe = new Recipe(recipeName, ingredients, steps);
            Recipe.Recipes.Add(newRecipe);

            MessageBox.Show($"Recipe '{recipeName}' saved successfully!");
            ClearFields();

            MenuWindow menuWindow = new MenuWindow();
            menuWindow.DataContext = newRecipe; 
            menuWindow.Show();

            
            this.Close();
        }

        private void ClearFields()
        {
            RecipeNameTextBox.Clear();
            IngredientNameTextBox.Clear();
            StepsTextBox.Clear();
        }
    }

}