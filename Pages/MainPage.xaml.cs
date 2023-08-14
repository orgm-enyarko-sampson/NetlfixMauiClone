using Netflix_Clone.Services;

namespace Netflix_Clone.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly TMDBService _tmdbService;

        public MainPage(TMDBService tmdbService)
        {
            InitializeComponent();
            _tmdbService = tmdbService;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var trending = await _tmdbService.GetTrendingAsync();
        }
    }
}