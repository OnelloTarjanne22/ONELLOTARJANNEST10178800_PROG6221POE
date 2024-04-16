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
        private double originalQuantity;
        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            originalQuantity = quantity;
        }
        public void ResetQuantity()
        {
            Quantity = originalQuantity;
        }

        public override string ToString()
        {
            return $"{Quantity} {Unit} of {Name}";
        }
    }
}
