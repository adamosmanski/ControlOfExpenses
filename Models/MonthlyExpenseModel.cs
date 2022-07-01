using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlOfExpenses.Models
{
    public class MonthlyExpenseModel
    {
        public string Total { get; set; }
        public string SelectDate { get; set; }
        public List<string> Months = new List<string>()
        {
            "Styczeń", "Luty","Marzec","Kwiecień","Maj","Czerwiec","Lipiec","Sierpień","Wrzesień","Październik","Listopad","Grudzień"
        };
    }
}