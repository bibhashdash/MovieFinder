using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieFinder.Services;
using MovieFinder.View;
using System.Collections.ObjectModel;
using System.Diagnostics;
using MovieFinder.Model;

namespace MovieFinder.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        MoviesService moviesService;
        public ObservableCollection<Movie> AllMovies { get; } = new ();

        [ObservableProperty]
        private string stupidTitle;
        public BaseViewModel()
        {
            moviesService = new MoviesService();
        }

        [RelayCommand]
       async Task GetMoviesAsync(string searchQuery)
        {
            try
            {
                var movies = await moviesService.GetMovies(searchQuery);
                if (movies.Count != 0) movies.Clear();
                foreach (var movie in movies)
                {
                    AllMovies.Add(movie);
                }
                //Console.WriteLine(AllMovies.Count);

            }
            catch (Exception ex) { 
                Debug.WriteLine(ex);
            }
         
    }
        
    }
}
