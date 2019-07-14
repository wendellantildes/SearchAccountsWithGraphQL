using System;
using SearchAccountsWithGraphQL.Api.Infra;
using SearchAccountsWithGraphQL.Api.Model;

namespace SearchAccountsWithGraphQL.Api.Business
{
    public class AccountService
    {
        private ApplicationDbContext _context;

        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }


        public void Insert(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
    }
}
