using WebApiMongo.Models;

namespace WebApiMongo.Services
{
    public class BookService : GenericService<Book>
    {
        public BookService(IBookstoreDatabaseSettings settings) : base(settings)
        {

        }
    }
}