using CommunityToolkit.Mvvm.ComponentModel;
using MovieFinder.ViewModel;

namespace MovieFinder.View;

public partial class SearchPage: ContentPage
{
	
	public string searchQuery;
	public SearchPage(BaseViewModel baseViewModel)
	{
		InitializeComponent();
		BindingContext = baseViewModel;
	}

    private void searchBar_SearchButtonPressed(object sender, EventArgs e)
    {
		Console.WriteLine(e);
    }
}

