using API.MediatR.Marca.Commands;
using API1.Data.DTO;
using API1.Domain.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.MediatR.Marca.Handlers
{
    public class GetAllMarcaHandler : IRequestHandler<GetAllMarcaCommand, List<MarcaDTO>>
    {
        private readonly AppDbContext _appDbContext;

        public GetAllMarcaHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<MarcaDTO>> Handle(GetAllMarcaCommand request, CancellationToken cancellationToken)
        {
            var marcas = await _appDbContext.Marca.ToListAsync();
            return marcas.Select(x => new MarcaDTO
            {
                Idmarca = x.Idmarca,
                Nombre = x.Nombre,
                PaginaWeb = x.PaginaWeb,
                TelefonoContacto = x.TelefonoContacto,
                CorreoContacto = x.CorreoContacto,
                CreatedDate = x.CreatedDate,
                CreatedBy = x.CreatedBy,
                ModifiedDate = x.ModifiedDate,
                ModifiedBy = x.ModifiedBy,
                DeletedDate = x.DeletedDate,
                DeletedBy = x.DeletedBy,
                IsDeleted = x.IsDeleted,
            }).ToList();
        }
    }
}
