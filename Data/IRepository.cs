using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlOfExpenses.Data
{
    public interface IRepository
    {
        decimal MonthlySum(string selectDate);
        decimal YearlySum(string selectDate);
        decimal DailySum(DateTime selectDate);

    }
}
