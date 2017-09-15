using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrelloApp.Controllers;
using TrelloApp.Core;
using TrelloApp.Models;

namespace TrelloApp.Tests.Controllers
{
    [TestClass]
    public class BoardsControllerTest
    {
        private BoardsController _controller;
        private Mock<ITrelloRepository> _mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            // Initialize mock TrelloRepository.
            _mockRepository = new Mock<ITrelloRepository>();

            // Initialize mock UnitOfWork.
            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Trello).Returns(_mockRepository.Object);

            // Initialize mock controller.
            _controller = new BoardsController(mockUoW.Object);
        }

        [TestMethod]
        public void GetBoards()
        {
            // Use Trello test token
            var token = "f2a8a8dbeba8bc838216028c0ec53cfb43bf15b3ba2fc245fe36e42a73474bdd";
            _controller.Token = token;

            var result = _controller.Index() as Task<ViewResult>;

            // Get the actual result from the task
            var viewresult = result.Result;

            // Get the model from the viewresult and cast it to the correct type             
            var model = (IEnumerable<Board>)(viewresult.Model);

            Assert.IsNotNull(model);       
        }
    }
}
