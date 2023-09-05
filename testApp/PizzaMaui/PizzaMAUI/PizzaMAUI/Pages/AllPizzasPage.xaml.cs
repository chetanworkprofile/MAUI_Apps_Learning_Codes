namespace PizzaMAUI.Pages;

public partial class AllPizzasPage : ContentPage
{
	private readonly AllPizzaViewModel _allPizzaViewModel;
	public AllPizzasPage(AllPizzaViewModel allPizzaViewModel)
	{
		InitializeComponent();
		_allPizzaViewModel = allPizzaViewModel;
		BindingContext =  _allPizzaViewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		if (_allPizzaViewModel.FromSearch)
		{
			await Task.Delay(10);
			searchBar.Focus();
		}
    }

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
		if(!string.IsNullOrEmpty(e.OldTextValue) && string.IsNullOrEmpty(e.NewTextValue))
		{
			_allPizzaViewModel.SearchPizzasCommand.Execute(null);
		}
		else
		{
			_allPizzaViewModel.SearchPizzasCommand.Execute(e.NewTextValue);
		} 
    }
}