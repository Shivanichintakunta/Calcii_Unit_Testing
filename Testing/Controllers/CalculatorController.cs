using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testing.Services;
using Testing.Models;
using Testing.DTOs;

namespace Testing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _service;

        public CalculatorController(ICalculatorService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<ActionResult<CalculatorEntitiy>> Add([FromBody] OperandsRequest request)
        {
            var result = await _service.AddAsync(request.Operand1, request.Operand2);
            return Ok(result);
        }

        [HttpPost("sub")]
        public async Task<ActionResult<CalculatorEntitiy>> Sub([FromBody] OperandsRequest request)
        {
            var result = await _service.SubAsync(request.Operand1, request.Operand2);
            return Ok(result);
        }

        [HttpPost("mul")]
        public async Task<ActionResult<CalculatorEntitiy>> Mul([FromBody] OperandsRequest request)
        {
            var result = await _service.MulAsync(request.Operand1, request.Operand2);
            return Ok(result);
        }

        [HttpPost("div")]
        public async Task<ActionResult<CalculatorEntitiy>> Div([FromBody] OperandsRequest request)
        {
            try
            {
                var result = await _service.DivAsync(request.Operand1, request.Operand2);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalculatorEntitiy>>> GetAll()
        {
            var results = await _service.GetAllAsync();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CalculatorEntitiy>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CalculatorEntitiy calculator)
        {
            if (id != calculator.id)
                return BadRequest("ID in URL does not match ID in body.");

            try
            {
                var success = await _service.UpdateAsync(id, calculator);
                if (!success)
                    return NotFound();

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
