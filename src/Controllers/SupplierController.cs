using Usecases.Boundaries.Inputs;
using Usecases.Boundaries.Outputs;
using Usecases.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Entities;

namespace Controllers
{

    [Route("")]
    [ApiController]
    public class SupplierController
    {

        [HttpPost]
        public SupplierIdOutput Post([FromBody]SupplierInput input, 
            [FromServices] IHandleable<SupplierInput, SupplierIdOutput> usecase) 
        {
            return usecase.Handle(input);
        }

        [HttpGet("{id}")]
        public SupplierOutput Get(string id,
            [FromServices] IHandleable<string, SupplierOutput> usecase)
        {
            return usecase.Handle(id);
        }
    }
}
