namespace WebApi.Endpoints.Todos;

public class GetAllTodosEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder route)
    {
        route.MapGet(RouteConstants.GetTodos, Handle)
            .WithName(EndpointName.GetTodos)
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
