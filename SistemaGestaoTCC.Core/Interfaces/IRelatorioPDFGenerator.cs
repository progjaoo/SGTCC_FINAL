using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IRelatorioPDFGenerator
    {
        Task<byte[]> GenerateRelatorioPDFAsync(RelatorioAcompanhamento relatorio);
    }
}
