using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    internal class Product
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Category { get; internal set; }
        public double CostUnit { get; internal set; }

        public string Unit{ get; internal set; }

        public override string ToString()
        {
            return $"Product: {this.Id}, {this.Name}, {this.Category}, {this.CostUnit}";
        }
    }
}