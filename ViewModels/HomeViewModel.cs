using CommunityToolkit.Mvvm.ComponentModel;
using Netflix_Clone.Models;
using Netflix_Clone.Services;
using System.Collections.ObjectModel;

namespace Netflix_Clone.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly TMDBService _tmdbService;
        public HomeViewModel(TMDBService tmdbService)
        {
            _tmdbService = tmdbService;
            
        }

        [ObservableProperty]
        private Media _trendingMovie;
        public ObservableCollection<Media> TopRated { get; set; } = new();
        public ObservableCollection<Media> Trending { get; set; } = new();
        public ObservableCollection<Media> NetflixOriginals { get; set; } = new();
        public ObservableCollection<Media> ActionMovies { get; set; } = new();

        public async Task InitializeAsync()
        {
            var trendingListTask =  _tmdbService.GetTrendingAsync();
            var netflixOriginalsTask =  _tmdbService.GetNetflixOriginalsAsync();
            var actionMoviesTask =  _tmdbService.GetActionMoviesAsync();
            var topRatedTask =  _tmdbService.GetTopRatedAsync();

            var medias = await Task.WhenAll(trendingListTask, netflixOriginalsTask, actionMoviesTask, topRatedTask);


            var trendingList = medias[0];
            var netflixOriginalsList = medias[1];
            var actionMoviesList = medias[2];
            var topRatedsList = medias[3];

            // Setting random trending movie from Trending List to the Trending Movie.
            TrendingMovie = trendingList.OrderBy(t => Guid.NewGuid()).FirstOrDefault(t => !string.IsNullOrWhiteSpace(t.DisplayTitle) && !string.IsNullOrWhiteSpace(t.Thumbnail));


            SetMediaCollection(trendingList, Trending);
            SetMediaCollection(netflixOriginalsList, NetflixOriginals);
            SetMediaCollection(actionMoviesList, ActionMovies);
            SetMediaCollection(topRatedsList, TopRated);

        }

        private static void SetMediaCollection(IEnumerable<Media> medias, ObservableCollection<Media> collection)
        {
            collection.Clear();
            foreach(var media in medias)
            {
                collection.Add(media);
            }

        }
    }
}
