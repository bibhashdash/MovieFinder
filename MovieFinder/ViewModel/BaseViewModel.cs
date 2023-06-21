using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieFinder.Services;
using MovieFinder.View;
using System.Collections.ObjectModel;
using System.Diagnostics;
using MovieFinder.Model;
using Microsoft.Maui.Controls;

namespace MovieFinder.ViewModel
    
{

    public partial class BaseViewModel : ObservableObject
    {

        [ObservableProperty]
        Movie movie;

        [ObservableProperty]
        Model.MovieDetails movieDetails;

        [ObservableProperty]
        public bool searchResultsAvailable;

        MoviesService moviesService;
        public ObservableCollection<Movie> AllMovies { get; } = new ();
        public BaseViewModel()
        {
            this.moviesService = new MoviesService();
            
        }

        [RelayCommand]
       async Task GetMoviesAsync(string searchQuery)
        {          
            AllMovies.Clear();
              
            try
            {
                
                var movies = await moviesService.GetMovies(searchQuery);
                
                foreach (var movie in movies)
                {
                    AllMovies.Add(movie);
                }
                
                SearchResultsAvailable = true;
            }
            catch (Exception ex) { 
                Debug.WriteLine(ex);
                SearchResultsAvailable = false;
            }
          
         
        }

        [RelayCommand]
        public void ClearSearchResults()
        {
            AllMovies.Clear();
            SearchResultsAvailable = false;
        }

        [RelayCommand]
        async Task GoToDetailsAsync(Movie movie)
        {
            if (movie is null)
                return;

           
            var result = await GetMovieDetailsAsync(movie.Title);
           
    
            
                Console.WriteLine(result.Title);
                await Shell.Current.GoToAsync($"{nameof(MovieDetailsPage)}", true, new Dictionary<string, object>
            {
                {"MovieDetails", result}
            });
            
        }

        [RelayCommand]
    async  Task<MovieDetails> GetMovieDetailsAsync(string movieTitle)
        {
            try
            {
                MovieDetails = await moviesService.GetMovieDetails(movieTitle);
            }
            catch (Exception ex) {
                Debug.WriteLine(ex);
            }
            return MovieDetails;
        }
    }
}
