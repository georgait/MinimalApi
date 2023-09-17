namespace WebApi.Endpoints.Todos.Constants;

public static class RouteConstants
{
    public const string GetTodos = $"{BaseRoute.Base}/todos";
    public const string GetTodo = $"{BaseRoute.Base}/todos/{{id}}";
    public const string CreateTodo = $"{BaseRoute.Base}/todos";
}
