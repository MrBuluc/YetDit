using FluentValidation;
using YetDit.Application.ViewModels.Posts;

namespace YetDit.Application.Validators.Posts
{
    public class CreatePostValidator : AbstractValidator<VM_Create_Post>
    {
        public CreatePostValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("Can't accept empty title value!")
                .MinimumLength(3)
                .WithMessage("Please enter a value that is greater than 3 char!");

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("Can't accept empty description value!")
                .MinimumLength(3)
                .WithMessage("Please enter a value that is greater than 3 char!");
        }
    }
}
