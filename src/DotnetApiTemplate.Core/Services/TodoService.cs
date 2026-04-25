using DotnetApiTemplate.Core.Interfaces;
using DotnetApiTemplate.Core.Models;

namespace DotnetApiTemplate.Core.Services;

public sealed class TodoService : ITodoService
{
    private readonly List<Todo> _items = [];

    public Todo Add(string title)
    {
        var item = new Todo(_items.Count + 1, title.Trim());
        _items.Add(item);
        return item;
    }

    public IReadOnlyCollection<Todo> List() => _items.AsReadOnly();

    public Todo Complete(int id)
    {
        var item = _items.Single(x => x.Id == id);
        var completed = item with { IsComplete = true };

        _items.Remove(item);
        _items.Add(completed);

        return completed;
    }
}