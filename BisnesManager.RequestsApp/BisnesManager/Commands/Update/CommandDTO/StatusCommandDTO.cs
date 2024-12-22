using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandDTO
{
    public class StatusCommandDTO : IRequest
    {

        public short Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
