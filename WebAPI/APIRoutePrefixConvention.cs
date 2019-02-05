using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using System.Collections.Generic;

namespace rebulanyum.CatalogApp.WebAPI
{
    public partial class Startup
    {
        internal class APIRoutePrefixConvention : IControllerModelConvention, IControllerConvention
        {
            bool includeBoth;
            AttributeRouteModel prefixRouteModel;
            public APIRoutePrefixConvention(string prefix, bool optional = false)
            {
                this.prefixRouteModel = new AttributeRouteModel(new RouteAttribute(prefix));
                this.includeBoth = optional;
            }
            public virtual void Apply(ControllerModel controller)
            {
                var selectors = new List<SelectorModel>();
                foreach (var selector in controller.Selectors)
                {
                    if (includeBoth)
                    {
                        selectors.Add(new SelectorModel(selector));
                    }
                    if (selector.AttributeRouteModel != null)
                    {
                        selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(prefixRouteModel, selector.AttributeRouteModel);
                    }
                    else
                    {
                        selector.AttributeRouteModel = prefixRouteModel;
                    }
                }
                foreach (var selector in selectors)
                {
                    controller.Selectors.Add(selector);
                }
            }

            public virtual bool Apply(IApiVersionConventionBuilder controller, ControllerModel controllerModel)
            {
                this.Apply(controllerModel);
                return true;
            }
        }
    }
}
