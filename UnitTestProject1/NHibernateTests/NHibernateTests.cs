﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CRKYazılım.Nortwind.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NHibernateTests
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            //NhProductDal productDal = new NhProductDal(new SqlServerHelper());

            //var result = productDal.GetList();

            //Assert.AreEqual(78, result.Count);
        }

        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            //NhProductDal productDal = new NhProductDal(new SqlServerHelper());

            //var result = productDal.GetList(p => p.ProductName.Contains("ab"));

            //Assert.AreEqual(4,result.Count);
        }
    }
}
