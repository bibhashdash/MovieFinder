using CommunityToolkit.Mvvm.Input;
using MovieFinder.View;

namespace MovieFinder.ViewModel
{
    public partial class BaseViewModel
    {

        [RelayCommand]

        async Task GoToShopAsync()
        {
            await Shell.Current.GoToAsync(nameof(Shopping));
        }

        public string Title
        {
            get;
        }

        [RelayCommand]
        async Task GoToSearchPageAsync()
        {
            await Shell.Current.GoToAsync("//searchpage");
        }
    }
}
