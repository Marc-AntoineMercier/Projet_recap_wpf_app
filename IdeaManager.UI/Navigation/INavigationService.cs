using IdeaManager.UI.ViewModels;

public interface INavigationService
{
    ViewModelBase CurrentViewModel { get; }

    void NavigateTo(ViewModelBase viewModel);
}