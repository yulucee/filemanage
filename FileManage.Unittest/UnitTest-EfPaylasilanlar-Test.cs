using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Transactions;
using Effort;
using Effort.DataLoaders;
using FileManageDAL.BusinessLayer.Abstract;
using FileManageDAL.BusinessLayer.Concrete;
using FileManageDAL.BusinessLayer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace FileManage.Unittest
{
    [TestClass]
    public class UnitTest_EfPaylasilanlar_Test
    {
        private IPaylasilanlarDal paylasdal;
        public UnitTest_EfPaylasilanlar_Test()
        {
            this.paylasdal = new EfPaylasilanlarDal();
        }
        public UnitTest_EfPaylasilanlar_Test(IPaylasilanlarDal paylasdal)
        {
            this.paylasdal = paylasdal;
        }
        [TestMethod]
        public void Index_Test_Pass()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var expected = 1;
                var id = 5;
                var result = paylasdal.Index(id);
                Assert.AreEqual(expected, result.Code);
            }
        }
        [TestMethod]
        public void KlasorAc_Test_Pass()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var expected = 0;
                var id = 1459;
                var result = paylasdal.PaylasilanlariAc(id);
                Assert.AreEqual(expected, result.Code);
            }
        }
        [TestMethod]
        public void KlasorAc_Test_Scenario2()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var expected = 0;
                var id = 1000;
                var result = paylasdal.PaylasilanlariAc(id);
                Assert.AreEqual(expected, result.Code);
            }
        }
        [TestMethod]
        public void Paylastiklarim_Success_Test()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var id = 200;
                var result = paylasdal.Paylastiklarim(id);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void PaylastiklarimiAc_Test_Success()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var id = 100;
                var expected = 1;
                var result = paylasdal.PaylastiklarimiAc(id);
                Assert.AreEqual(expected, result.Code);
            }
        }
        [TestMethod]
        public void Bilgi_Test_IdNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var expecteed = 0;
                var a = "none";
                var result = paylasdal.Bilgi(a);
                Assert.AreEqual(expecteed, result.Code);
            }
        }
        [TestMethod]
        public void Bilgi_Test_ListOkCheck()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var id = "*1457";
                var result = paylasdal.Bilgi(id);
                var expected = 1;
                Assert.AreEqual(expected, result.Code);
            }
        }
        [TestMethod]
        public void Bilgi_IdNotExist()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var id = "*1000";
                var result = paylasdal.Bilgi(id);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void BenimlePaylasilanlarBilgi()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var expected = 1;
                var id = "*1457";
                var result = paylasdal.BenimlePaylasilanlarBilgi(id);
                Assert.AreEqual(expected, result.Code);
            }
        }
        [TestMethod]
        public void BenimlePaylasilanlarBilgi_Test_IdCheck()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var expected = 1;
                var id = "*1457";
                var result = paylasdal.BenimlePaylasilanlarBilgi(id);
                Assert.AreEqual(expected, result.Code);
            }
        }
        [TestMethod]
        public void BenimlePaylasilanlarBilgi_Test_IdNotExist()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var expected = 4;
                var id = "*1000";
                var result = paylasdal.BenimlePaylasilanlarBilgi(id);
                Assert.AreEqual(expected,result.Code);
            }
        }
        [TestMethod]
        public void YetkiKaldir_IdZero()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var id = 0;
                var expected = 3;
                var result = paylasdal.YetkiKaldirma(id);
                Assert.AreEqual(expected, result.Code);
            }
        }
        [TestMethod]
        public void YetkiKaldir_IdNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var expected = 3;
                var result = paylasdal.YetkiKaldirma(null);
                Assert.AreEqual(expected, result.Code);
            }
        }
        [TestMethod]
        public void YetkiKaldir_PaylasmaId_Test()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var id = 1787;
                var result = paylasdal.YetkiKaldirma(id);
                Assert.IsNotNull(result);
            }   
        }
        [TestMethod]
        public void YetkiKaldir_TableNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var exp = 4;
                var id = 100;
                var result = paylasdal.YetkiKaldirma(id);
                Assert.AreEqual(exp,result.Code);
            }
        }
        [TestMethod]
        public void YetkiKaldir_AltKlasor_null()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var id = 1787;
                var result = paylasdal.YetkiKaldirma(id);
                var exp = 1;
                Assert.AreEqual(exp, result.Code);
            }
        }
    }
}
