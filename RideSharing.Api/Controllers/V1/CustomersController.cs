//using AutoMapper;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using RideSharing.Api.Filters;

//namespace RideSharing.Api.V1
//{
//    [ApiVersion("1.0")]
//    [ApiController]
//    [Route("api/{version:apiVersion}/[controller]")]
//    public class CustomersController : BaseController
//    {
//        private readonly IMediator _mediator;
//        private readonly IMapper _mapper;

//        public CustomersController(IMediator mediator, IMapper mapper)
//        {
//            _mediator = mediator;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAllAsync()
//        {
//            var query = new GetAllCustomersQueryRequest();
//            var result = await _mediator.Send(query);

//            if (result.IsError) return HandleErrorResponse(result.Errors);

//            return Ok(result.Value);
//        }

//        [HttpPost]
//        [ValidateModel]
//        public async Task<IActionResult> PostAsync([FromBody] CustomerRequests.CreateCustomer createCustomer)
//        {
//            var command = _mapper.Map<CreateCustomerCommand>(createCustomer);
//            var result = await _mediator.Send(command);

//            if (result.IsError) return HandleErrorResponse(result.Errors);

//            return CreatedAtAction(actionName: nameof(PostAsync),
//                                   routeValues: new { id = result.Value.Id },
//                                   value: result.Value);
//        }

//        [HttpPatch]
//        [Route("{id}")]
//        public async Task<IActionResult> PostAsync([FromRoute] Guid id, [FromBody] CustomerRequests.UpdateCustomer updatedCustomer)
//        {
//            if (id == Guid.Empty || id != updatedCustomer.Id) return BadRequest();

//            var command = _mapper.Map<UpdateCustomerCommand>(updatedCustomer);
//            command.Id = id;

//            var result = await _mediator.Send(command);

//            if (result.IsError) return HandleErrorResponse(result.Errors);

//            return CreatedAtAction(actionName: nameof(PostAsync),
//                                   routeValues: new { id = result.Value.Id },
//                                   value: result.Value);
//        }

//        [HttpGet]
//        [Route("{id}")]
//        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
//        {
//            if (id == Guid.Empty) return BadRequest();

//            var query = new GetCustomerByIdQuery(id);

//            var result = await _mediator.Send(query);

//            if (result.IsError) return HandleErrorResponse(result.Errors);

//            return Ok(result.Value);
//        }

//        [HttpDelete]
//        [Route("{id}")]
//        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
//        {
//            if (id == Guid.Empty) return BadRequest();

//            var query = new DeleteCustomerCommand(id);

//            var result = await _mediator.Send(query);

//            if (result.IsError) return HandleErrorResponse(result.Errors);

//            return Ok(result.Value);
//        }
//    }
//}
