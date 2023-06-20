using System.Text.RegularExpressions;

namespace MySecondApplication.CustomConstraints
{
    public class MyCustomConstraints : IRouteConstraint
    {
        bool IRouteConstraint.Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var key = values.ContainsKey(routeKey);
            if (!key)
            {
                return false;
            }
            else
            {
                Regex regex = new Regex("^(apr|may|jun|july)$");
                string? value = Convert.ToString(values[routeKey]);
                if (regex.IsMatch(value!)) { return true; }
                else
                {
                    return false;
                }

            }
        }
    }
}
