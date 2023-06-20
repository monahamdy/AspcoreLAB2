using AspcoreLAB2.Models;
using System.Security.Principal;

namespace AspcoreLAB2.Repository
{
    public class AccountRepository: IAccountRepository
    {
        ITIContext Context;
        public AccountRepository(ITIContext Context)
        {
            this.Context = Context;
        }
        public Account Get(string username, string password)
        {
            return Context.Account.FirstOrDefault(a => a.UserName == username && a.Password == password);
        }
        public string GetRoles(int id)
        {
            if (id % 2 == 0)
            {
                return "Admin";
            }
            return "Student";
        }
        public void Create(Account account)
        {
            Context.Account.Add(account);
        }

        public bool Find(string username, string password)
        {
            Account acc = Context.Account
                .FirstOrDefault(e => e.UserName == username && e.Password == password);
            if (acc != null)
                return true;
            else
                return false;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
