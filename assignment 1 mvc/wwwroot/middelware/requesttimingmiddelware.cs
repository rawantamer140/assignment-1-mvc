namespace assignment_1_mvc.wwwroot.middelware
{
    public class requesttimingmiddelware
    {

        private readonly RequestDelegate _next;
        public requesttimingmiddelware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var startTime = DateTime.Now;
            // Call the next middleware in the pipeline
            await _next(context);
            var endTime = DateTime.Now;
            var elapsedTime = endTime - startTime;
            // Log the request timing information
            Console.WriteLine($"Request to {context.Request.Path} took {elapsedTime.TotalMilliseconds} ms");
        }
    }
}
