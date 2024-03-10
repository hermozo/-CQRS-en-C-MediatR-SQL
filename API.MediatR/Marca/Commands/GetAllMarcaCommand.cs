using API1.Data.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.MediatR.Marca.Commands
{
    public record GetAllMarcaCommand : IRequest<List<MarcaDTO>>;
}
