using InsuranceAdvisor.Domain.Requests;
using InsuranceAdvisor.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceAdvisor.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsuranceController: ControllerBase
    {
        private readonly IInsuranceAdvisorService _insuranceAdvisorService;

        public InsuranceController(IInsuranceAdvisorService insuranceAdvisorService)
        {
            _insuranceAdvisorService = insuranceAdvisorService;
        }

        //TODO: melhorar esse nome
        [HttpPost(Name = "CalculateInsuranceScore")]
        public IActionResult CalculateInsuranceScore(CalculateInsuranceScoreRequest request)
        {
            _insuranceAdvisorService.Do(request);
            return Ok();
        }
    }
}
