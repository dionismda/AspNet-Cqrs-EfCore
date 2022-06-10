using Domain.Entities;
using Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<Todo> _items;

        public TodoQueryTests()
        {
            _items = new List<Todo>();
            _items.Add(new Todo("Tarefa 1", "Usertest1", DateTime.Now));
            _items.Add(new Todo("Tarefa 2", "Usertest2", DateTime.Now));
            _items.Add(new Todo("Tarefa 3", "Usertest3", DateTime.Now));
            _items.Add(new Todo("Tarefa 4", "Usertest4", DateTime.Now));
            _items.Add(new Todo("Tarefa 5", "Usertest1", DateTime.Now));
        }

        [TestMethod]
        public void Consulta_retorna_tarefas_apenas_do_usuario_solicitado()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("Usertest1"));
            Assert.AreEqual(2, result.Count());
        }
    }
}
