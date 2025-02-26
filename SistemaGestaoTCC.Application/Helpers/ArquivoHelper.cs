using Microsoft.AspNetCore.Http;

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
            //WARN nao esta deletando
            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var filePath = Path.Combine(uploadDirectory, $"{idArquivo}{extensao}");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

    }
}