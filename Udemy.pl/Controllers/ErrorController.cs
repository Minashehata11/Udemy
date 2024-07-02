namespace Udemy.pl.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        public ActionResult errors(int code)
        {
            return NotFound(new ErrorApiResponse(code));
        }
    }
}
