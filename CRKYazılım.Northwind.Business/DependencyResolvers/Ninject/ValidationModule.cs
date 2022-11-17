using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using FluentValidation;
using CRKYazılım.Northwind.Entities.Concrete;
using CRKYazılım.Northwind.Business.ValidationRules.FluentValidation;



namespace CRKYazılım.Northwind.Business.DependencyResolvers.Ninject
{
    public class ValidationModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidatior>().InSingletonScope();
        }
    }
}
