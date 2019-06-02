using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult OkOrNotFound(this ControllerBase controller, object model)
        {
            if (model == null)
            {
                return controller.NotFound();
            }

            return controller.Ok(model);
        }
    }
}
