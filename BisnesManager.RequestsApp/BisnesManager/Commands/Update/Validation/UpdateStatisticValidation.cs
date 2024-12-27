using BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Update.Validation
{
    public class UpdateStatisticValidation : AbstractValidator<StatisticUpdateCommandDTO>
    {
        public UpdateStatisticValidation() 
        {
            RuleFor(statistic=>statistic.Id).NotNull().NotEmpty();
            RuleFor(statistic=>statistic.IdUser).NotNull().NotEmpty();
            RuleFor(statistic=>statistic.LevelResponibility).NotNull().NotEmpty();
            RuleFor(statistic=>statistic.DateCreate).NotNull().NotEmpty();
            RuleFor(statistic=>statistic.QualityWork).NotNull().NotEmpty();
            RuleFor(statistic=>statistic.EffectivCommunication).NotNull().NotEmpty();
            RuleFor(statistic=>statistic.HardSkils).NotNull().NotEmpty();
            RuleFor(statistic => statistic.SoftSkils).NotNull().NotEmpty();

        }
    }
}
