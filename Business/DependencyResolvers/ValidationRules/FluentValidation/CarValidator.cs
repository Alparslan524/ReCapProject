using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);

            //RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(5000).When(c => c.BrandId == 2); 
            //Mesela markası bmw olan(brandID==2) araçlarda daily price 5000'den büyük olmalıdır

            RuleFor(c => c.Description).Must(StartWithHello);

        }

        private bool StartWithHello(string arg)
        {
            return arg.StartsWith("Hello");//Hello ile başlayacaksa true dönecek
        }
    }
}
