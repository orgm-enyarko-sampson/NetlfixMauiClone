using Netflix_Clone.Services;
using Netflix_Clone.ViewModels;

namespace Netflix_Clone.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly HomeViewModel _homeViewModel;
        public MainPage(HomeViewModel homeViewModel)
        {
            InitializeComponent();
            _homeViewModel = homeViewModel;
            BindingContext = _homeViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
           await _homeViewModel.InitializeAsync();
        }
    }
}