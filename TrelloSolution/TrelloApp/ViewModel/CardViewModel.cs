using System.Collections.Generic;
using TrelloApp.Models;

namespace TrelloApp.ViewModel
{
    public class CardViewModel
    {
        public Card Card { get; set; }
        public IEnumerable<Comment> Comments { get; set; }        
    }
}