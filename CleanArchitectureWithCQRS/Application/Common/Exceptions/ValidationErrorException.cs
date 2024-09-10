namespace Application.Common.Exceptions
{
    public class ValidationErrorException : Exception
    {
        public object Errors { get; }

        public ValidationErrorException(object errors)
        {
            Errors = errors;
        }
    }
}
