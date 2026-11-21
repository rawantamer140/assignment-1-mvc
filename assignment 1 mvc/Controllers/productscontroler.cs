using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace assignment_1_mvc.Controllers
{
    public class productscontroler : Controller
    {
        [HttpGet]//by default the method is GET, but we can specify it explicitly using the [HttpGet] attribute. This attribute indicates that the method should only respond to HTTP GET requests, which are typically used to retrieve data from a server. In this case, the test() method will only be executed when a GET request is made to the /products/test URL.

        //baseurl: https://localhost:7241/products/test
        // baseurl/products/test
        public string test()
        {
            return "hello from products controller";
        }

        //response [status code 200] and content type [text/plain]

        [HttpGet]

        public ContentResult test()
        {

            //---2
            //creating a new instance of the ContentResult class, which is a type of ActionResult that represents a response containing plain text content. The ContentResult class is part of the Microsoft.AspNetCore.Mvc.Infrastructure namespace, which provides infrastructure services for ASP.NET Core MVC applications.
            //setting the content type of the response to "text/html", which indicates that the response will contain HTML content. This is done by setting the ContentType property of the ContentResult object to "text/html".
            //setting the content of the response to a string that contains HTML markup. In this case, the content is "hello from products controller  </br> rawan tamer ", which will be displayed in the browser as plain text with a line break between the two phrases. This is done by setting the Content property of the ContentResult object to the desired string.
            ContentResult result = new ContentResult();
            result.contenttype = "text/html";
            result.content = "hello from products controller  </br> rawan tamer ";
            result.statuscode = 200;
            return result;



            // --2 
            //creating a new instance of the ContentResult class, which is a type of ActionResult that represents a response containing plain text content. The ContentResult class is part of the Microsoft.AspNetCore.Mvc.Infrastructure namespace, which provides infrastructure services for ASP.NET Core MVC applications.
            //setting the content type of the response to "text/html", which indicates that the response will contain HTML content. This is done by setting the ContentType property of the ContentResult object to "text/html".
            //setting the content of the response to a string that contains HTML markup. In this case, the content is "hello from products controller  </br> rawan tamer ", which will be displayed in the browser as plain text with a line break between the two phrases. This is done by setting the Content property of the ContentResult object to the desired string.
            return Content("hello from products controller  </br> rawan tamer ", "text/html", System.Text.Encoding.UTF8);



            //---3
            
            if(true)
            {
                return Content("hello from products controller  </br> rawan tamer ", "text/html", System.Text.Encoding.UTF8);
            }
            else
            {
                return Content("hello from products controller  </br> rawan tamer ", "text/html", System.Text.Encoding.UTF8);
            })

        }

        [HttpGet]
        public IActionResult index()
        {
            return View();
        }


        //baseurl: https://localhost:7241/products/getproducts

        [HttpGet]
        public IActionResult getproducts()
        {
          var products = new List<product>
            {
                new product { id = 1, name = "product 1", price = 10.99 },
                new product { id = 2, name = "product 2", price = 19.99 },
                new product { id = 3, name = "product 3", price = 5.99 }
            };
            return Json(products);
        }

        [NonAction]//indicates that the method is not an action method and should not be treated as such by the MVC framework. This means that the method cannot be invoked directly by a client through a URL, and it will not be included in the list of available actions for the controller.

        public string getproductname()
        {
            return "product name";
        }



        //baseurl: https://localhost:7241/products/getproductbyid/1
        public IActionResult getproductbyid(int id)
        {
            if(id<0)
            {
                return BadRequest("Invalid product ID");
            }
            else if(id==0)
            {
                return RedirectToAction(nameof(getproducts));
            }
            else if (id > 3)
            {
                return NotFound("Product not found");
            }
            else
            {
                var product = new product { id = id, name = "product " + id, price = 10.99 };
                return Json(product);
            }
            
        }

        //baseurl: products/redirectaction

        [HttpGet]
        public IActionResult redirectaction()
        {
            return RedirectToAction("https://github.com/dashboard");
        }


        [HttpGet]
        public IActionResult fileaction()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "image.jpg");
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "image/jpeg", "image.jpg");
        }


        //routing 

        //baseurl /controllers/action/segment

        [HttpGet("testroute/{name}/{id}")]
        public IActionResult routeaction(string name, int id)
        {
            return Content($"name: {name}, id: {id}");
        }




        // model binding
        //----1
        public IActionResult getbyid( int id,  int enotherid)
        {
            return Json(new { id=id  , enotherid = enotherid})
        }
     

       



    }
}
