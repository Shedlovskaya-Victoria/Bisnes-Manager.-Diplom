using BisnesManager.DatabasePersistens.Context;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandDTO;
using BisnesManager.RequestsApp.Common.Exception;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandHandler
{
    public class DeleteUserCommandHandler : ImplementBase<User>, IRequestHandler<UserUpdateCommandDTO>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        public DeleteUserCommandHandler(BissnesExpertSystemDiplomaContext context) : base(context)
        {
            _context = context;
        }

        public async Task Handle(UserUpdateCommandDTO request, CancellationToken cancellationToken)
        {
            var entry = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entry == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            entry.Name = request.Name;
            entry.Email = request.Email;
            entry.Password = request.Password;
            entry.Patronymic = request.Patronymic;
            entry.PhotoImage = request.PhotoImage;
            entry.CheckPhrase = request.CheckPhrase;
            entry.DateCreate = DateOnly.FromDateTime(DateTime.Now);
            entry.EndWorkTime = (DateTimeOffset)request.EndWorkTime;
            entry.StartWorkTime = (DateTime)request.StartWorkTime;
            entry.Family = request.Family;
            entry.IdRole = request.IdRole;
            entry.Login = request.Login;
            

            await SaveAsync(cancellationToken);

        }
    }
}
