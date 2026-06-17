namespace DevOpsDashboard.Application.DTOs;

public class DashboardOverviewDto
{
    public int TotalDeployments { get; set; }

    public int SuccessfulDeployments { get; set; }

    public int VisitorsToday { get; set; }

    public int HealthyServices { get; set; }
}