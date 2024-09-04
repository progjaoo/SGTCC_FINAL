using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface ITagRepository 
    {
        //SFC
        Task<List<ProjetoTag>> GetAllAsync();
        Task<ProjetoTag> GetById(int id);
        Task Tag(int id);
    }
}
