using Microsoft.AspNetCore.Mvc.Filters;

namespace BirdFarmAPI.ActionFilterAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class FirebaseAutorized : ActionFilterAttribute, IActionFilter
    {

    }
}
