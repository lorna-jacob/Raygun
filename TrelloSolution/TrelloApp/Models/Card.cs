using System;
using System.Collections.Generic;

namespace TrelloApp.Models
{
    public class Card
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateLastActivity { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public string IdBoard { get; set; }
    }
}