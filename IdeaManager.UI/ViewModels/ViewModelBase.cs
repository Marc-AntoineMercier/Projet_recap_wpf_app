using CommunityToolkit.Mvvm.ComponentModel;

namespace IdeaManager.UI.ViewModels
{
    public abstract class ViewModelBase : ObservableObject
    {
        public virtual Task OnNavigatedToAsync() => Task.CompletedTask;

    }
}
