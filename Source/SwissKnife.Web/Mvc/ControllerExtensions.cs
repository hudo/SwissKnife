﻿/*
 * Original proposal for this class comes from Marin Rončević (http://github.com/mroncev).
 */
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace SwissKnife.Web.Mvc
{
    /// <preliminary/>
    /// <threadsafety static="true"/>
    public static class ControllerExtensions // TODO-IG: This type is in development. Review and refactoring is needed.
        // TODO-IG: Should this be extension or base class or we should offer both?
    // In this case we want to have Controller instead of less restrictive IController because we expect the object to have the RedirectToAction() method.
    {
        public static RedirectToRouteResult RedirectToAction<TController>(this Controller controller, Expression<Func<TController, ActionResult>> actionExpression) where TController : Controller
        {
            return RedirectToAction(controller, actionExpression, (object)null);
        }

        public static RedirectToRouteResult RedirectToAction<TController>(this Controller controller, Expression<Func<TController, Task<ActionResult>>> actionExpression) where TController : Controller
        {
            return RedirectToAction(controller, actionExpression, (object)null);
        }

        public static RedirectToRouteResult RedirectToAction<TController>(this Controller controller, Expression<Func<TController, ActionResult>> actionExpression, object routeValues) where TController : Controller
        {
            return RedirectToAction(controller, actionExpression, new RouteValueDictionary(routeValues));
        }

        public static RedirectToRouteResult RedirectToAction<TController>(this Controller controller, Expression<Func<TController, Task<ActionResult>>> actionExpression, object routeValues) where TController : Controller
        {
            return RedirectToAction(controller, actionExpression, new RouteValueDictionary(routeValues));
        }

        public static RedirectToRouteResult RedirectToAction<TController>(this Controller controller, Expression<Func<TController, ActionResult>> actionExpression, RouteValueDictionary routeValues) where TController : Controller
        {
            return RedirectToActionCore<TController>(controller, ControllerHelper.GetActionName(actionExpression), routeValues);
        }

        public static RedirectToRouteResult RedirectToAction<TController>(this Controller controller, Expression<Func<TController, Task<ActionResult>>> actionExpression, RouteValueDictionary routeValues) where TController : Controller
        {
            return RedirectToActionCore<TController>(controller, ControllerHelper.GetActionName(actionExpression), routeValues);
        }

        private static RedirectToRouteResult RedirectToActionCore<TController>(Controller controller, string actionName, RouteValueDictionary routeValues) where TController : Controller
        {
            var controllerName = ControllerHelper.GetControllerName<TController>();

            var methodInfo = typeof(TController).GetMethod("RedirectToAction", BindingFlags.NonPublic | BindingFlags.Instance, null, new[]
                                                                       {
                                                                           typeof (string), typeof (string),
                                                                           typeof (RouteValueDictionary)
                                                                       }, null);

            return (RedirectToRouteResult)methodInfo.Invoke(controller, new object[] { actionName, controllerName, routeValues });
        }
    }
}