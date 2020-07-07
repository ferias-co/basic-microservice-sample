using Usecases.Boundaries.Inputs;
using Usecases.Boundaries.Outputs;
using Usecases.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{

    [Route("")]
    [ApiController]
    public class SupplierController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post([FromBody]SupplierInput input, 
            [FromServices] IHandleable<SupplierInput, SupplierIdOutput> usecase) 
        {
            return new OkObjectResult( usecase.Handle(input) );
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id,
            [FromServices] IHandleable<string, SupplierOutput> usecase)
        {
            return new OkObjectResult(usecase.Handle(id));
        }
    }
}
