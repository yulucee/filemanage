using System;
using System.Collections.Generic;
using System.Transactions;
using Effort;
using Effort.DataLoaders;
using FileManageDAL.BusinessLayer.Abstract;
using FileManageDAL.BusinessLayer.Concrete;
using FileManageDAL.BusinessLayer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FileManage.Unittest
{
   
    [TestClass]
    public class UnitTest1
    {
        private IHomeDal homeDal;        
        public UnitTest1()
        {
        //    Effort.Provider.EffortProviderConfiguration.RegisterProvider();
            this.homeDal = new EfHomeDal();
        }
        public UnitTest1(IHomeDal homeDal)
        {
            this.homeDal = homeDal;
        }
        //private filemanagerDB CreateContext()
        //{
        //    System.Data.Common.DbConnection connection = DbConnectionFactory.CreatePersistent("name=filemanagerDB");
        //    var context = new filemanagerDB(connection);
        //    return context;
        //}
        [TestMethod]
        [TestCategory("pass")]
        public void ParolamıUnuttum_Test_Pass()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                string username = "ibrahimyuluce@hotmail.com";
                var result = homeDal.ParolamıUnuttum(username);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        [TestCategory("fail")]
        public void ParolamıUnuttum_Test_Fail()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                string username = "ibrahim@hotmail.com";
                var result = homeDal.ParolamıUnuttum(username);
                Assert.IsFalse(result.Data);
            }
        }
        [TestMethod]
        public void KayıtOl_Test_Pass()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                string name = "gokhan";
                var soyad = "tas";
                var mail = "deneme@hotmail.com";
                var sifre = "1234";
                var result = homeDal.KayıtOl(name, soyad, mail, sifre);
                Assert.IsTrue(result.Data);
            }
        }
        [TestMethod]
        public void KayıtOl_Test_IsMailExist_Fail()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                string mail = "aleynaucak@hotmail.com";
                var result = homeDal.KayıtOl(null, null, mail, null);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void KayıtOl_Test_IsMailExist_Pass()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                string mail = "sdasda@hotmail.com";
                var result = homeDal.KayıtOl(null, null, mail, null);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void ResetPassWord_Password_NotSame()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                string mail = "ibrahimyuluce@hotmail.com";
                string tempcode = null;
                string code = null;
                string sifre1 = "1234";
                string sifre2 = "12345";
                var result = homeDal.ResetPassword(mail, tempcode, code, sifre1, sifre2);
                Assert.IsFalse(result.Data);
            }
        }
        [TestMethod]
        public void ResetPassword_Password_Same()
        { 
                var sifre1 = "1234";
                var sifre2 = "1234";
                Assert.AreSame(sifre1, sifre2);  
        }
        [TestMethod]
        public void KullanıcıEkle_TcKimlik_Sorgu()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                long tc = 16259411740;
                string adi = "ibrahim";
                string soyadi = "yülüce";
                string dogumyili = "13/02/1996";
                string sifre1 = "1234";
                string sifre2 = "1234";
                var result = homeDal.KullanıcıEkle(tc, adi, soyadi, dogumyili,null, sifre1, sifre2);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void KullanıcıEkle_TcKimlikIsFalse()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                long tc = 16259411741;
                string adi = "ibrahim";
                string soyadi = "yülüce";
                string dogumyili = "13/02/1996";
                string sifre1 = "1234";
                string sifre2 = "1234";
                var result = homeDal.KullanıcıEkle(tc, adi, soyadi, dogumyili, null, sifre1, sifre2);
                Assert.IsFalse(result.Data);
            }
        }
        [TestMethod]
        public void KullanıcıEkle_Password_Same()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                long tc = 16259411740;
                string adi = "ibrahim";
                string soyadi = "yülüce";
                string dogumyili = "13/02/1996";
                string sifre1 = "1234";
                string sifre2 = "1234";
                string mail = "ibrahimyuluce@hotmail.de";
                var result = homeDal.KullanıcıEkle(tc, adi, soyadi, dogumyili, mail, sifre1, sifre2);
                Assert.IsTrue(result.Data);
            }
        }
        [TestMethod]
        public void KullanıcıEkle_Password_NotSame()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                long tc = 16259411740;
                string adi = "ibrahim";
                string soyadi = "yülüce";
                string dogumyili = "13/02/1996";
                string sifre1 = "1234";
                string sifre2 = "12345";
                var result = homeDal.KullanıcıEkle(tc, adi, soyadi, dogumyili, null, sifre1, sifre2);
                Assert.IsFalse(result.Data);
            }
        }
    }
}
