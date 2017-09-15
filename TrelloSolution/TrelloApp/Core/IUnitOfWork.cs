namespace TrelloApp.Core
{
    public interface IUnitOfWork
    {
        ITrelloRepository Trello { get; }        
    }
}
