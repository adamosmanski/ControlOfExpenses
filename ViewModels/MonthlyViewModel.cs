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
    public class MonthlyViewModel : ObserveObject
    {

        MonthlyExpenseModel model = new MonthlyExpenseModel();
        ControlOfExpensesContext dbContext = new ControlOfExpensesContext();
        public MonthlyViewModel()
        {
            SelectDate = model.SelectDate;
            Total = model.Total;
            Months = model.Months;
            
        }
        public List<string> Months
        {
            get => model.Months;
            set
            {
                model.Months = value;
                GetTotal(SelectDate);
                Observe();
            }
        }
        public string SelectDate
        {
            get
            {
                switch (model.SelectDate)
                {
                    case "Styczeń":
                        return model.SelectDate = "1";                        
                    case "Luty":
                        return model.SelectDate = "2";                         
                    case "Marzec":
                        return model.SelectDate = "3";
                    case "Kwiecień":
                        return model.SelectDate = "4";
                    case "Maj":
                        return model.SelectDate = "5";
                    case "Czerwiec":
                        return model.SelectDate = "6";
                    case "Lipiec":
                        return model.SelectDate = "7";
                    case "Sierpień":
                        return model.SelectDate = "8";
                    case "Wrzesień":
                        return model.SelectDate = "9";
                    case "Październik":
                        return model.SelectDate = "10";
                    case "Listopad":
                        return model.SelectDate = "11";
                    case "Grudzień":
                        return model.SelectDate = "12";
                    default:
                        return model.SelectDate;
                }
            }
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
                GetTotal(SelectDate);
                Observe();
            }
        }
        private void GetTotal(string sd)
        {
            DataRepository dataRepository = new DataRepository(dbContext);
            model.Total = dataRepository.MonthlySum(sd).ToString();
        }
        private void Observe()
        {
            OnPropertyChanged(nameof(Months));
            OnPropertyChanged(nameof(SelectDate));
            OnPropertyChanged(nameof(Total));
        }
    }
}

