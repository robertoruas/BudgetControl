using BudgetControl.Core.Application.DTOs;
using BudgetControl.Core.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgetControl.API.Controllers
{
    [ApiController, Route("api/v1/[controller]")]
    public class ReportController : ControllerBase
    {
        private ISummaryService _service;

        public ReportController(ISummaryService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet, Route("{year}/{month}")]
        public async Task<IActionResult> Summary(int year, int month)
        {
            try
            {
                SummaryDTO summary = await _service.GetSummaryByMonthAndYear(month, year);

                return Ok(summary);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
