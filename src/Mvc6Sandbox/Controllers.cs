using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Mvc;

namespace Mvc6Sandbox
{
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
