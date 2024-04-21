using FluentValidation;
using WebApplication1.Models.Talepler;

public class TalepValidator : AbstractValidator<Talep>
{
    public TalepValidator()
    {
        RuleFor(talep => talep.CustomerId).NotEmpty().WithMessage("Customer Id is required.");
        RuleFor(talep => talep.Complaint).NotEmpty().WithMessage("Complaint is required.");
    }
}
