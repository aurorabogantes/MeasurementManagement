using System.Linq.Expressions;
using MeasurementManagement.BC.Models;
using MeasurementManagement.BW.Interfaces.BW;
using Microsoft.AspNetCore.Mvc;

namespace MeasurementManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasuresController : ControllerBase
    {
        private readonly IMeasurementManagementBW measurementManagementBW;
        public MeasuresController(IMeasurementManagementBW measurementManagementBW)
        {
            this.measurementManagementBW = measurementManagementBW;
        }

        [HttpGet(Name = "GetAllMeasures")]
        public async Task<ActionResult<IEnumerable<Measure>>> Get()
        {
            try
            {
                var measures = await measurementManagementBW.getAllMeasures();
                return Ok(measures);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetMeasure")]
        public async Task<ActionResult<Measure>> Get(int id)
        {
            try
            {
                var measures = await measurementManagementBW.getMeasure(id);
                if(measures ==  null)
                {
                    return NotFound("Measure not found");
                }
                return Ok(measures);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost(Name = "CreateMeasure")]
        public async Task<ActionResult<Measure>> Post([FromBody] Measure measure)
        {
            try
            {
                var result = await measurementManagementBW.addMeasure(measure);
                if(!result)
                {
                    return BadRequest("Failed to create measure");
                }
                return Ok(true);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}", Name = "UpdateMeasure")]
        public async Task<ActionResult<bool>> Put(int id, [FromBody] Measure measure)
        {
            try
            {
                if(id != measure.Id)
                {
                    return BadRequest("Measure ID mismatch");
                }

                var result = await measurementManagementBW.updateMeasure(id, measure);

                if(!result)
                {
                    return NotFound("Measure not found");
                }

                return Ok(true);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}", Name = "DeleteMeasure")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var result = await measurementManagementBW.deleteMeasure(id);
                if(!result)
                {
                    return NotFound("Measure not found");
                }
                return Ok(true);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
