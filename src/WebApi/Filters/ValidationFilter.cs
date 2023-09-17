namespace WebApi.Filters;

public class ValidationFilter<T> : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();
        if (validator is not null)
        {
            var entity = context.Arguments
              .OfType<T>()
              .FirstOrDefault(a => a?.GetType() == typeof(T));

            if (entity is not null)
            {
                var validation = await validator.ValidateAsync(entity);
                if (validation.IsValid)
                {
                    return await next(context);
                }
                return Results.BadRequest(validation.Errors.ToValidationFailureResponse());
            }
            else
            {
                return Results.Problem("Could not find type to validate");
            }
        }
        return await next(context);
    }
}