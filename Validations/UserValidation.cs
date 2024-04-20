﻿using FluentValidation;
using SaleOfProductsJWT.Contracts;


namespace SaleOfProductsJWT.Validations
{
    public class UserValidation : AbstractValidator<RequestCreateUser>
    {
        public UserValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Имя пользователя обязательно для заполнения");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email обязателен для заполнения").EmailAddress().WithMessage("Введите корректный Email");
        }
    }
}
