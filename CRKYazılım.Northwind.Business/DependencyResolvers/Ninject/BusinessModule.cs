using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using CRKYazılım.Northwind.Business.Abstract;
using CRKYazılım.Northwind.Business.Concrete.Managers;
using CRKYazılım.Northwind.DataAccess.Abstract;
using CRKYazılım.Northwind.DataAccess.Concrete.EntityFramework;
using CRKYazılım.Core.DataAccess;
using CRKYazılım.Core.DataAccess.EntityFramework;
using CRKYazılım.Core.DataAccess.NHihabernate;
using CRKYazılım.Northwind.DataAccess.Concrete.NHibernate.Helpers;


namespace CRKYazılım.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<System.Data.Entity.DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
