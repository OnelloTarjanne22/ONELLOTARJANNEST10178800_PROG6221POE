using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ONELLOTARJANNEST10178800PROG6211POEP1
{
    public class Step
    {
        public string Description { get; set; }

        public Step(string description)
        {
            Description = description;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
