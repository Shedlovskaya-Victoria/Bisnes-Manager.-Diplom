using BisnesManager.DatabasePersistens.Context;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.BisnesManager.Commands.Create.CommandDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Create.CommandHandler
{
    public class CreateBisnesTaskCommandHandler : ImplementBase<BisnesTask>, IRequestHandler<BisnesTaskCreateCommandDTO>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;

       
        public CreateBisnesTaskCommandHandler(BissnesExpertSystemDiplomaContext context) : base(context)
        {
            _context = context;
        }

        async Task<Unit>  IRequestHandler<BisnesTaskCreateCommandDTO, Unit>.Handle(BisnesTaskCreateCommandDTO request, CancellationToken cancellationToken)
        {
            var bisnesTask = new BisnesTask()
            {
                AssignmentsContent = request.AssignmentsContent,
                Content = request.Content,
                DateCreate = DateOnly.FromDateTime(DateTime.Now),
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                IdStatus = request.IdStatus,
                IdUser = request.IdUser,
                Indentation = request.Indentation,
            };

            await _context.BisnesTasks.AddAsync(bisnesTask, cancellationToken);
            await SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
