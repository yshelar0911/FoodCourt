namespace FoodCourt
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Custom logic before the request is processed
            Console.WriteLine("Custom Middleware: Before request processing");

            // Call the next middleware in the pipeline
            await _next(context);

            // Custom logic after the request is processed
            Console.WriteLine("Custom Middleware: After request processing");
        }
    }

}
