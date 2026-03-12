using System.Text.Json;



namespace ProductApiDemo.WebAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)

        {
            try
            {
                await _next(context);
            }
            catch (ArgumentException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = ex.Message,
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
            catch (Exception ex) 
            {

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = ex.Message
                };
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }   
    }
}
