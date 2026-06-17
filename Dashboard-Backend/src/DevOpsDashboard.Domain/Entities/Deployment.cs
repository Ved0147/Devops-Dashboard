using DevOpsDashboard.Domain.Common;
using DevOpsDashboard.Domain.Enums;

namespace DevOpsDashboard.Domain.Entities;

public class Deployment : BaseEntity
{
    public string ServiceName { get; private set; } = string.Empty;

    public string Environment { get; private set; } = string.Empty;

    public string CommitHash { get; private set; } = string.Empty;

    public string BranchName { get; private set; } = string.Empty;

    public DeploymentStatus Status { get; private set; }

    public DateTime StartedAt { get; private set; }

    public DateTime? FinishedAt { get; private set; }

    public string TriggeredBy { get; private set; } = string.Empty;

    private Deployment()
    {
    }

    public Deployment(
        string serviceName,
        string environment,
        string commitHash,
        string branchName,
        string triggeredBy)
    {
        ServiceName = serviceName;
        Environment = environment;
        CommitHash = commitHash;
        BranchName = branchName;
        TriggeredBy = triggeredBy;

        StartedAt = DateTime.UtcNow;
        Status = DeploymentStatus.Pending;
    }
    public void MarkAsSuccessful()
    {
        Status = DeploymentStatus.Success;
        FinishedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    public void MarkAsFailed()
    {
        Status = DeploymentStatus.Failed;
        FinishedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}