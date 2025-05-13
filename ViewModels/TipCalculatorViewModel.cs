using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TipCalculator.ViewModels
{
    public partial class TipCalculatorViewModel : ObservableObject
    {
        // Valor de la boletas
        [ObservableProperty]
        private decimal billAmount;
        
        // Porcentaje de propina a agregar
        [ObservableProperty]
        private int tipPercentage;
        
        // Porcentaje de la boleta que paga la persona
        // Igual a billAmount si la cantidad de personas es 1
        [ObservableProperty]
        private decimal subtotal;
        
        // Porcentaje de la propina que paga la persona
        // Depende de tipPercentage y totalPeople
        [ObservableProperty]
        private decimal tipAmount;
        
        // Cantidad de persona en que se divide la boleta
        [ObservableProperty]
        private int totalPeople;

        // Valor total a pagar por persona
        // Suma subtotal y tipAmount
        [ObservableProperty]
        private decimal totalPerPerson;

        public TipCalculatorViewModel()
        {
            // Default values (tip percentage + total people)
            TipPercentage = 10;
            TotalPeople = 1;

            UpdateCalculations();
        }

        partial void OnBillAmountChanged(decimal value) => UpdateCalculations();
        partial void OnTipPercentageChanged(int value) => UpdateCalculations();
        partial void OnTotalPeopleChanged(int value) => UpdateCalculations();

        [RelayCommand]
        private void SetTipPercentage(int percentage)
        {
            TipPercentage = percentage;
        }

        [RelayCommand]
        private void ChangeTotalPeople(int change)
        {
            TotalPeople += change;
            if (TotalPeople < 1) {
                TotalPeople = 1;
            }
        }

        [RelayCommand]
        private void UpdateCalculations()
        {
            // Me tira error diciendo que es 0 si no está esto
            if (TotalPeople < 1) {
                TotalPeople = 1;
            }
            Subtotal = BillAmount / TotalPeople;
            TipAmount = Subtotal * TipPercentage / 100;
            TotalPerPerson = Subtotal + TipAmount;
        }

    }
}