using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using WebApi.Endpoints.Todos;
using WebApi.Endpoints.Todos.DTOs;
using FluentAssertions;


namespace UnitTests;

public class PostTodoEndpointTests
{
    //private readonly AppDbContext _context = Substitute.For<AppDbContext>();

    //[Fact]
    //public void CreateTodo_ShouldReturnOkResult_WhenTodoIsAdded()
    //{
    //    // Arrange
    //    var todoDto = new CreateTodoDto("title", "description");

    //    // Act
    //    var result = CreateTodoEndpoint.Handle(todoDto, _context);

    //    // Assert
    //    result.Result.As<Ok<Todo>>().StatusCode.Should().Be(StatusCodes.Status200OK);
    //}

    //[Fact]
    //public void CreateTodo_ShouldReturnBadRequestResult_WhenTodoIsNotAdded()
    //{
    //    // Arrange
    //    CreateTodoDto? todoDto = null;

    //    // Act
    //    var result = CreateTodoEndpoint.Handle(todoDto!, _context);

    //    // Assert
    //    result.Result.As<BadRequest<string>>().StatusCode.Should().Be(StatusCodes.Status400BadRequest);
    //}

    //[Fact]
    //public void CreateTodo_ShouldReturnBadRequestResult_WhenTodoIsNotValid()
    //{
    //    // Arrange
    //    var todoDto = new CreateTodoDto("", "");

    //    // Act
    //    var result = CreateTodoEndpoint.Handle(todoDto, _context);

    //    // Assert
    //    result.Result.As<BadRequest<string>>().StatusCode.Should().Be(StatusCodes.Status400BadRequest);
    //}
}
