using CarsCms.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsCms.Validation
{
    public class EngineValidator : AbstractValidator<Engine>
    {
        public EngineValidator()
        {
            //tutaj tworzymy walidację - tutaj jest to komponent, trzeba go jeszcze wywołać 
            //to jest tylko reguła
            RuleFor(x => x.Name).NotEmpty().WithMessage("Pole NAZWA silnika nie może być puste");
            RuleFor(x => x.Capacity).LessThan(6000).WithMessage("Pojemność silnika jest za duża. Musi być mniejsza niż 6000");
            RuleFor(x => x.Capacity).GreaterThan(1500).WithMessage("Pojemność silnika jest za mała. Musi być większa niż 1500");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Nazwa jest za któtka");
            RuleFor(x => x.Name).MaximumLength(16).WithMessage("Nazwa jest za długa");
            RuleFor(x => x.Name).Must(name => BigLetter(name)).WithMessage("Nazwa musi zaczynać się od wielkiej litery");
            
            RuleFor(x => x.Capacity).NotEmpty().WithMessage("Pole POJEMNOŚĆ silnika nie może być puste");

            RuleFor(x => x).Must(x => PojemnoscWidelki(x)).WithMessage("Nazwa musi zaczynać się od wielkiej litery");

            RuleFor(x => x).Must(x => PojemnoscName(x)).WithMessage("Błąd błąd błąd");


        }



        public bool BigLetter(string name)
        {
            if (char.IsUpper(name[0]))
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }


        public bool PojemnoscWidelki (Engine engine)
        {
            if (engine.Capacity > 1589 && engine.Capacity < 1601) ;

            {
                if (engine.Weight > 650)
                {
                    return true;
                }

                else
                {
                    return false;
                }
                return true; 

            }
        }








        public bool PojemnoscName (Engine engine)
        {
            if (engine.Capacity / 10 > 20 && engine.Name == "AAA")
            {
                return false; 
            }
            else
            {
                return true;
            }
                 
        }

    }
}