using API.MediatR.Marca.Commands;
using API1.Data.DTO;
using API1.Domain.Context;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.MediatR.Marca.Handlers
{

    public class GetByIdHandler : IRequestHandler<GetByIdQuery, MarcaDTO>
    {
        private readonly AppDbContext _appDbContext;
        public GetByIdHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<MarcaDTO> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var marca = await _appDbContext.Marca.FindAsync(request.id, cancellationToken);
            if (marca == null) {
                return null;
            }
            return new MarcaDTO { 
                Idmarca = marca.Idmarca,
                Nombre = marca.Nombre,
                PaginaWeb = marca.PaginaWeb,
                TelefonoContacto = marca.TelefonoContacto,
                CorreoContacto = marca.CorreoContacto,
                CreatedDate = marca.CreatedDate,
                CreatedBy = marca.CreatedBy,
                ModifiedDate = marca.ModifiedDate,
                ModifiedBy = marca.ModifiedBy,
                DeletedDate = marca.DeletedDate,
                DeletedBy = marca.DeletedBy,
                IsDeleted = marca.IsDeleted
            };
        }
    }
}
