using TipCalculator.ViewModels;

namespace TipCalculator;

public partial class MainPage : ContentPage
{
	private TipCalculatorViewModel viewModel;

	public MainPage()
	{
		InitializeComponent();
		viewModel = new TipCalculatorViewModel();
		BindingContext = viewModel;
	}
}

