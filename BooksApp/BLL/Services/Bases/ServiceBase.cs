using BLL.DAL;
using BLL.DAL.Entities;

namespace BLL.Services.Bases
{
    public abstract class ServiceBase
    {
        public bool IsSuccessful { get; set; }

        public string Message { get; set; } = string.Empty;

        protected readonly BooksDbContext _db;

        protected ServiceBase(BooksDbContext db)
        {
            _db = db;
        }

        public ServiceBase Success(string message = "")
        {
            IsSuccessful = true;
            Message = message;
            return this;
        }
        
        public ServiceBase Error(string message = "")
        {
            IsSuccessful = false;
            Message = message;
            return this;
        }
    }
}
