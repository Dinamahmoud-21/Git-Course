using MVCDemo.Models;

namespace MVCDemo.Repository
{
    public interface IAccountRepository
    {
        //found , find
        bool Found(string username, string password);

        Account Find(string username, string password);
    }
}
