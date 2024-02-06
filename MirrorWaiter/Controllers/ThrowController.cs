using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MirrorWaiter.Controllers
{
    public class ThrowController : ControllerBase
    {
        [Route("/error")]
        public IActionResult HandleError() => Problem();

        [Route("/error-dev")]
        public IActionResult HandleErrorDev([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem(
                    detail: exceptionHandlerFeature.Error.StackTrace,
                    title: exceptionHandlerFeature.Error.Message
                );
        }
    }
}
