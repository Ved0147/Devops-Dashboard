using DevOpsDashboard.Application.DTOs;
using DevOpsDashboard.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevOpsDashboard.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("overview")]
    public async Task<ActionResult<DashboardOverviewDto>> GetOverview()
    {
        var totalDeployments =
            await _context.Deployments.CountAsync();

        var successfulDeployments =
            await _context.Deployments.CountAsync(
                x => x.Status == Domain.Enums.DeploymentStatus.Success);

        var visitorsToday =
            await _context.Visitors.CountAsync(
                x => x.VisitedAt.Date == DateTime.UtcNow.Date);

        var healthyServices =
            await _context.HealthChecks.CountAsync(
                x => x.IsHealthy);

        var response = new DashboardOverviewDto
        {
            TotalDeployments = totalDeployments,
            SuccessfulDeployments = successfulDeployments,
            VisitorsToday = visitorsToday,
            HealthyServices = healthyServices
        };

        return Ok(response);
    }
}