using DotnetApiTemplate.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotnetApiTemplate.Api.Controllers;

[ApiController]
[Route("api/todos")]
public sealed class TodosController(ITodoService todoService) : ControllerBase
{
    [HttpGet]
    public IActionResult List()
    {
        return Ok(todoService.List());
    }

    [HttpPost]
    public IActionResult Add([FromBody] CreateTodoRequest request)
    {
        var todo = todoService.Add(request.Title);

        return CreatedAtAction(nameof(List), new { id = todo.Id }, todo);
    }

    [HttpPatch("{id:int}/complete")]
    public IActionResult Complete(int id)
    {
        var todo = todoService.Complete(id);

        return Ok(todo);
    }
}

public sealed record CreateTodoRequest(string Title);