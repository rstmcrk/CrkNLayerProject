using CRKYazılım.Core.DataAccess.EntityFramework;
using CRKYazılım.Northwind.DataAccess.Abstract;
using CRKYazılım.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRKYazılım.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {

    }
}
