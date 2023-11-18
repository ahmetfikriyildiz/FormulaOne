using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Controllers
{
    public class AchivementsController : BaseController
    {
        public AchivementsController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : base(unitOfWork, mapper,mediator)
        {
        }
        [HttpGet]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> GetDriverAchivement(Guid driverId)
        {
            var driverAchivements = await _unitOfWork.Achivements.GetDriverAchivementAsync(driverId);

            if (driverAchivements == null)

                return NotFound("achivements nor found");

            var result = _mapper.Map<DriverAchivementResponses>(driverAchivements);

            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddAchivement([FromBody] CreateDriverAchivementRequest achivement)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = _mapper.Map<Achivement>(achivement);

            await _unitOfWork.Achivements.Add(result);
           
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriverAchivement), new { driverId = result.DriverId }, result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAchivements([FromBody] UpdateDriverAchivementRequest achivement)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = _mapper.Map<Achivement>(achivement);
            await _unitOfWork.Achivements.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    
    
     }
    
}