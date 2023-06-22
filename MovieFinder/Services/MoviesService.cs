using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using MovieFinder.Model;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using System.Net.WebSockets;

namespace MovieFinder.Services
{
    class MoviesService
    {
        HttpClient httpClient;

        public MoviesService ()
        {
            httpClient = new ();
        }

        List<Movie> movieList = new ();

        public async Task<List<Movie>> GetMovies(string searchQuery)
        {
            
            var url = $"https://www.omdbapi.com/?i=tt3896198&apikey=55dce2d4&s={searchQuery}";
             var response = await httpClient.GetAsync(url);
            movieList.Clear();
            if (response.IsSuccessStatusCode)
            {
                
                var result2 = await response.Content.ReadFromJsonAsync<Root>();
                movieList = result2.Search;                
            }
            return movieList;
        }

        MovieDetails movieDetails = new ();

        public async Task<MovieDetails> GetMovieDetails(string movieTitle)
        {
            var url = $"https://www.omdbapi.com/?i=tt3896198&apikey=55dce2d4&t={movieTitle}&plot=full";
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                movieDetails = await response.Content.ReadFromJsonAsync<MovieDetails>();

            }
            return movieDetails;
        }
    }
}
