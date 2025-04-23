using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface ISeminarioRepository
    {
        Task<List<Seminario>> GetAllAsync();
        Task<Seminario> GetById(int id);
        Task AddASync(Seminario seminario);
        Task Delete(int id);

        //SEMINARIOPROJETO - VARIOS PRA VARIOS
        Task<SeminarioProjeto> GetSeminarioProjetoByIdAsync(int id);
        Task<List<SeminarioProjeto>> GetAllSeminarioProjeto();
        Task<SeminarioProjeto> GetByProjectAndSeminario(int idSeminario, int idProjeto);
        Task AddSeminarioProjeto(SeminarioProjeto seminarioProjeto);
        Task DeleteSeminarioProjeto(int id);
        Task SaveChangesAsync();
    }
}
