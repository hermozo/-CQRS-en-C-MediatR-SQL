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
    public class DeleteHandler : IRequestHandler<DeleteCommand, bool>
    {
        private readonly AppDbContext _appDbContext;
        public DeleteHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var marca = await _appDbContext.Marca.FindAsync(request.id, cancellationToken);
            if (marca == null)
            {
                return false;
            }
            _appDbContext.Remove(marca);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
