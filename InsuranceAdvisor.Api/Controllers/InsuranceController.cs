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

        [HttpPost(Name = "AdviseInsurancePlan")]
        public IActionResult AdviseInsurancePlan(AdviseInsurancePlanRequest request)
        {
            return Ok(_insuranceAdvisorService.AdviseInsurancePlan(request));
        }
    }
}
