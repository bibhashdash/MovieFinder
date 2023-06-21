using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using MovieFinder.Model;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using GoogleGson;
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

        //Movie movie = new Movie ();

        //Root result = new Root ();

        public async Task<List<Movie>> GetMovies(string searchQuery)
        {
            if (movieList.Count > 0) return movieList;
            var url = $"https://www.omdbapi.com/?i=tt3896198&apikey=55dce2d4&s={searchQuery}";
             var response = await httpClient.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                var result2 = await response.Content.ReadFromJsonAsync<Root>();
                movieList = result2.Search;
            }
            return movieList;
        }
    }
}
