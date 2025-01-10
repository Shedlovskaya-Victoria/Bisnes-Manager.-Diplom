using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<TRequest> _logger;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators, ILogger<TRequest> logger)
        {
            _validators = validators;
            _logger = logger;
        }


        /// <summary>
        /// т.к. делегат next - не принимает TRequest в качестве параметра, то мы можем изменять входной запрос, но не заменять его.
        /// </summary>
        /// <param name="request">это обьект запроса переданный через метод IMdeator.Send()</param>
        /// <param name="next">асинхронное продолжение для следующего действия в цепочке вызовов нашего behavoira</param>
        /// <param name="cancellationToken">токен пользователя</param>
        /// <returns></returns>
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken , RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failture = _validators
                .Select(v=>v.Validate(context))
                .SelectMany(result=>result.Errors)
                .Where(failture=>failture != null)
                .ToList();
            if(failture.Any())
            {
                throw new ValidationException(failture);
            }
                 
          
            try
            {
                return  next();
            }
            catch (ValidationException ex)
            {
                //most likely internal server error
                //better retain error as an inner exception for debugging
                //but also return that an error occurred
               
                throw ex;
            }
        }
    }
}
