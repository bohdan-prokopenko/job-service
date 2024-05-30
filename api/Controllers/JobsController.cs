using JobService.Api.Dto.Request;
using JobService.Api.Dto.Response;
using JobService.Domain.Entity;
using JobService.Domain.UseCase;

using Microsoft.AspNetCore.Mvc;

namespace JobService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController(ICalculateTotalUseCase calculateTotalUseCase) : ControllerBase {
    
    [HttpPost]
    public JobResponse CalculateTotal([FromBody] JobRequestDto jobRequest) {
        JobResult result = calculateTotalUseCase.Execute(jobRequest.ToRawJob());
        return new JobResponse(result);
    }
}
