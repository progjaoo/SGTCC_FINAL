using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;
namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class RelatorioPDFGenerator : IRelatorioPDFGenerator
    {
        private readonly string _logoPath;

        public RelatorioPDFGenerator()
        {
            _logoPath = Path.Combine(Directory.GetCurrentDirectory(), "Images", "logounidombosco.png");
        }

        public async Task<byte[]> GenerateRelatorioPDFAsync(RelatorioAcompanhamento relatorio)
        {
            using (var stream = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(stream);
                PdfDocument pdf = new PdfDocument(writer);
                iText.Layout.Document document = new iText.Layout.Document(pdf);

                document.SetMargins(20, 20, 20, 20);

                try
                {
                    iText.Layout.Element.Table headerTable = new iText.Layout.Element.Table(new float[] { 1, 5 }).UseAllAvailableWidth();

                    if (File.Exists(_logoPath))
                    {
                        ImageData logoImageData = ImageDataFactory.Create(_logoPath);
                        iText.Layout.Element.Image logoImage = new iText.Layout.Element.Image(logoImageData).SetWidth(50).SetHeight(50);
                        Cell logoCell = new Cell().Add(logoImage).SetBorder(Border.NO_BORDER).SetVerticalAlignment(VerticalAlignment.MIDDLE);
                        headerTable.AddCell(logoCell);
                    }
                    else
                    {
                        headerTable.AddCell(new Cell().Add(new Paragraph("Logo")).SetBorder(Border.NO_BORDER).SetVerticalAlignment(VerticalAlignment.MIDDLE));
                    }


                    Cell titleCell = new Cell()
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetFontSize(12)
                        .SetBorder(Border.NO_BORDER)
                        .Add(new Paragraph("Trabalho Final de Conclusão de Curso (TCC)\n" +
                                           "Centro Universitário Dom Bosco do Rio de Janeiro – UniDomBosco-RJ\n" +
                                           "Curso de Sistemas de Informação"));
                    headerTable.AddCell(titleCell);

                    document.Add(headerTable);

                    document.Add(new Paragraph("\n"));

                    document.Add(new Paragraph($"Professor: {relatorio.IdUsuarioNavigation.Nome}"));
                    document.Add(new Paragraph($"Nome do Projeto: {relatorio.IdProjetoNavigation.Nome}"));
                    document.Add(new Paragraph($"Data: {relatorio.DataRealizacao:dd/MM/yyyy}, Duração do encontro: {relatorio.DuracaoEncontro}h"));

                    document.Add(new Paragraph("\nParticipantes do Projeto:"));

                    if (relatorio.IdProjetoNavigation?.UsuarioProjetos != null && relatorio.IdProjetoNavigation.UsuarioProjetos.Any())
                    {
                        foreach (var usuarioProjeto in relatorio.IdProjetoNavigation.UsuarioProjetos)
                        {
                            if (usuarioProjeto.IdUsuarioNavigation != null)
                            {
                                document.Add(new Paragraph($"- {usuarioProjeto.IdUsuarioNavigation.Nome} ({usuarioProjeto.Funcao})"));
                            }
                            else
                            {
                                document.Add(new Paragraph("- Informação do Participante Indisponível"));
                            }
                        }
                    }
                    else
                    {
                        document.Add(new Paragraph("- Nenhum participante encontrado para este projeto."));
                    }
                    document.Add(new Paragraph("\n"));

                    document.Add(new Paragraph($"Descrição do Relatório: {relatorio.Descricao}"));

                    document.Add(new Paragraph("\n"));
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao gerar PDF do Relatório: {ex.Message}");
                }
                finally
                {
                    document.Close();
                }

                return stream.ToArray();
            }
        }
    }
}
