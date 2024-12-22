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
    public class CreateUserCommandHandler : ImplementBase<User>, IRequestHandler<UserCommandDTO>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        public CreateUserCommandHandler(BissnesExpertSystemDiplomaContext context) : base(context)
        {
            _context = context;
        }

        public async Task Handle(UserCommandDTO request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Patronymic = request.Patronymic,
                PhotoImage = request.PhotoImage,
                CheckPhrase = request.CheckPhrase,
                DateCreate = DateOnly.FromDateTime(DateTime.Now),
                EndWorkTime = (DateTimeOffset)request.EndWorkTime,
                StartWorkTime = (DateTime)request.StartWorkTime,
                Family = request.Family,
                IdRole = request.IdRole,
                Login = request.Login,
            };

            await _context.Users.AddAsync(user);
            await SaveAsync();

        }
    }
}
