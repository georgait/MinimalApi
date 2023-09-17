using FluentValidation;

namespace WebApi.Endpoints.Todos.DTOs;

public record CreateTodoDto(string? Title, string? Description);

public class CreateTodoDtoValidator : AbstractValidator<CreateTodoDto>
{
    public CreateTodoDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500);
    }
}
