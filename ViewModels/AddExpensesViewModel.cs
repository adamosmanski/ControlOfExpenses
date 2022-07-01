using ControlOfExpenses.Core;
using ControlOfExpenses.Data;
using ControlOfExpenses.Data.Entities;
using ControlOfExpenses.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ControlOfExpenses.ViewModels
{
    public class AddExpensesViewModel : ObserveObject, IDataErrorInfo
    {
        public AddExpensesModel model = new AddExpensesModel();
        private ControlOfExpensesContext db = new ControlOfExpensesContext();
        
        public AddExpensesViewModel()
        {
            _isEnabled = false;
            User = model.User;
            Cost = model.Cost.ToString();
            Dates = model.Dates;
            Confirm = new RelayCommand(AcceptData);
        }
        //private ICommand _confirm = null;
        private bool _isEnabled = false;
        public bool IsButtonEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                OnPropertyChanged(nameof(IsButtonEnabled));
            }
        }
        public ICommand Confirm { get; set; }
        public string User
        {
            get=> model.User;
            set
            {
                model.User = value;
                OnPropertyChanged(nameof(User));
            }
        }
        private string _cost;
        public string Cost
        {
            get => _cost;
            set
            {
                _cost = value;
                if (model.Cost.ToString().Length > 0)
                {
                    _isEnabled = true;
                }
                OnPropertyChanged((nameof(Cost)));
                OnPropertyChanged(nameof(IsButtonEnabled));
            }
        }

        public DateTime Dates
        {
            get => model.Dates;
            set
            {
                model.Dates = value;
                OnPropertyChanged(nameof(Dates));
            }
        }

        /*
         *      Validation
         */
        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if(columnName== nameof(User))
                {
                    if (string.IsNullOrEmpty(model.User))
                        result = "Proszę podaj użytkownika";
                }
                if (columnName == nameof(Cost))
                {
                    if (string.IsNullOrEmpty(_cost))
                        result = "Proszę podaj wydaną kwotę";
                }
                return result;
            }
        }

        /*
         *      Methods
         */
        private void AcceptData(object obj)
        {
            Expense DataModel = new Expense();
            
            DataModel.Cost = decimal.Parse(Cost);
            DataModel.User = User;
            DataModel.YearCost = Dates.Year.ToString();
            DataModel.DayCost = Dates.Day.ToString();
            DataModel.MonthCost = Dates.Month.ToString();
            db.Add(DataModel);
            db.SaveChanges();
            Cost = String.Empty;
            User = String.Empty;
            Dates = DateTime.Now;
        }
    }
}
