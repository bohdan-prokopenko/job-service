using JobService.Api.Request;
using JobService.Api.Response;

using Microsoft.AspNetCore.Mvc;

namespace JobService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase {
    
    [HttpPost]
    public JobResponse CalculateTotal([FromBody] JobRequest jobRequest) {

    }
}
