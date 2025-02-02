namespace ClientDataViewer.Shared.Models;

public record ReportDto(
    string Subject,
    string Text,
    bool HasPriority,
    string CarePlanGoalId,
    string ClientId,
    string CreatedBy,
    DateTime CreatedAt);