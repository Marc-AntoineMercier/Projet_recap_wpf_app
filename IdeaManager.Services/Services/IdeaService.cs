using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using IdeaManager.Core.Enums;

public class IdeaService : IIdeaService
{
    private readonly IUnitOfWork _unitOfWork;

    public IdeaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task SubmitIdeaAsync(Idea idea)
    {
        if (string.IsNullOrWhiteSpace(idea.Title))
            throw new ArgumentException("Le titre est obligatoire.");

        idea.VoteCount = 0;
        idea.Status = IdeaStatus.InProgress;

        await _unitOfWork.IdeaRepository.AddAsync(idea);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<Idea>> GetAllAsync()
    {
        return await _unitOfWork.IdeaRepository.GetAllAsync();
    }

    public async Task VoteForIdeaAsync(int ideaId)
    {
        var idea = await _unitOfWork.IdeaRepository.GetByIdAsync(ideaId);

        if (idea == null)
            throw new InvalidOperationException("Idée non trouvée.");

        idea.VoteCount++;
        await _unitOfWork.IdeaRepository.AddAsync(idea); // Pour simuler une mise à jour simplifiée
    }

}
