using System.Threading.Tasks;
using System.Web.Mvc;
using TrelloApp.Core;
using TrelloApp.Filters;
using TrelloApp.ViewModel;

namespace TrelloApp.Controllers
{
    [Authenticate]
    [HandleError(View = "PageNotFound")]
    public class CardsController : BaseController
    {
        public CardsController(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        
        [Route("boardId")]
        public async Task<ViewResult> Index(string boardId)
        {            
            var cards = await UnitOfWork?
                .Trello
                .GetCardsFromBoardAsync(Token, boardId);

            return View(cards);
        }
        
        [Route("cardId")]
        public async Task<ViewResult> Card(string cardId)
        {            
            var card = await UnitOfWork?
                .Trello
                .GetCardAsync(Token, cardId);

            var comments = await UnitOfWork?
                .Trello
                .GetCardCommentsAsync(Token, cardId);

            return View("Card", new CardViewModel { Card = card, Comments = comments });
        }

        [HttpPost]
        public async Task<ActionResult> Comment(string cardId, string comment)
        {
            await UnitOfWork?.Trello.PostCommentAsync(Token, cardId, comment);
            return RedirectPermanent($"/Cards/Card?cardId={cardId}");
        }
    }
}