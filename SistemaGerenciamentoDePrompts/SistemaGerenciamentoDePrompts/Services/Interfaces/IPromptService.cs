using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaGerenciamentoDePrompts.Models;

namespace SistemaGerenciamentoDePrompts.Services.Interfaces
{
    public interface IPromptService
    {
        Task<IEnumerable<Prompt>> GetAllPromptsAsync();
        Task<Prompt?> GetPromptByIdAsync(int id);
        Task<int> CreatePromptAsync(Prompt prompt);
        Task<bool> UpdatePromptAsync(Prompt prompt);
        Task<bool> DeletePromptAsync(int id);
    }
}