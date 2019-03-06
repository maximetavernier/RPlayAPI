using Microsoft.AspNetCore.Mvc;

namespace RPlay.API.Attributes
{
    public sealed class PublicRouteAttribute : RouteAttribute
    {
        public PublicRouteAttribute(string template) : base($"public/{template}")
        {
        }
    }
}