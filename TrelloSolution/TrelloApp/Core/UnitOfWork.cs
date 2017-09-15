namespace TrelloApp.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        TrelloRepository _trelloRepository;

        public UnitOfWork()
        {
            _trelloRepository = new TrelloRepository();            
        }

        public ITrelloRepository Trello
        {
            get
            {

                if (_trelloRepository == null)
                {
                    _trelloRepository = new TrelloRepository();
                }
                return _trelloRepository;
            }
        }
    }
}