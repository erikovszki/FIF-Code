namespace FIF.Registration.Middlewares
{
    /// <summary>
    /// Middleware to handle global exceptions in the application.
    /// It catches exceptions thrown during the request processing pipeline,
    /// sets the response status code to 500, and writes the exception message
    /// to the response.
    /// </summary>
    public class GlobalExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(ex.Message);
                //TODO: Log the exception then return a generic error message to the client.
            }
        }
    }
}
