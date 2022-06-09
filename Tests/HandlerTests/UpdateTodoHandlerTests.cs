using Domain.Commands;
using Domain.Handler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Repositories;

namespace Tests.HandlerTests
{
    [TestClass]
    public class UpdateTodoHandlerTests
    {

        private readonly UpdateTodoCommand _invalidCommand = new UpdateTodoCommand(new Guid(), "", "");
        private readonly UpdateTodoCommand _validCommand = new UpdateTodoCommand(new Guid(), "Titulo Tarefa", "UserTeste");
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

        [TestMethod]
        public void Comando_invalido_deve_parar_a_execucao()
        {
            var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void Comando_valido_deve_criar_tarefa()
        {
            var result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(result.Success, true);
        }
    }
}
