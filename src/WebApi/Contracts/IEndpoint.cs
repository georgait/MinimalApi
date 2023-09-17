namespace WebApi.Core;

public interface IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder route);
}
