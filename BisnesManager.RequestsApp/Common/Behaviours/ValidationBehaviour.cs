using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;


namespace BisnesManager.RequestsApp.Common.Behaviours
{
    //что-то типа фильтра, отработает до вызова действий контроллера
    //а класс нужен, чтобы работали все другие валидаторы
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;


        /// <summary>
        /// т.к. делегат next - не принимает TRequest в качестве параметра, то мы можем изменять входной запрос, но не заменять его.
        /// </summary>
        /// <param name="request">это обьект запроса переданный через метод IMdeator.Send()</param>
        /// <param name="next">асинхронное продолжение для следующего действия в цепочке вызовов нашего behavoira</param>
        /// <param name="cancellationToken">токен пользователя</param>
        /// <returns></returns>
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failture = _validators
                .Select(v=>v.Validate(context))
                .SelectMany(result=>result.Errors)
                .Where(failture=>failture != null)
                .ToList();
            if(failture.Count != 0)
            {
                throw new ValidationException(failture);
            }
            return next();
        }
    }
}
