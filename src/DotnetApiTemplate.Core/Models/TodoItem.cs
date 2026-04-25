namespace DotnetApiTemplate.Core.Models;

public sealed record Todo(int Id, string Title, bool IsComplete = false);