using API.MediatR.Marca.Commands;
using API1.Data.DTO;
using API1.Domain.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.MediatR.Marca.Handlers
{
    public class UpdateHandler : IRequestHandler<UpdateCommand, MarcaDTO>
    {
        private readonly AppDbContext _appDbContext;
        public UpdateHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<MarcaDTO> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var marca = await _appDbContext.Marca.FindAsync(request.Idmarca, cancellationToken);
            if (marca == null)
            {
                return null;
            };
            marca.Nombre = request.Nombre;
            marca.PaginaWeb = request.PaginaWeb;
            marca.TelefonoContacto = request.TelefonoContacto;
            marca.CorreoContacto = request.CorreoContacto;
            marca.CreatedDate = request.CreatedDate;
            marca.CreatedBy = request.CreatedBy;
            marca.ModifiedDate = request.ModifiedDate;
            marca.ModifiedBy = request.ModifiedBy;
            marca.DeletedDate = request.DeletedDate;
            marca.DeletedBy = request.DeletedBy;
            marca.IsDeleted = request.IsDeleted;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return new MarcaDTO
            {
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
