using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlOfExpenses.Models
{
    public class AddExpensesModel
    {
        public string User { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public DateTime Dates { get; set; }

        public AddExpensesModel()
        {
            Dates = DateTime.Now;
        }
    }
}
