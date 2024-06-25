using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ONELLOTARJANNEST10178800PROG6211POEP3
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            LoadRecipeComboBoxes();
        }

        private void LoadRecipeComboBoxes()
        {
            selectRecipeComboBox.ItemsSource = Recipe.Recipes.Select(r => r.Name).ToList();
            deleteRecipeComboBox.ItemsSource = Recipe.Recipes.Select(r => r.Name).ToList();
            selectRecipeToScaleComboBox.ItemsSource = Recipe.Recipes.Select(r => r.Name).ToList();
        }

        private void RefreshRecipeListView()
        {
            recipeListBox.ItemsSource = null;
            recipeListBox.ItemsSource = Recipe.Recipes.Select(r => new RecipeDetail
            {
                RecipeName = r.Name,
                Ingredients = r.GetFormattedIngredients(),
                Steps = r.GetFormattedSteps(),
                TotalCalories = r.TotalCalories()
            }).ToList();
        }

        private void SelectRecipeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (selectRecipeComboBox.SelectedItem != null)
            {
                string selectedRecipeName = selectRecipeComboBox.SelectedItem.ToString();
                Recipe selectedRecipe = Recipe.Recipes.FirstOrDefault(r => r.Name == selectedRecipeName);

                if (selectedRecipe != null)
                {
                    var recipeDetail = new RecipeDetail
                    {
                        RecipeName = selectedRecipe.Name,
                        Ingredients = selectedRecipe.GetFormattedIngredients(),
                        Steps = selectedRecipe.GetFormattedSteps(),
                        TotalCalories = selectedRecipe.TotalCalories()
                    };

                    recipeListBox.ItemsSource = new List<RecipeDetail> { recipeDetail };
                }
            }
        }
        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            var ingredientName = ingredientFilterTextBox.Text.ToLower();
            var foodGroup = ((ComboBoxItem)foodGroupFilterComboBox.SelectedItem)?.Content.ToString() ?? "All";
            int maxCalories;
            int.TryParse(caloriesFilterTextBox.Text, out maxCalories);

            Recipe.ApplyFilters(recipeListBox, ingredientName, foodGroup, maxCalories);
        }



        private void DeleteRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (deleteRecipeComboBox.SelectedItem != null)
            {
                string recipeNameToDelete = deleteRecipeComboBox.SelectedItem.ToString();
                Recipe.DeleteRecipe(recipeNameToDelete);

                MessageBox.Show($"Recipe '{recipeNameToDelete}' has been deleted.");

                LoadRecipeComboBoxes();
                RefreshRecipeListView();
            }
        }

        private void AddNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ClearAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            Recipe.ClearAllRecipes(recipeListBox);
            LoadRecipeComboBoxes();
            RefreshRecipeListView();
        }

        private void DisplayAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            RefreshRecipeListView();
        }

        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedRecipeName = selectRecipeToScaleComboBox.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedRecipeName))
            {
                MessageBox.Show("Please select a recipe to scale.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (double.TryParse(scalingFactorTextBox.Text, out double factor))
            {
                try
                {
                    var selectedRecipe = Recipe.Recipes.FirstOrDefault(recipe => recipe.Name == selectedRecipeName);
                    if (selectedRecipe != null)
                    {
                        selectedRecipe.ScaleRecipe(factor);
                        MessageBox.Show($"Recipe '{selectedRecipe.Name}' has been scaled by a factor of {factor}.");
                        RefreshRecipeListView();
                    }
                    else
                    {
                        MessageBox.Show($"Recipe '{selectedRecipeName}' not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number for the scaling factor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ResetScaleButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedRecipeName = selectRecipeToScaleComboBox.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedRecipeName))
            {
                MessageBox.Show("Please select a recipe to reset its scale.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var selectedRecipe = Recipe.Recipes.FirstOrDefault(recipe => recipe.Name == selectedRecipeName);
            if (selectedRecipe != null)
            {
                selectedRecipe.ResetQuantity();
                MessageBox.Show($"Scale of recipe '{selectedRecipe.Name}' has been reset.");
                RefreshRecipeListView();
            }
            else
            {
                MessageBox.Show($"Recipe '{selectedRecipeName}' not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }


}
