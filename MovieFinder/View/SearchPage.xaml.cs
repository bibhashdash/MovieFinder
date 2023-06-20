using MovieFinder.ViewModel;

namespace MovieFinder.View;

public partial class SearchPage: ContentPage
{

	public SearchPage(BaseViewModel baseViewModel)
	{
		InitializeComponent();
		BindingContext = baseViewModel;
	}

	
}

