using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {   // RuleFor= Bu kural kimin için?       her p için ProductName minimum 2 karakter olamalıdır.      p=Product
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);  // UnitPrice 0'dan daha fazla olmalıdır.
            RuleFor(P => P.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            // her p için UnitPrice         10 olmalıdır     ne zaman   her p için CategoryId 1 olduğu zaman.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı"); // ProductName A ile başlamalıdır. 
        }

        private bool StartWithA(string arg) //arg = gönderiğim parametre yani ProductName 
        {
            return arg.StartsWith("A"); // A ile başlıyosa true döner başlamazsa false döner.
        }
    }
}
