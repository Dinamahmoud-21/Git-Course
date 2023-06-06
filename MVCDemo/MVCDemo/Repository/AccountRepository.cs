using MVCDemo.Models;

namespace MVCDemo.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ITIEntity context;

        public AccountRepository(ITIEntity Context)
        {
            context = Context;
        }
        public Account Find(string username, string password)
        {
            Account account=context.Account
                .FirstOrDefault(a=>a.UserName== username && a.Password == password);
            return account;
        }

        public bool Found(string username, string password)
        {
            Account account = context.Account
               .FirstOrDefault(a => a.UserName == username && a.Password == password);
            return account != null ? true : false;
        }
    }
}
