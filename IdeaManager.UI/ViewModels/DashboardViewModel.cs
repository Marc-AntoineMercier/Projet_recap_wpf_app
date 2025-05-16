using CommunityToolkit.Mvvm.ComponentModel;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using IdeaManager.Core.Enums;

namespace IdeaManager.UI.ViewModels
{
    public partial class DashboardViewModel : ViewModelBase
    {
        private readonly IIdeaService _ideaService;

        public DashboardViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
            LoadSummaryAsync();
        }

        [ObservableProperty]
        private string totalIdeasText;

        [ObservableProperty]
        private string approvedIdeasText;

        [ObservableProperty]
        private string pendingIdeasText;

        [ObservableProperty]
        private string rejectedIdeasText;

        private async Task LoadSummaryAsync()
        {
            List<Idea> ideas = await _ideaService.GetAllAsync();

            TotalIdeasText = $"Total d'idées : {ideas.Count}";
            ApprovedIdeasText = $"Idées approuvées : {ideas.Count(i => i.Status == IdeaStatus.Approved)}";
            PendingIdeasText = $"Idées en attente : {ideas.Count(i => i.Status == IdeaStatus.Pending)}";
            RejectedIdeasText = $"Idées rejetées : {ideas.Count(i => i.Status == IdeaStatus.Rejected)}";

        }
    }
}