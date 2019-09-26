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
    public class EfDosya_Test
    {
        private IDosyaDal dosyadal;
        public EfDosya_Test()
        {
            this.dosyadal = new EfDosyaDal();
        }
        public EfDosya_Test(IDosyaDal dosyadal)
        {
            this.dosyadal = dosyadal;
        }
        [TestMethod]
        public void Edits_DosyaId_Check_Pass()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                int a = 1457;
                string b = "yeni";
                var result = dosyadal.Edits(a, b);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void Edits_DosyaId_Check_Fail()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                int a = 1234;
                string b = "action";
                var result = dosyadal.Edits(a, b);
                Assert.IsFalse(result.Data);
            }
        }
        [TestMethod]
        public void Edits_DosyaAdi_Check_Pass()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                int a = 1457;
                string b = "yeni";
                var result = dosyadal.Edits(a, b);
                Assert.IsFalse(result.Data);
            }
        }
        [TestMethod]
        public void Sil_Check_Pass()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                int a = 1457;
                var result = dosyadal.Sil(a);
                Assert.IsTrue(result.Data);
            }
        }
        [TestMethod]
        public void Sil_Check_Fail()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                int a = 1234;
                var result = dosyadal.Sil(a);
                Assert.IsFalse(result.Data);
            }
        }
        [TestMethod]
        public void IcShare_DosyaId_Null()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var expectedvalue = 0;
                string a = null;
                string k_id = "36";
                string c_Val = "1";
                var result = dosyadal.IcShare(a, k_id, c_Val);
                Assert.AreEqual(expectedvalue, result.Code);
            }
        }
        [TestMethod]
        public void IcShare_KullaniciId_Null()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var expectedvalue = 0;
                string a = "1234";
                string k_id = null;
                string c_Val = "1";
                var result = dosyadal.IcShare(a, k_id, c_Val);
                Assert.AreEqual(expectedvalue, result.Code);
            }
        }
        [TestMethod]
        public void IcShare_CheckValue_Null()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var expectedvalue = 0;
                string a = "1234";
                string k_id = "36";
                string c_Val = null;
                var result = dosyadal.IcShare(a, k_id, c_Val);
                Assert.AreEqual(expectedvalue, result.Code);
            }
        }
        [TestMethod]
        public void IcShare_Completed_Successful()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var expectedvalue = 1;
                string a = "*1457";
                string k_id = "36";
                string c_Val = "1";
                var result = dosyadal.IcShare(a, k_id, c_Val);
                Assert.AreEqual(expectedvalue, result.Code);
            }
        }
        [TestMethod]
        public void IcShare_Klasor_Share_Success()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var expectedvalue = 1;
                string a = "*1460";
                string k_id = "36";
                string c_Val = "1";
                var result = dosyadal.IcShare(a, k_id, c_Val);
                Assert.AreEqual(expectedvalue, result.Code);
            }
        }

    }
}
