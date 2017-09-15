using System.Web.Mvc;
using TrelloApp.Core;

namespace TrelloApp.Controllers
{
    public class BaseController : Controller
    {
        IUnitOfWork _unitOfWork;
        string _token = string.Empty;        

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        public string Token
        {
            get
            {
                return string.IsNullOrEmpty(_token) ?
                    Session["TrelloToken"] as string : _token;
            }
            set
            {
                _token = value;
            }
        }
    }
}