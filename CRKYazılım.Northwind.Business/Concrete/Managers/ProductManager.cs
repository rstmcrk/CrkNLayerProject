using CRKYazılım.Northwind.Business.Abstract;
using CRKYazılım.Northwind.DataAccess.Abstract;
using CRKYazılım.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRKYazılım.Core.CrossCuttingConcerns.Validation.FluentValidation;
using CRKYazılım.Core.Aspects.Postsharp;
using CRKYazılım.Core.Aspects.Postsharp.ValidationAspects;
using CRKYazılım.Core.Aspects.Postsharp.TransactionAspects;
using CRKYazılım.Core.Aspects.Postsharp.CacheAspect;
using CRKYazılım.Core.CrossCuttingConcerns.Caching.Microsoft;
using System.Data.Entity.Infrastructure.Interception;
using CRKYazılım.Core.Aspects.Postsharp.LogAspect;
using CRKYazılım.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using DatabaseLogger = CRKYazılım.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers.DatabaseLogger;

namespace CRKYazılım.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _ProductDal;

        public ProductManager(IProductDal productDal)
        {
            _ProductDal = productDal;
        }

        [FluentValidationAspect(typeof(ValidationRules.FluentValidation.ProductValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            
            return _ProductDal.Add(product);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        public List<Product> GetAll()
        {
            return _ProductDal.GetList();
        }

        public Product GetById(int id)
        {
            return _ProductDal.Get(p => p.ProductId == id);
        }

        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _ProductDal.Add(product1);
            // Business Codes
            _ProductDal.Update(product2);
        }

        [FluentValidationAspect(typeof(ValidationRules.FluentValidation.ProductValidatior))]
        public Product Update(Product product)
        {
            return _ProductDal.Update(product);
        }
    }
}
