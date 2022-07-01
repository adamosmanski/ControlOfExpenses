using System;
using System.Collections.Generic;

namespace ControlOfExpenses.Data.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Cost { get; set; } = 0!;
        public string User { get; set; } = null!;
        public string DayCost { get; set; } = null!;
        public string MonthCost { get; set; } = null!;
        public string YearCost { get; set; } = null!;
    }
}
