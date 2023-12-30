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
                .MaximumLength(255)
                .MinimumLength(3)
                .WithMessage("Please enter a value that is between 3 and 255 char!");

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("Can't accept empty description value!")
                .MaximumLength(255)
                .MinimumLength(3)
                .WithMessage("Please enter a value that is between 3 and 150 char!");
        }
    }
}
