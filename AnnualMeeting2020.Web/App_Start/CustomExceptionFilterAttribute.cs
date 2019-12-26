using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnnualMeeting2020.Web
{
    public class CustomExceptionFilterAttribute : HandleErrorAttribute, IExceptionFilter
    {
        static readonly ILog log = LogManager.GetLogger(typeof(CustomExceptionFilterAttribute));
        public override void OnException(ExceptionContext filterContext)
        {
            //log4net组件,用于日志记录。
            var message = $"消息类型：{filterContext.Exception.GetType().Name}\r\n" +
                $"消息内容：{filterContext.Exception.Message}\r\n" +
                $"引发异常的方法：{filterContext.Exception.TargetSite}\r\n" +
                $"引发异常源：{filterContext.Exception.Source + filterContext.Exception.StackTrace}";
            log.Error(message);
            filterContext.ExceptionHandled = true;
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
                filterContext.Result = new RedirectResult("/Error/Error");

            base.OnException(filterContext);
        }
    }
}