using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.EntityTest
{
  [TestClass]
  public class TodoQueryTests
  {
    private List<TodoItem> _items;

    public TodoQueryTests()
    {
      _items = new List<TodoItem>();
      _items.Add(new TodoItem("tarefa 1", "usuarioA", DateTime.Now));
      _items.Add(new TodoItem("tarefa 2", "DouglasCosta", DateTime.Now));
      _items.Add(new TodoItem("tarefa 3", "usuarioA", DateTime.Now));
      _items.Add(new TodoItem("tarefa 3", "DouglasCosta", DateTime.Now));
      _items.Add(new TodoItem("tarefa 5", "usuarioA", DateTime.Now));
      _items.Add(new TodoItem("tarefa 6", "DouglasCosta", DateTime.Now));
    }

    [TestMethod]
    public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_DouglasCosta()
    {
      var result = _items.AsQueryable().Where(TodoQueries.GetAll("DouglasCosta"));
      Assert.AreEqual(3, result.Count());
    }
  }
}
