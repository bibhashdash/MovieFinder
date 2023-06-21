using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MovieFinder.Model;

namespace MovieFinder.ViewModel
{
    [QueryProperty("MovieDetails", "MovieDetails")]
    public partial class MovieDetailsViewModel : BaseViewModel
    {
        public MovieDetailsViewModel()
        {

        }

        [ObservableProperty]
        MovieDetails movieDetails;        
    }
}
