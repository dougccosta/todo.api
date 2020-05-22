using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers
{
  [ApiController]
  [Route("v1/todos")]
  public class TodoController : ControllerBase
  {

    [Route("")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAll(
      [FromServices]ITodoRepository repository
    )
    {
      return repository.GetAll("DouglasCosta");
    }

    [Route("done")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllDone(
      [FromServices]ITodoRepository repository
    )
    {
      return repository.GetAllDone("DouglasCosta");
    }

    [Route("undone")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndone(
      [FromServices]ITodoRepository repository
    )
    {
      return repository.GetAllUndone("DouglasCosta");
    }

    [Route("done/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForToday(
      [FromServices]ITodoRepository repository
    )
    {
      return repository.GetByPediod("DouglasCosta",
                                    DateTime.Now.Date,
                                    true);
    }

    [Route("undone/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneForToday(
      [FromServices]ITodoRepository repository
    )
    {
      return repository.GetByPediod("DouglasCosta",
                                    DateTime.Now.Date,
                                    false);
    }

    [Route("done/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForTomorrow(
      [FromServices]ITodoRepository repository
    )
    {
      return repository.GetByPediod("DouglasCosta",
                                    DateTime.Now.Date.AddDays(1),
                                    true);
    }

    [Route("undone/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneForTomorrow(
      [FromServices]ITodoRepository repository
    )
    {
      return repository.GetByPediod("DouglasCosta",
                                    DateTime.Now.Date.AddDays(1),
                                    false);
    }

    [Route("")]
    [HttpPost]
    public GenericCommandResult Create(
      [FromBody]CreateTodoCommand command,
      [FromServices]TodoHandler handler
    )
    {
      command.User = "DouglasCosta";
      return (GenericCommandResult)handler.Handle(command);
    }

    [Route("")]
    [HttpPut]
    public GenericCommandResult Update(
      [FromBody]UpdateTodoCommand command,
      [FromServices]TodoHandler handler
    )
    {
      command.User = "DouglasCosta";
      return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-done")]
    [HttpPut]
    public GenericCommandResult MarkAsDone(
      [FromBody]MarkTodoAsDoneCommand command,
      [FromServices]TodoHandler handler
    )
    {
      command.User = "DouglasCosta";
      return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-undone")]
    [HttpPut]
    public GenericCommandResult MarkAsUndone(
      [FromBody]MarkTodoAsUndoneCommand command,
      [FromServices]TodoHandler handler
    )
    {
      command.User = "DouglasCosta";
      return (GenericCommandResult)handler.Handle(command);
    }
  }
}
