namespace assignment_1_mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //registering the MVC services with the dependency injection container, which allows the application to use controllers and views for handling requests and generating responses
            //the method is called on the IServiceCollection interface, which is provided by the builder.Services property
            //the method configures the application to use the default conventions for routing, model binding, and view rendering, as well as other features such as validation and filters
            builder.Services.AddControllersWithViews();

            //----1
            //registering the MVC services with the dependency injection container, which allows the application to use controllers and views for handling requests and generating responses
            //the method is called on the IServiceCollection interface, which is provided by the builder.Services property
            //builder.Services.AddControllers();


            //----2
            //registering the MVC services with the dependency injection container, which allows the application to use controllers and views for handling requests and generating responses
            //the method is called on the IServiceCollection interface, which is provided by the builder.Services property
            //registers services required for MVC, including controllers, views, and Razor Pages, as well as other features such as model binding, validation, and filters
            // builder.Services.AddMvc();


            //----3

            //registering the MVC services with the dependency injection container, which allows the application to use controllers and views for handling requests and generating responses
            //the method is called on the IServiceCollection interface, which is provided by the builder.Services property
            //registers only the core services required for MVC, including controllers and action results, but does not include support for views or Razor Pages
            //builder.Services.AddMvcCore();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {

                //middleware that handles exceptions that occur during the processing of HTTP requests in a production environment. It is used to provide a user-friendly error page instead of displaying the default error page that may contain sensitive information about the application.
                //The UseExceptionHandler method is called on the IApplicationBuilder interface, which is provided by the app variable. The method takes a string parameter that specifies the path to the error page that should be displayed when an exception occurs. In this case, the error page is located at /Home/Error, which corresponds to the Error action method in the HomeController class.
                //catching unhandled exceptions and redirecting the user to a custom error page, which can help improve the user experience and provide more information about the error that occurred.

                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

                //tell the browser to only communicate with the server over HTTPS for a specified period of time. This is done to improve security by preventing man-in-the-middle attacks and ensuring that sensitive information is transmitted securely.

                //The UseHsts method is called on the IApplicationBuilder interface, which is provided by the app variable. The method adds the Strict-Transport-Security header to all HTTP responses sent by the application, which instructs the browser to only communicate with the server over HTTPS for a specified period of time. The default value for this period is 30 days, but it can be changed by passing a TimeSpan parameter to the UseHsts method.
                app.UseHsts();
            }
            //redirects all HTTP requests to HTTPS, which is a secure version of the HTTP protocol. This is done to improve security by encrypting the communication between the client and server, preventing eavesdropping and tampering of sensitive information.

            app.UseHttpsRedirection();
            //enables the application to serve static files, such as images, CSS files, and JavaScript files, directly from the file system without requiring any additional processing by the application. This is done to improve performance and reduce server load by allowing the client to cache static files locally.
            //The UseStaticFiles method is called on the IApplicationBuilder interface, which is provided by the app variable. The method enables the application to serve static files from the wwwroot folder by default, but this can be changed by passing a StaticFileOptions parameter to the UseStaticFiles method.
            app.UseStaticFiles();
            //enables the application to serve static files, such as images, CSS files, and JavaScript files, directly from the file system without requiring any additional processing by the application. This is done to improve performance and reduce server load by allowing the client to cache static files locally.
            //The UseStaticFiles method is called on the IApplicationBuilder interface, which is provided by the app variable. The method enables the application to serve static files from the wwwroot folder by default, but this can be changed by passing a StaticFileOptions parameter to the UseStaticFiles method.
            app.UseRouting();

            //enables the application to use session state, which allows the application to store and retrieve user-specific data across multiple requests. This is done to improve the user experience by allowing the application to remember user preferences and other information between requests.
            app.UseSession();
            //enables the application to use authentication and authorization middleware, which allows the application to authenticate users and authorize access to resources based on their roles and permissions. This is done to improve security by ensuring that only authorized users can access sensitive information and perform certain actions.


            //inline middleware that checks if the request path starts with "/static". If it does, the middleware serves the static file located at "wwwroot{context.Request.Path}". If it doesn't, the middleware calls the next middleware in the pipeline using the next() method. This allows for serving static files from a specific path while still allowing other requests to be handled by other middleware in the pipeline.
            app.Use(async (context, next) =>
            {
                // Check if the request is for a static file
                if (context.Request.Path.StartsWithSegments("/static"))
                {
                    // Serve the static file
                    await context.Response.SendFileAsync($"wwwroot{context.Request.Path}");
                }
                else
                {
                    // Call the next middleware in the pipeline
                    await next();
                }
            });
            app.UseAuthorization();
            app.UseMiddleware<requesttimingmiddelware>();


            
            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
