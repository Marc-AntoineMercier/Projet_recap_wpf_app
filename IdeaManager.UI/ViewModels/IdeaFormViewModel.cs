using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;

namespace IdeaManager.UI.ViewModels
{
    public partial class IdeaFormViewModel : ViewModelBase
    {
        private readonly IIdeaService _ideaService;

        public IdeaFormViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
        }

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string errorMessage;

        [ObservableProperty]
        private string confirmationMessage;

        public bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Description))
            {
                errorMessage = "Veuillez remplir tous les champs.";
                return false;
            }
            return true;
        }

        [RelayCommand]
        private async Task SubmitAsync()
        {
            if (!ValidateInputs()) return;

            try
            {
                var idea = new Idea
                {
                    Title = Title,
                    Description = Description
                };

                await _ideaService.SubmitIdeaAsync(idea);
                ConfirmationMessage = "L'idée a été soumise avec succès!";
                ClearInput();
                ErrorMessage = string.Empty;
            }
            catch (ArgumentException argEx)
            {
                ErrorMessage = argEx.Message;
                Console.WriteLine(argEx.Message);
                ConfirmationMessage = string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);
                ErrorMessage = ex.InnerException?.Message ?? ex.Message;
                ConfirmationMessage = string.Empty;
            }
        }

        [RelayCommand]
        public void ClearInput()
        {
            Title = string.Empty;
            Description = string.Empty;
            ErrorMessage = string.Empty;
            ConfirmationMessage = string.Empty;
        }
    }
}
