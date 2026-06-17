using DevOpsDashboard.Domain.Common;

namespace DevOpsDashboard.Domain.Entities;

public class HealthCheck : BaseEntity
{
    public string ServiceName { get; private set; } = string.Empty;

    public bool IsHealthy { get; private set; }

    public long ResponseTimeMs { get; private set; }

    public DateTime CheckedAt { get; private set; }

    private HealthCheck()
    {
    }

    public HealthCheck(
        string serviceName,
        bool isHealthy,
        long responseTimeMs)
    {
        ServiceName = serviceName;
        IsHealthy = isHealthy;
        ResponseTimeMs = responseTimeMs;
        CheckedAt = DateTime.UtcNow;
    }
}