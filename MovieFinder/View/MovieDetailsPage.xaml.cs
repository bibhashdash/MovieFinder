using CommunityToolkit;
using MovieFinder.ViewModel;
namespace MovieFinder.View;


public partial class MovieDetailsPage: ContentPage
{
	public MovieDetailsPage(MovieDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

}