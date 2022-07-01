using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlOfExpenses.Models
{
    public class DailyExpensesModel
    {
        public string Total { get; set; }
        public DateTime SelectDate { get; set; }
        public DailyExpensesModel()
        {
            SelectDate = DateTime.Now;
        }
    }
}
