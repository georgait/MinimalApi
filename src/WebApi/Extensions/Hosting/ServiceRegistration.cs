namespace WebApi.Extensions.Hosting;

public static class ServiceRegistration
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        
        builder.Services.AddSwagger();
        
        builder.Services.AddRateLimiting();

        /* 
           Adds authentication and authorization.
           In order to use the below services uncomment 
           the corresponding private methods in this file
       */
        //builder.Services.AddDefaultAuthentication(builder.Configuration);
        //builder.Services.AddDefaultAuthorization();

        // Delete the bellow line if you have authenticated endpoints, 
        // instead use the above two lines of code    
        builder.Services.AddAuthorization();

        builder.Services.AddCors();

        builder.Services.Scan(s => s.FromAssemblyOf<IEndpoint>()
            .AddClasses(classes => classes.AssignableTo<IEndpoint>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

        builder.Services.AddValidatorsFromAssemblyContaining<CreateTodoDtoValidator>();

    }

    private static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {        
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = """
                            JWT Authorization header using the Bearer scheme.
                            Enter 'Bearer' [space] and then your token in the text input below.
                            Example: 'Bearer 12345abcdef'
                            """,
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });

            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Template: Place here the name of your API",

            });
        });
    }

    //private static void AddDefaultAuthentication(this IServiceCollection services, IConfiguration configuration)
    //{
    //    services.AddAuthentication("Bearer")
    //         .AddJwtBearer("Bearer", options =>
    //         {
    //             options.Authority = configuration["IdentityServer:Authority"];

    //             options.TokenValidationParameters = new TokenValidationParameters
    //             {
    //                 ValidateAudience = false
    //             };
    //         });
    //}
        
    //private static void AddDefaultAuthorization(this IServiceCollection services)
    //{
    //    services.AddAuthorization(options =>
    //    {
    //        options.AddPolicy(AuthorizationPolicies.ApiScope, policy =>
    //        {
    //            policy.RequireAuthenticatedUser();
    //            policy.RequireClaim("scope", "api");
    //        });
    //    });
    //}
        
    private static void AddRateLimiting(this IServiceCollection services)
    {
        services.AddRateLimiter(options =>
        {
            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
                RateLimitPartition.GetFixedWindowLimiter("GlobalLimiter", partition => new FixedWindowRateLimiterOptions
                {
                    AutoReplenishment = true,
                    PermitLimit = 100,
                    QueueLimit = 0,
                    Window = TimeSpan.FromMinutes(1),
                }));

            options.RejectionStatusCode = 429;
        });
    }
    private static void AddCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(Cors.CorsPolicy, builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
    }
}
