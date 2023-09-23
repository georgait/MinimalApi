using WebApi.Config.Summaries;

namespace WebApi.Endpoints.Todos;

public class GetAllTodosEndpoint : IEndpoint
{
    const string EndpointName = "Get all todos";

    public void MapEndpoint(IEndpointRouteBuilder route)
    {
        route.MapGet(Routes.GetTodos, Handle)
            .WithName(EndpointName)
            .WithOpenApi(TodoSummaries.GetTodosSummary);
    }

    internal static Results<Ok<List<TodoDto>>, NotFound> Handle()
    {
        // TODO: get todos from database
        List<TodoDto> todos = new();

        if (todos.Count == 0)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(todos);
    }
}
