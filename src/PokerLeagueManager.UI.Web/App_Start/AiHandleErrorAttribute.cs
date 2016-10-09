﻿using System;
using System.Web.Mvc;
using Microsoft.ApplicationInsights;

namespace PokerLeagueManager.UI.Web
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public sealed class AIHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext != null && filterContext.HttpContext != null && filterContext.Exception != null)
            {
                // If customError is Off, then AI HTTPModule will report the exception
                if (filterContext.HttpContext.IsCustomErrorEnabled)
                {
                    var ai = new TelemetryClient();
                    ai.TrackException(filterContext.Exception);
                }
            }

            base.OnException(filterContext);
        }
    }
}