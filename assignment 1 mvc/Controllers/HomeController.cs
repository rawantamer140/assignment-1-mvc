using assignment_1_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace assignment_1_mvc.Controllers
{

    //mvc controller class that handles requests and returns responses for the home page of the application
    //it contains methods for rendering the index and privacy views, as well as an error view in case of exceptions
    //it also uses dependency injection to get an instance of the ILogger interface for logging purposes
    //the controller inherits from the base Controller class provided by ASP.NET Core MVC framework
    //the controller is decorated with the [ResponseCache] attribute to disable caching for the error view
    //the controller is part of the assignment_1_mvc namespace and is located in the Controllers folder
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //action method that handles GET requests to the root URL of the application
        //it returns the Index view to the client, which is typically the home page of the application
        //the method does not take any parameters and does not perform any logic or data manipulation
        //the method is decorated with the [HttpGet] attribute to indicate that it only responds to GET requests
        //the method is asynchronous and returns a Task<IActionResult> to allow for non-blocking execution
      
        public IActionResult Index()
        {
            return View();
        }

        //action method that handles GET requests to the /Home/Privacy URL of the application
        //it returns the Privacy view to the client, which typically contains information about the application's privacy policy
        //the method does not take any parameters and does not perform any logic or data manipulation
        //the method is decorated with the [HttpGet] attribute to indicate that it only responds to GET requests
        public IActionResult Privacy()
        {
            return View();
        }

        //action method that handles GET requests to the /Home/Error URL of the application
        //it returns the Error view to the client, which typically displays an error message and a request ID for debugging purposes
        //the method does not take any parameters and does not perform any logic or data manipulation
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //the method creates a new instance of the ErrorViewModel class and sets its RequestId property to the current activity ID or the HTTP context trace identifier
            //it then passes the model to the view for rendering
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
