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
    public class RequestLeaveController : ControllerBase
    {
        private readonly IRequestLeave _requestLeave;
        public RequestLeaveController(IRequestLeave requestLeave)
        {
            _requestLeave = requestLeave;
        }
        [HttpGet("GetAllRequestLeave")]
        public async Task<IActionResult> GetAllRequestLeave()
        {
            try
            {
                var requestLeaves = await _requestLeave.GetAllRequestLeave();
                if (requestLeaves != null)
                {
                    return Ok(requestLeaves);
                }
                else
                {
                    return BadRequest("No Leave Request are available");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetRequestLeaveById/{Id}")]
        public async Task<IActionResult> GetLeaveRequestById(int Id)
        {
            try
            {
                if (Id >0)
                {
                    var requestLeave = await _requestLeave.GetById(Id);
                    if (requestLeave != null)
                    {
                        return Ok(requestLeave);
                    }
                    else
                    {
                        return BadRequest("No Leave Request available at these Id");
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
        [HttpPost("AddRequestLeave")]
        public async Task<IActionResult> AddRequestLeave(RequestLeaveDto requestLeaveDto)
        {
            try
            {
                if (requestLeaveDto != null)
                {
                    var requestLeave = await _requestLeave.AddRequestLeave(requestLeaveDto);
                    if (requestLeave != null)
                    {
                        return Ok(requestLeave);
                    }
                    else
                    {
                        return BadRequest("Unable to add Leave Request ");
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
        [HttpPut("UpdateRequestleave/{Id}")]
        public async Task<IActionResult> UpdateRequestleave(int Id, UpdateRequestLeaveDto updateRequestLeaveDto)
        {
            try
            {
                if (updateRequestLeaveDto != null)
                {
                    var requestLeave = await _requestLeave.UpdateRequestleave(Id, updateRequestLeaveDto);
                    if (requestLeave != null)
                    {
                        return Ok(requestLeave);
                    }
                    else
                    {
                        return BadRequest("Unable to Update Leave Request");
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
        [HttpDelete("DeleteRequestLeave/{Id}")]
        public async Task<IActionResult> DeleteRequestLeave(int Id)
        {
            try
            {
                if (Id >0)
                {
                    var requestLeave = await _requestLeave.DeleteRequestLeave(Id);
                    if (requestLeave != null)
                    {
                        return Ok(requestLeave);
                    }
                    else
                    {
                        return BadRequest("Unable to Delete Leave Request");
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