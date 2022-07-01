using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlOfExpenses.Models
{
    public class YearlyExpenseModel
    {
        public List<int> Years = new List<int>();
        public string Total { get; set; }
        public string SelectDate { get; set; }
        public YearlyExpenseModel()
        {
            for (int x = 2020; x <= DateTime.Now.Year; x++)
            {
                Years.Add(x);
            }
        }
    }
}
