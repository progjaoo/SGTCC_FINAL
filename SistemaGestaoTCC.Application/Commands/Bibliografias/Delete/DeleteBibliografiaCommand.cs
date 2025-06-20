﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Commands.Bibliografias.Delete
{
    public class DeleteBibliografiaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DeleteBibliografiaCommand(int id)
        {
            Id = id;
        }
    }
}
