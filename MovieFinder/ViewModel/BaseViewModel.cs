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
        public BaseViewModel()
        {
            this.moviesService = new MoviesService();
        }

        [RelayCommand]
       async Task GetMoviesAsync(string searchQuery)
        {
            Console.WriteLine(searchQuery);
            AllMovies.Clear();
            Console.WriteLine(AllMovies.Count);   
            try
            {
                var movies = await moviesService.GetMovies(searchQuery);
                
                foreach (var movie in movies)
                {
                    AllMovies.Add(movie);
                }
                

            }
            catch (Exception ex) { 
                Debug.WriteLine(ex);
            }
            finally
            {
                //Console.WriteLine(AllMovies.Count);
            }
         
    }
        
    }
}
