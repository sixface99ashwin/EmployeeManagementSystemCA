using EmployeeManagementSystemCA.Core.IRepository;
using EmployeeManagementSystemCA.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace EmployeeManagementSystemCA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignation _designation;
        public DesignationController(IDesignation designation)
        {
            _designation = designation;
        }
        [HttpGet("GetAllDesignationData")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var designations = await _designation.GetAllDesignationData();
                if (designations != null)
                {
                    return Ok(designations);
                }
                else
                {
                    return BadRequest("No Designation details available");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("GetDesignationByName/{Name}")]
        public async Task<IActionResult> GetDesignationByName(string Name)
        {
            try
            {
                if (Name != null)
                {
                    var designation = await _designation.GetDesignationByName(Name);
                    if (designation != null)
                    {
                        return Ok(designation);
                    }
                    else
                    {
                        return BadRequest("No Designation available at these Name");
                    }
                }
                else
                {
                    return BadRequest("Please enter valid Name");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("AddDesignationDetails")]
        public async Task<IActionResult> AddDesignationDetails(DesignationDto designationdto)
        {
            try
            {
                if (designationdto != null)
                {
                    var designation = await _designation.AddDesignationDetails(designationdto);
                    if (designation != null)
                    {
                        return Ok(designation);
                    }
                    else
                    {
                        return BadRequest("Unable to add Designation details");
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
        [HttpPut("UpdateDesignationDetails/{Name}")]
        public async Task<IActionResult> UpdateDesignationDetails(string Name, UpdateDesignationDto updatedesignationDto)
        {
            try
            {
                if (updatedesignationDto != null)
                {
                    var designation = await _designation.UpdateDesignationDetails(Name, updatedesignationDto);
                    if (designation != null)
                    {
                        return Ok(designation);
                    }
                    else
                    {
                        return BadRequest("Unable to Update Designation Details");
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
        [HttpDelete("DeleteDesignation/{Name}")]
        public async Task<IActionResult> DeleteDesignationDetails(string Name)
        {
            try
            {
                if (Name != null)
                {
                    var designation = await _designation.DeleteDesignationDetails(Name);
                    if (designation != null)
                    {
                        return Ok(designation);
                    }
                    else
                    {
                        return BadRequest("Unable to Delete Designation Details");
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
