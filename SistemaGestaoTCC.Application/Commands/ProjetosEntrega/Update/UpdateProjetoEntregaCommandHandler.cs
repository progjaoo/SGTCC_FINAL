﻿namespace SistemaGestaoTCC.Application.Commands.ProjetosEntrega.Update
{
    //public class UpdateProjetoEntregaCommandHandler : IRequestHandler<UpdateProjetoEntregaCommand, Unit>
    //{
    //    private readonly IProjetoEntregaRepository _projetoEntregaRepository;

    //    public UpdateProjetoEntregaCommandHandler(IProjetoEntregaRepository projetoEntregaRepository)
    //    {
    //        _projetoEntregaRepository = projetoEntregaRepository;
    //    }
    //    public async Task<Unit> Handle(UpdateProjetoEntregaCommand request, CancellationToken cancellationToken)
    //    {

    //        var entrega = await _projetoEntregaRepository.GetByIdAsync(request.Id);

    //        if (entrega == null)
    //            throw new Exception("Entrega não encontrada");

    //        entrega.UpdateEntrega(request.Titulo, request.DataLimite, request.Entregue);
    //        await _projetoEntregaRepository.SaveChangesAsync();

    //        return Unit.Value;
    //    }
    //}
}
