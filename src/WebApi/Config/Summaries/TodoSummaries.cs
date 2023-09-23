namespace WebApi.Config.Summaries;

public static class TodoSummaries
{
    public static OpenApiOperation CreateTodoSummary(OpenApiOperation operation)
    {
        return new OpenApiOperation(operation)
        {
            Tags = new List<OpenApiTag> { new() { Name = "TODOs" } },
            Summary = "Create a todo",
            Description = "Create a todo",
            Responses = new OpenApiResponses
            {
                ["200"] = new OpenApiResponse
                {
                    Description = "Created",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["application/json"] = new OpenApiMediaType
                        {
                            Schema = new OpenApiSchema
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.Schema,
                                    Id = "Todo"
                                }
                            }
                        }
                    }
                },
                ["400"] = new OpenApiResponse
                {
                    Description = "Bad Request",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["application/problem+json"] = new OpenApiMediaType
                        {
                            Schema = new OpenApiSchema
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.Schema,
                                    Id = "BadRequest"
                                }
                            }
                        }
                    }
                }
            }
        };
    }

    public static OpenApiOperation GetTodoSummary(OpenApiOperation operation)
    {
        return new(operation)
        {
            Tags = new List<OpenApiTag> { new() { Name = "TODOs" } },
            Summary = "Get todo by id",
            Description = "Get todo by id"
        };
    }

    public static OpenApiOperation GetTodosSummary(OpenApiOperation operation)
    {
        return new(operation)
        {
            Tags = new List<OpenApiTag> { new() { Name = "TODOs" } },
            Summary = "Get all todos",
            Description = "Get all todos"
        };
    }
}
