using Microsoft.AspNetCore.Http;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Helpers
{
    public static class ArquivoHelper
    {
        internal static async Task SalvarArquivo(IFormFile file, string folderName, int idArquivo)
        {
            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            var extensao = Path.GetExtension(file.FileName);
            var novoNome = $"{idArquivo}{extensao}";
            var filePath = Path.Combine(uploadDirectory, novoNome);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

        }

        internal static void DeletarArquivo(string folderName, int idArquivo, string extensao)
        {
            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var filePath = Path.Combine(uploadDirectory, $"{idArquivo}{extensao}");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        internal static void DeletarArquivo(Arquivo arquivo)
        {
            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), arquivo.Diretorio);
            var filePath = Path.Combine(uploadDirectory, $"{arquivo.Id}{arquivo.Extensao}");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

    }
}