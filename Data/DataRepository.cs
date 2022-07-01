using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlOfExpenses.Data
{
    public class DataRepository : IRepository
    {
        private ControlOfExpensesContext _controlContext;
        public DataRepository(ControlOfExpensesContext controlContext)
        {
            _controlContext = controlContext;
        }

        public decimal DailySum(DateTime selectDate)
        {
            return _controlContext.Expenses.Where(x => x.DayCost == selectDate.Day.ToString()).Where(x => x.MonthCost == selectDate.Month.ToString()).Where(x => x.YearCost == selectDate.Year.ToString()).Sum(x => x.Cost);
        }

        public decimal MonthlySum(string selectDate)
        {
            return _controlContext.Expenses.Where(x => x.MonthCost == selectDate).Where(x => x.YearCost == DateTime.Now.Year.ToString()).Sum(x => x.Cost);
        }

        public decimal YearlySum(string selectDate)
        {
            return _controlContext.Expenses.Where(x => x.YearCost == selectDate).Sum(x => x.Cost);
        }
        //public decimal CustomizeSum(string selectDate)
        //{
        //    return 0;
        //}
    }
}
