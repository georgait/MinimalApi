using WebApi.Config.Summaries;

namespace WebApi.Endpoints.Todos;

public class GetTodoEndpoint : IEndpoint
{
    const string EndpointName = "Get todo by id";

    public void MapEndpoint(IEndpointRouteBuilder route)
    {
        route.MapGet(Routes.GetTodo, Handle)
            .WithName(EndpointName)
            .WithOpenApi(TodoSummaries.GetTodoSummary);
    }

    internal static Results<Ok<TodoDto>, NotFound> Handle([FromRoute] int id)
    {
        // TODO: get todo from database
        var todo = new TodoDto(id, "Todo title", "Todo description");

        return TypedResults.Ok(todo);
    }
}
