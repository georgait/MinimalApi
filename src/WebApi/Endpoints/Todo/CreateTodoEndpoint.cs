using WebApi.Config.Summaries;

namespace WebApi.Endpoints.Todos;

public class CreateTodoEndpoint : IEndpoint
{
    const string EndpointName = "Create todo";

    public void MapEndpoint(IEndpointRouteBuilder route)
    {
        route.MapPost(Routes.CreateTodo, Handle)
            .WithName(EndpointName)
            .WithOpenApi(TodoSummaries.CreateTodoSummary)
            .AddEndpointFilter<ValidationFilter<CreateTodoDto>>();
    }

    internal static Results<Ok<TodoDto>, BadRequest<IEnumerable<string>>> Handle([FromBody] CreateTodoDto request)
    {
        // TODO: create todo in database
        var todo = new TodoDto(1, request.Title, request.Description);

        return TypedResults.Ok(todo);
    }
}
