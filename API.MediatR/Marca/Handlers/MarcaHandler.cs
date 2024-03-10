using API.MediatR.Marca.Commands;
using API1.Data.DTO;
using API1.Data.Entity;
using API1.Domain.Context;
using MediatR;

namespace API.MediatR.Marca.Handlers
{
    public class MarcaHandler : IRequestHandler<CreateCommand, MarcaDTO>
    {
        private readonly AppDbContext _appDbContext;
        public MarcaHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<MarcaDTO> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var marca = new API1.Data.Entity.Marca
            {
                Idmarca = request.Idmarca,
                Nombre = request.Nombre,
                PaginaWeb = request.PaginaWeb,
                TelefonoContacto = request.TelefonoContacto,
                CorreoContacto = request.CorreoContacto,
                CreatedDate = request.CreatedDate,
                CreatedBy = request.CreatedBy,
                ModifiedDate = request.ModifiedDate,
                ModifiedBy = request.ModifiedBy,
                DeletedDate = request.DeletedDate,
                DeletedBy = request.DeletedBy,
                IsDeleted = request.IsDeleted
            };
            _appDbContext.Add(marca);
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
