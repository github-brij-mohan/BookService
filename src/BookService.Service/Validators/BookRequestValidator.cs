using BookService.Service.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookService.Service.Validators
{
    public class BookRequestValidator: AbstractValidator<BookRequest>
    {
        public BookRequestValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("The name field is required in the request")
                .Length(1, 200)
                .WithMessage("The length of name field should be less than 200 characters");

            RuleFor(x => x.Author)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("The author field is required in the request")
                .Length(1, 200)
                .WithMessage("The length of author field should be less than 200 characters");

            RuleFor(x => x.Price)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("The price field is required in the request");
        }
    }
}
