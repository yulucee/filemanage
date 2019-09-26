using FileManageDAL.BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace FileManage.Filtreler
{
    public class ActionFiltre : ActionFilterAttribute, IExceptionFilter
    {
        filemanagerDB db = new filemanagerDB();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int kullaniciid = (int)filterContext.HttpContext.Session["kullaniciId"];
            var parameters = filterContext.ActionParameters;
            var mesaj = "";
            foreach (var item in parameters)
            {
                // msaj = msaj + "," + item.Key + ":" + item.Value;
                mesaj = item.Key + ": " + item.Value;

            }
            db.ActionFilters.Add(new ActionFilter()
            {
                Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Action = filterContext.ActionDescriptor.ActionName,
                IpAdresi = filterContext.HttpContext.Request.UserHostAddress,
                Tarih = DateTime.Now,
                LinkNumaralari = mesaj,
                KullaniciKim = kullaniciid,
                Bilgi = "OnActionExecuting"
            });
            base.OnActionExecuting(filterContext);
            db.SaveChanges();
        }
        public bool FilterAction(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.ActionName != "DosyaINYukle") return true;
            return false;
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            int kullaniciid = (int)filterContext.HttpContext.Session["kullaniciId"];
            db.ActionFilters.Add(new ActionFilter()
            {
                Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Action = filterContext.ActionDescriptor.ActionName,
                IpAdresi = filterContext.HttpContext.Request.UserHostAddress,
                Tarih = DateTime.Now,
                KullaniciKim = kullaniciid,
                Bilgi = "OnActionExecuted"
            });
            db.SaveChanges();
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            int kullaniciid = (int)filterContext.HttpContext.Session["kullaniciId"];
            db.ActionFilters.Add(new ActionFilter()
            {
                Controller = filterContext.RouteData.Values["controller"].ToString(),
                Action = filterContext.RouteData.Values["action"].ToString(),
                IpAdresi = filterContext.HttpContext.Request.UserHostAddress,
                Tarih = DateTime.Now,
                KullaniciKim = kullaniciid,
                Bilgi = "OnResultExecuting"
            });
            db.SaveChanges();
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            int kullaniciid = (int)filterContext.HttpContext.Session["kullaniciId"];
            db.ActionFilters.Add(new ActionFilter()
            {
                Controller = filterContext.RouteData.Values["controller"].ToString(),
                Action = filterContext.RouteData.Values["action"].ToString(),
                IpAdresi = filterContext.HttpContext.Request.UserHostAddress,
                Tarih = DateTime.Now,
                KullaniciKim = kullaniciid,
                Bilgi = "OnResultExecuted"
            });
            db.SaveChanges();
        }
        public void OnException(ExceptionContext filterContext)
        {
            int kullaniciid = (int)filterContext.HttpContext.Session["kullaniciId"];
            db.ActionFilters.Add(new ActionFilter()
            {
                Controller = filterContext.RouteData.Values["controller"].ToString(),
                Action = filterContext.RouteData.Values["action"].ToString(),
                IpAdresi = filterContext.HttpContext.Request.UserHostAddress,
                Tarih = DateTime.Now,
                KullaniciKim = kullaniciid,
                Bilgi = filterContext.Exception.Message
            });
            db.SaveChanges();
        }
    }
}