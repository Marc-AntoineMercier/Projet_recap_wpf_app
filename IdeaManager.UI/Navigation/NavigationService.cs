using CommunityToolkit.Mvvm.ComponentModel;
using IdeaManager.UI.ViewModels;
using System.Windows.Navigation;

namespace IdeaManager.UI.Navigation
{
    public partial class NavigationService : ObservableObject
    {
        [ObservableProperty]
        private ViewModelBase currentViewModel;

        public async void NavigateTo(ViewModelBase viewModel)
        {
            CurrentViewModel = viewModel;
            await viewModel.OnNavigatedToAsync();
        }
    }
}
