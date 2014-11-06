using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Mvc;

namespace HelloMvc
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {

          app.UseServices(services =>
                {
                    services.AddMvc();
          });

          app.UseMvc();
        }
    }


    public class FooController : Controller {
      [Route("HelloWorld")]
      public string Get() {

            return "Hello world!@";
      }


      [Route("SimpleActionResult")]
      public JsonResult GetSimpleAction() {
            var person = new Person() {
              FirstName="Dave", LastName="Brown"
              };

        return new JsonResult(person);
      }

      [Route("NoContent")]
      public NoContentResult GetNoContent() {

            return new NoContentResult();
      }
    }

    public class Person {
      public string FirstName {get;set;}
      public string LastName {get;set;}
    }
}
