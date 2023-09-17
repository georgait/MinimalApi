namespace WebApi.Endpoints.Todos;

public class GetTodoEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder route)
    {
        route.MapGet(RouteConstants.GetTodo, Handle)
            .WithName(EndpointName.GetTodoById)
            .WithOpenApi(TodoSummaries.GetTodoSummary);
    }

    internal static Results<Ok<TodoDto>, NotFound> Handle([FromRoute] int id)
    {
        // TODO: get todo from database
        var todo = new TodoDto(id, "Todo title", "Todo description");

        return TypedResults.Ok(todo);
    }
}
