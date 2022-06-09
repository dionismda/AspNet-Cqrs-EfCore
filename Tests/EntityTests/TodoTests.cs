using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.EntityTests
{
    [TestClass]
    public class TodoTests
    {
        private readonly Todo _todo = new Todo("Titulo tarefa", "UserTest", DateTime.Now);

        [TestMethod]
        public void Criado_um_novo_todo_nao_pode_ser_concluido()
        {
            Assert.AreEqual(_todo.Done, false);
        }
    }
}
