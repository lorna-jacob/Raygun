using System.Collections.Generic;
using System.Threading.Tasks;
using TrelloApp.Models;

namespace TrelloApp.Core
{
    public interface ITrelloRepository
    {
        Task<Member> GetMemberAsync(string token);
        Task<IEnumerable<Board>> GetBoardsAsync(string token);
        Task<IEnumerable<Card>> GetCardsFromBoardAsync(string token, string boardId);
        Task<Card> GetCardAsync(string token, string cardId);
        Task<IEnumerable<Comment>> GetCardCommentsAsync(string token, string cardId);
        Task PostCommentAsync(string token, string cardId, string comment);
    }
}