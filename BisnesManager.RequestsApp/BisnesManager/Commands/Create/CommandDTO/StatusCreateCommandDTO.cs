using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Create.CommandDTO
{
    public class StatusCreateCommandDTO : IRequest
    {
        public string Title { get; set; } = null!;
    }
}
