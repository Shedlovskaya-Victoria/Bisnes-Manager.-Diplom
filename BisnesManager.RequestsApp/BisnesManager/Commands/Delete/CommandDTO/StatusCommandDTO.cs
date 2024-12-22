using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Delete.CommandDTO
{
    public class StatusCommandDTO : IRequest<Unit>
    {

        public short Id { get; set; }
    }
}
