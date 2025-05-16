using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Enums;
using IdeaManager.Core.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;

namespace IdeaManager.UI.ViewModels
{
    public partial class IdeaListViewModel : ViewModelBase
    {
        private readonly IIdeaService _ideaService;

        [ObservableProperty]
        private ObservableCollection<Idea> ideasList = new();

        [ObservableProperty]
        private Idea? selectedIdea;

        public IdeaListViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
        }

        private IdeaStatus _ideaStatus;
        public IdeaStatus IdeaStatus
        {
            get => _ideaStatus;
            set
            {
                _ideaStatus = value;
                OnPropertyChanged();
            }
        }

        public override async Task OnNavigatedToAsync()
        {
            var ideas = await _ideaService.GetAllAsync();
            ideasList = new ObservableCollection<Idea>(ideas);
        }


        private bool CanDeleteIdea() => SelectedIdea != null;
    }
}