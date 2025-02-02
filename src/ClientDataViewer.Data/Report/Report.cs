﻿namespace ClientDataViewer.Data.Report;

public record Report(
    string Subject,
    string Text,
    bool HasPriority,
    string CarePlanGoalId,
    string ClientId,
    string CreatedBy,
    DateTime CreatedAt);