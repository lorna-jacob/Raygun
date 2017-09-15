using System.Threading.Tasks;
using System.Web.Mvc;
using TrelloApp.Core;
using TrelloApp.Filters;

namespace TrelloApp.Controllers
{
    [Authenticate]
    [HandleError(View = "PageNotFound")]
    public class BoardsController : BaseController
    {
        public BoardsController(IUnitOfWork unitOfWork) : base(unitOfWork) { }        

        // GET: Boards
        public async Task<ViewResult> Index()
        {            
            var boards = await UnitOfWork?
                .Trello
                .GetBoardsAsync(Token);

            return View(boards);            
        }
    }
}