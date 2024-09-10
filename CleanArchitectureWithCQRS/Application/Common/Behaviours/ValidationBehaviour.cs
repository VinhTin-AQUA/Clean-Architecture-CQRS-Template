using Application.Common.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(
                    validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults
                    .Where(v => v.Errors.Any())
                    .SelectMany(r => r.Errors)
                    .ToList();

                if(failures.Count > 0)
                {
                    // Tạo một object chứa danh sách lỗi
                    var errorResponse = new
                    {
                        StatusCode = 400,
                        Errors = failures.Select(f => new
                        {
                            f.PropertyName,
                            f.ErrorMessage
                        }).ToList()
                    };

                    // Trả về object lỗi dưới dạng lỗi 400
                    // middle ware được customer ở Program.cs
                    throw new ValidationErrorException(errorResponse); // Định nghĩa một Exception để xử lý trả về
                }
            }
            return await next();
        }
    }
}
