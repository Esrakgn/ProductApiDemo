namespace ProductApiDemo.WebAPI.Middlewares
{
    public class RequestLoggingMiddleware
    {
        //sıradaki middleware’i ya da request hattındaki bir sonraki adımı temsil eder. ondan sonra kim çalışacak . bir kez atanır sonra değişmemesi istenir 
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //Bu middleware’in ana çalışma metodu. Bu metod, gelen HTTP isteğini işlemek ve ardından sıradaki middleware'e geçmek için kullanılır.
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"Request Path: {context.Request.Path}");//Burada gelen isteğin yolunu alıyoruz.

            await _next(context);

            //olmadan middleware zinciri devam etmez.
        }
    }
}
