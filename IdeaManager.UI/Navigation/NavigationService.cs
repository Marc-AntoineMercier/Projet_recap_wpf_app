using IdeaManager.UI.ViewModels;
using System.ComponentModel;

namespace IdeaManager.UI.Navigation
{
    public class NavigationService : INavigationService, INotifyPropertyChanged
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            private set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentViewModel)));
                }
            }
        }

        public async void NavigateTo(ViewModelBase viewModel)
        {
            CurrentViewModel = viewModel;
            await viewModel.OnNavigatedToAsync();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}