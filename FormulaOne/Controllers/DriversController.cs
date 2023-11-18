using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using FormulaOne.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Controllers
{
 
    public class DriversController : BaseController
    {
        private readonly IMediator _mediator;

        public DriversController(IUnitOfWork unitOfWork,IMapper mapper,IMediator mediator):base (unitOfWork, mapper) 
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            var query= new GetAllDriversQuery();

            var result= await _mediator.Send(query);

            return Ok(result);
        }
        [HttpGet]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            var query = new GetDriverQuery(driverId);

            var result = await _mediator.Send(query);
            if(result==null)
                return NotFound();


            return Ok(result);
        }
      
        [HttpPost("")]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
        {
            if (!ModelState.IsValid) 
                return BadRequest();
                    
            var result = _mapper.Map<Driver>(driver);
            await _unitOfWork.Drivers.Add(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriver), new { driverId = result.Id }, result);

        }
        [HttpPut("")]
        public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Driver>(driver);
            await _unitOfWork.Drivers.Add(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();

        }
        [HttpDelete]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> DeleteDriver(Guid driverId)
        {
            var driver = _unitOfWork.Drivers.Delete(driverId);

            if (driver == null)

                return NotFound();

            await _unitOfWork.Drivers.Delete(driverId);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

    }
}
