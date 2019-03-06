using Microsoft.AspNetCore.Mvc;

namespace RPlay.API.Attributes
{
    public sealed class PrivateRouteAttribute : RouteAttribute
    {
        public PrivateRouteAttribute(string template) : base($"private/{template}")
        {
        }
    }
}