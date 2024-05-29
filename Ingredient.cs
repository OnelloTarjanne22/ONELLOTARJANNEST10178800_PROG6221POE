using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ONELLOTARJANNEST10178800PROG6211POEP1
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
        private double InitialQuantity { get; set; }

        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
            InitialQuantity = quantity;  
        }

        public void ResetQuantity()
        {
            Quantity = InitialQuantity;
        }

        public override string ToString()
        {
            return $"{Name}: {Quantity} {Unit} ({Calories} calories)";
        }
    }
}
