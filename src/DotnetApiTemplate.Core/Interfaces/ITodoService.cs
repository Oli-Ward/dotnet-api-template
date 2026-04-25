using DotnetApiTemplate.Core.Models;

namespace DotnetApiTemplate.Core.Interfaces;

public interface ITodoService
{
    Todo Add(string title);
    IReadOnlyCollection<Todo> List();
    Todo Complete(int id);
}