namespace WebApi.Endpoints.Todos.RoutesConstants;

public static class Routes
{
    public const string GetTodos = $"{BaseRoute.Base}/todos";
    public const string GetTodo = $"{BaseRoute.Base}/todos/{{id}}";
    public const string CreateTodo = $"{BaseRoute.Base}/todos";
}
