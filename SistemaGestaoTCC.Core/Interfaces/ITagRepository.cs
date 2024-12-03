using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface ITagRepository 
    {
        //SFC
        Task<List<ProjetoTag>> GetAllAsync();
        Task<ProjetoTag> GetById(int id);
        Task Tag(int id);
    }
}
