﻿using MediatR;
using Microsoft.Identity.Client;
using SistemaGestaoTCC.Application.ViewModels.CategoriaVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Categorias.GetAll
{
    public class GetAllCategoriaQueryHandler : IRequestHandler<GetAllCategoriaQuery, List<CategoriaViewModel>>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public GetAllCategoriaQueryHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<List<CategoriaViewModel>> Handle(GetAllCategoriaQuery request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetAllAsync();

            var categoriaViewModel = categoria.Select(c => new CategoriaViewModel(
                c.Id,
                c.Valor)).ToList();

            return categoriaViewModel;
        }
    }
}
