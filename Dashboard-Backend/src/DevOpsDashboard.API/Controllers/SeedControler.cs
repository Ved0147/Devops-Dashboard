using DevOpsDashboard.Domain.Entities;
using DevOpsDashboard.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsDashboard.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeedController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SeedController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Seed()
    {
        if (_context.Deployments.Any())
        {
            return BadRequest("Database already seeded.");
        }

        var deployment1 = new Deployment(
            "Portfolio API",
            "Production",
            "abc123",
            "main",
            "GitHub Actions");

        deployment1.MarkAsSuccessful();

        var deployment2 = new Deployment(
            "DevOps Dashboard API",
            "Production",
            "def456",
            "main",
            "GitHub Actions");

        deployment2.MarkAsSuccessful();

        var deployment3 = new Deployment(
            "AI Resume Assistant",
            "Production",
            "ghi789",
            "main",
            "GitHub Actions");

        deployment3.MarkAsFailed();

        await _context.Deployments.AddRangeAsync(
            deployment1,
            deployment2,
            deployment3);

        await _context.SaveChangesAsync();

        return Ok("Seed data inserted successfully.");
    }
}