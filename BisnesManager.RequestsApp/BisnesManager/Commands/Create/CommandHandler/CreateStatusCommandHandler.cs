using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisnesManager.DatabasePersistens.Context;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.ETL.DTO;
using BisnesManager.RequestsApp.BisnesManager.Commands.Create.CommandDTO;
using MediatR;
namespace BisnesManager.RequestsApp.BisnesManager.Commands.Create.CommandHandler
{
    public class CreateStatusCommandHandler : ImplementBase<Status>, IRequestHandler<StatusCreateCommandDTO>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        public CreateStatusCommandHandler(BissnesExpertSystemDiplomaContext context) : base(context)
        {
            _context = context;
        }

        

        async Task<Unit> IRequestHandler<StatusCreateCommandDTO, Unit>.Handle(StatusCreateCommandDTO request, CancellationToken cancellationToken)
        {
            var status = new Status()
            {
                Title = request.Title,
            };

            await _context.Statuses.AddAsync(status, cancellationToken);
            await SaveAsync(cancellationToken);


            return Unit.Value;
        }
    }
}
