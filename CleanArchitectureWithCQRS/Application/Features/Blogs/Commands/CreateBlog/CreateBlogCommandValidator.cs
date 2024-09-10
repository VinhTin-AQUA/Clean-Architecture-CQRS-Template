using FluentValidation;

namespace Application.Features.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithErrorCode("400").WithMessage("Tên blog là bắt buộc")
                .NotNull().WithErrorCode("400").WithMessage("Tên blog là bắt buộc");

            RuleFor(p => p.Description)
                .NotEmpty().WithErrorCode("400").WithMessage("mô tả là bắt buộc")
                .NotNull().WithErrorCode("400").WithMessage("mô tả là bắt buộc");

            RuleFor(p => p.Author)
                .NotEmpty().WithErrorCode("400").WithMessage("tác giả là bắt buộc")
                .NotNull().WithErrorCode("400").WithMessage("tác giả là bắt buộc");
        }
    }
}
