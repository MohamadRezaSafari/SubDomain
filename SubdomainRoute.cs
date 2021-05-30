using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Domain
{
    public class SubdomainRoute : Route
    {
        public SubdomainRoute(string domain, string url, RouteValueDictionary defaults)
            : this(domain, url, defaults, new MvcRouteHandler())
        {
        }

        public SubdomainRoute(string domain, string url, object defaults)
            : this(domain, url, new RouteValueDictionary(defaults), new MvcRouteHandler())
        {
        }

        public SubdomainRoute(string domain, string url, object defaults, IRouteHandler routeHandler)
            : this(domain, url, new RouteValueDictionary(defaults), routeHandler)
        {
        }

        public SubdomainRoute(string domain, string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler)
        {
            this.Domain = domain;
        }

        public string Domain { get; set; }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var routeData = base.GetRouteData(httpContext);
            routeData.Values.Add("client", httpContext.Request.Url.Host.Split('.').First());
            return routeData;
        }
    }
}