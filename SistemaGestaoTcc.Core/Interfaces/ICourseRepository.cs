using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Curso>> GetAllAsync();
        Task<Curso> GetById(int id);
        Task AddASync(Curso curso);
        Task DeleteCourse(int id);
        Task SaveChangesAsync();
    }
}
