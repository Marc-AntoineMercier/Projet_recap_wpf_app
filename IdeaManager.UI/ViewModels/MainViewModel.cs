using CommunityToolkit.Mvvm.Input;
using IdeaManager.UI.Navigation;

namespace IdeaManager.UI.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        public INavigationService Navigator { get; }

        private readonly IdeaFormViewModel _formViewModel;
        private readonly IdeaListViewModel _listViewModel;
        private readonly DashboardViewModel _dashboardViewModel;

        public MainViewModel(
            INavigationService navigationService,
            IdeaFormViewModel formViewModel,
            IdeaListViewModel listViewModel,
            DashboardViewModel dashboardViewModel)
        {
            Navigator = navigationService;
            _formViewModel = formViewModel;
            _listViewModel = listViewModel;
            _dashboardViewModel = dashboardViewModel;

            Navigator.NavigateTo(_dashboardViewModel);
        }

        [RelayCommand]
        private void ShowForm() => Navigator.NavigateTo(_formViewModel);

        [RelayCommand]
        private void ShowList() => Navigator.NavigateTo(_listViewModel);

        [RelayCommand]
        private void ShowDashboard() => Navigator.NavigateTo(_dashboardViewModel);
    }
}
