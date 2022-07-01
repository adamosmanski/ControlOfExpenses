using ControlOfExpenses.Core;
using ControlOfExpenses.Data;
using ControlOfExpenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlOfExpenses.ViewModels
{
    public class YearlyViewModel : ObserveObject
    {
        YearlyExpenseModel model = new YearlyExpenseModel();
        ControlOfExpensesContext dbContext = new ControlOfExpensesContext();
        public YearlyViewModel()
        {
            Total = model.Total;
            Years = model.Years;
            SelectDate = model.SelectDate;
        }
        public List<int> Years
        {
            get => model.Years;
            set
            {
                model.Years = value;
                Observe();
            }
        }
        public string SelectDate
        {
            get => model.SelectDate;
            set
            {
                model.SelectDate = value;
                GetTotal(SelectDate);
                Observe();
            }
        }
        public string Total
        {
            get => model.Total;
            set
            {
                model.Total = value;                
                Observe();
            }
        }
        private void GetTotal(string sd)
        {
            DataRepository dataRepository = new DataRepository(dbContext);
            model.Total = dataRepository.YearlySum(sd).ToString();
        }
        private void Observe()
        {
            OnPropertyChanged(nameof(Years));
            OnPropertyChanged(nameof(SelectDate));
            OnPropertyChanged(nameof(Total));
        }
    }
}
