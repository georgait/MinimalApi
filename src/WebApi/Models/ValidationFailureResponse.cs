namespace WebApi.Models;

public class ValidationFailureResponse
{
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
}

public static class ValidationFailureResponseExtensions
{
    public static ValidationFailureResponse ToValidationFailureResponse(this IEnumerable<FluentValidation.Results.ValidationFailure> failures)
    {
        return new()
        {
            Errors = failures.Select(x => x.ErrorMessage)
        };
    }
}
