using FluentValidation;
using YetDit.Application.ViewModels.Comments;

namespace YetDit.Application.Validators.Comments
{
    public class CreateCommentValidator : AbstractValidator<VM_Create_Comment>
    {
        public CreateCommentValidator()
        {
            RuleFor(c => c.Content)
                .NotEmpty()
                .WithMessage("Can't accept empty content value!")
                .MinimumLength(3)
                .WithMessage("Please enter a value that is greater than 3 char!");
        }
    }
}
