using ControlOfExpenses.Core;
using ControlOfExpenses.Data;
using ControlOfExpenses.Data.Entities;
using ControlOfExpenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlOfExpenses.ViewModels
{
    public class DailyViewModel : ObserveObject
    {        
        DailyExpensesModel dailyModel = new DailyExpensesModel();
        ControlOfExpensesContext dbContext = new ControlOfExpensesContext();
        public DailyViewModel()
        {
            SelectDate = dailyModel.SelectDate;
            Total = dailyModel.Total;
        }
        public DateTime SelectDate
        {
            get => dailyModel.SelectDate;
            set
            {
                dailyModel.SelectDate = value;
                GetTotal(dailyModel.Total, SelectDate);
                Observe();
            }
        }
        public string Total
        {
            get => dailyModel.Total;
            set
            {
                GetTotal(dailyModel.Total, SelectDate);
                Observe();
            }
        }
        private void GetTotal(string total, DateTime sd)
        {
            DataRepository dataRepository = new DataRepository(dbContext);
            dailyModel.Total = dataRepository.DailySum(sd).ToString();
        }            
        
        private void Observe()
        {
            OnPropertyChanged(nameof(SelectDate));
            OnPropertyChanged(nameof(Total));
        }

    }
}
