using System.Collections.Generic;

namespace TrelloApp.Models
{
    public class Member
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public IEnumerable<string> IdBoards { get; set; }
    }
}