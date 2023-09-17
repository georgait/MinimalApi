namespace WebApi.Extensions.Hosting;

public static class ApplicationPipeline
{
    public static void UseServices(this WebApplication app)
    {
        app.UseExceptionHandler();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Template: Name your api here");
            });
        }

        app.UseHttpsRedirection();

        //app.UseAuthentication();

        app.UseRateLimiter();

        app.UseCors(Cors.CorsPolicy);

        app.UseAuthorization();

        app.UseEndpoints();
    }

    private static void UseEndpoints(this WebApplication app)
    {
        // Setup group for all endpoints
        var root = app.MapGroup("api");
        
        // Add authorization to all endpoints
        //root.RequireAuthorization(AuthorizationPolicies.ApiScope);

        var endpoints = app.Services.GetServices<IEndpoint>();
        foreach (var endpoint in endpoints)
        {
            endpoint.MapEndpoint(root);
        }
    }

    private static void UseExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    // Try to "catch" in results via validation the 404 status code
                    // otherwise uncomment the below lines.
                    //context.Response.StatusCode = contextFeature.Error switch
                    //{
                    //    NotFoundException => StatusCodes.Status404NotFound,
                    //    _ => StatusCodes.Status500InternalServerError
                    //};

                    // Remove this line if you catch the 404 with above code
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                }

                var errorMessage = new
                {
                    context.Response.StatusCode,
                    contextFeature!.Error.Message
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(errorMessage));
            });
        });
    }

    // TODO: Move to separate file or use external library like `Ardalis.GuardClauses`
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the NotFoundException class with a specified name of the queried object and its key.
        /// </summary>
        /// <param name="objectName">Name of the queried object.</param>
        /// <param name="key">The value by which the object is queried.</param>
        public NotFoundException(string key, string objectName)
            : base($"Queried object {objectName} was not found, Key: {key}")
        {
        }

        /// <summary>
        /// Initializes a new instance of the NotFoundException class with a specified name of the queried object, its key,
        /// and the exception that is the cause of this exception.
        /// </summary>
        /// <param name="objectName">Name of the queried object.</param>
        /// <param name="key">The value by which the object is queried.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public NotFoundException(string key, string objectName, Exception innerException)
            : base($"Queried object {objectName} was not found, Key: {key}", innerException)
        {
        }
    }
}
