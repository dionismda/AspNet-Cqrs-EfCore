using Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", DateTime.Now, "");
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo Tarefa", DateTime.Now, "UserTeste");

        public CreateTodoCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void Comando_invalido()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Comando_valido()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
