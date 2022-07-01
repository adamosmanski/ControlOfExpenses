using ControlOfExpenses.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace ControlOfExpenses.ViewModels
{
    public class MainViewModel : ObserveObject
    {
        public MainViewModel()
        {
            Minimizing = new RelayCommand(MinimizeApp);
            CloseApplication = new RelayCommand(CloseApp);
            AddExpenses = new RelayCommand(AddExp);
            DailyExpenses = new RelayCommand(ShowDailyExpenses);
            MonthlyExpenses = new RelayCommand(ShowMonthlyExpenses);
            YearlyExpenses = new RelayCommand(ShowYearlyExpenses);
        }
        private string _title = "Kontroler Wydatków";
        public ICommand CloseApplication{ get; set; }
        public ICommand Minimizing { get; set; }
        public ICommand AddExpenses { get; set; }
        public ICommand DailyExpenses { get; set; }
        public ICommand MonthlyExpenses { get; set; }
        public ICommand YearlyExpenses { get; set; }

        public string Title
        {
            get => _title;
        }
        private ObserveObject _currentVM;
        public ObserveObject CurrentVM
        {
            get => _currentVM;
            set
            {
                _currentVM = value;
                OnPropertyChanged(nameof(CurrentVM));
            }
        }
        private ObserveObject _add;
        public ObserveObject Add
        {
            get => _add;
            set
            {
                _add = value;
                OnPropertyChanged(nameof(Add));
            }
        }

        /*
         *  Methods
         */
        private void ShowDailyExpenses(object obj)
        {
            CurrentVM = new DailyViewModel();
        }
        private void AddExp(object obj)
        {
            Add = new AddExpensesViewModel();
        }
        private void ShowMonthlyExpenses(object obj)
        {
            CurrentVM = new MonthlyViewModel();
        }
        private void ShowYearlyExpenses(object obj)
        {
            CurrentVM = new YearlyViewModel();
        }
        private void MinimizeApp(object obj)
        {
            App.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
        }
        private void CloseApp(object obj)
        {
            Environment.Exit(0);
        }
    }
}
