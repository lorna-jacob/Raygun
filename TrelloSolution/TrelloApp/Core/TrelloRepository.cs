using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using TrelloApp.Models;

namespace TrelloApp.Core
{
    public class TrelloRepository : ITrelloRepository
    {
        const string TRELLO_BASE_ENDPOINT = "https://api.trello.com/1/";
        readonly string _applicationKey;        
        static HttpClient client = new HttpClient();

        public TrelloRepository()
        {            
            _applicationKey = WebConfigurationManager.AppSettings["AppKey"];
        }

        /// <summary>
        /// Gets Trello Member associated with the token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Member</returns>
        public async Task<Member> GetMemberAsync(string token)
        {                                  
            var response = await client.GetAsync($"{TRELLO_BASE_ENDPOINT}members/me?key={_applicationKey}&token={token}");
            if (response.StatusCode != HttpStatusCode.OK)
                return null;
            
            var memberData = await response.Content.ReadAsStringAsync();
            var member = JsonConvert.DeserializeObject<Member>(memberData);
            return member;            
        }

        /// <summary>
        /// Gets all boards of the given member.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Board>> GetBoardsAsync(string token)
        {
            var member = await GetMemberAsync(token);
            if (member == null)
                return null;

            var response = await client.GetAsync($"{TRELLO_BASE_ENDPOINT}members/{member.Id}/boards?key={_applicationKey}&token={token}");
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            var boardData = await response.Content.ReadAsStringAsync();
            var boards = JsonConvert.DeserializeObject<IEnumerable<Board>>(boardData);

            return boards;
        }

        /// <summary>
        /// Gets all cards from given board.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="boardId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Card>> GetCardsFromBoardAsync(string token, string boardId)
        {                        
            var response = await client.GetAsync($"{TRELLO_BASE_ENDPOINT}boards/{boardId}/cards?key={_applicationKey}&token={token}");
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            var cardData = await response.Content.ReadAsStringAsync();
            var cards = JsonConvert.DeserializeObject<IEnumerable<Card>>(cardData);

            return cards;
        }

        /// <summary>
        /// Gets card from given id.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public async Task<Card> GetCardAsync(string token, string cardId)
        {
            var response = await client.GetAsync($"{TRELLO_BASE_ENDPOINT}cards/{cardId}?key={_applicationKey}&token={token}");
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            var cardData = await response.Content.ReadAsStringAsync();
            var card = JsonConvert.DeserializeObject<Card>(cardData);

            return card;
        }

        /// <summary>
        /// Gets the comments associated with the given card.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Comment>> GetCardCommentsAsync(string token, string cardId)
        {            
            var response = await client.GetAsync($"{TRELLO_BASE_ENDPOINT}cards/{cardId}/actions?filter=commentCard&key={_applicationKey}&token={token}");
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            var commentData = await response.Content.ReadAsStringAsync();
            var comments = JsonConvert.DeserializeObject<IEnumerable<Comment>>(commentData);

            return comments;
        }

        /// <summary>
        /// Creates new comment and posts it to the given card.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cardId"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public async Task PostCommentAsync(string token, string cardId, string comment)
        {
            var uri = $"{TRELLO_BASE_ENDPOINT}cards/{cardId}/actions/comments?key={_applicationKey}&token={token}&text={comment}";
            await client.PostAsync(uri, null);
        }        
    }
}