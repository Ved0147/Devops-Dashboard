using DevOpsDashboard.Domain.Common;

namespace DevOpsDashboard.Domain.Entities;

public class Visitor : BaseEntity
{
    public string Page { get; private set; } = string.Empty;

    public string IpAddress { get; private set; } = string.Empty;

    public DateTime VisitedAt { get; private set; }

    private Visitor()
    {
    }

    public Visitor(string page, string ipAddress)
    {
        Page = page;
        IpAddress = ipAddress;
        VisitedAt = DateTime.UtcNow;
    }
}