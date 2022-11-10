using EmployeeManagementSystemCA.Core.IRepository;
using EmployeeManagementSystemCA.DTO;
using EmployeeManagementSystemCA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace EmployeeManagementSystemCA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingHourController : ControllerBase
    {
        private readonly IWorkingHour _workingHour;
        public WorkingHourController(IWorkingHour workingHour)
        {
            _workingHour = workingHour;
        }
        [HttpGet("GetAllWorkingDetails")]
        public async Task<IActionResult> GetAllDetails()
        {
            try
            {
                var workingHours = await _workingHour.GetAllDetails();
                if (workingHours != null)
                {
                    return Ok(workingHours);
                }
                else
                {
                    return BadRequest("No Working Data are available");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    var workingHour = await _workingHour.GetById(Id);
                    if (workingHour != null)
                    {
                        return Ok(workingHour);
                    }
                    else
                    {
                        return BadRequest("No Working Data available at these Id");
                    }
                }
                else
                {
                    return BadRequest("Please enter valid Id");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("AddWorkingDetails")]
        public async Task<IActionResult> AddWorkingDetails(WorkingHourDto workingHourDto)
        {
            try
            {
                if (workingHourDto != null)
                {
                    var workingHour = await _workingHour.AddWorkingDetails(workingHourDto);
                    if (workingHour != null)
                    {
                        return Ok(workingHour);
                    }
                    else
                    {
                        return BadRequest("Unable to add Working Hours data ");
                    }
                }
                else
                {
                    return BadRequest("Please enter a valid data");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("UpdateWorkingDetails/{Id}")]
        public async Task<IActionResult> UpdateWorkingDetails(int Id, UpdateWorkingHourDto updateWorkingHourDto)
        {
            try
            {
                if (updateWorkingHourDto != null)
                {
                    var workingHour = await _workingHour.UpdateWorkingDetails(Id, updateWorkingHourDto);
                    if (workingHour != null)
                    {
                        return Ok(workingHour);
                    }
                    else
                    {
                        return BadRequest("Unable to Update Working Hours data");
                    }
                }
                else
                {
                    return BadRequest("Please enter a valid data");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("DeleteWorkingDetails/{Id}")]
        public async Task<IActionResult> DeleteWorkingDetails(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    var workingHour = await _workingHour.DeleteWorkingDetails(Id);
                    if (workingHour != null)
                    {
                        return Ok(workingHour);
                    }
                    else
                    {
                        return BadRequest("Unable to Delete Working Hour Data");
                    }
                }
                else
                {
                    return BadRequest("Please Enter valid Id");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
