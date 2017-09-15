using System;

namespace TrelloApp.Models
{
    public class Comment
    {
        public string Id { get; set; }        
        public DateTime Date { get; set; }    
        public CommentData Data { get; set; }
        public MemberData MemberCreator { get; set; }
    }

    public class CommentData
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }

    public class MemberData
    {
        public string FullName { get; set; }
    }
}