using System;
using System.Collections.Generic;
using GraphQL.Types;
using SearchAccountsWithGraphQL.Api.Infra;
using System.Linq;

namespace SearchAccountsWithGraphQL.Api.Model.GraphQL
{
    public class AccountQuery : ObjectGraphType
    {
        public AccountQuery(ApplicationDbContext ac)
        {
            Field<ListGraphType<AccountType>>("accounts",
                arguments : new QueryArguments(new QueryArgument<AccountTypeEnum> { Name = "type"}),
                resolve: context =>
               {
                   var type = context.GetArgument<AccountsType>("type");
                   return ac.Accounts.Where(x => x.Type == type);
               });
        }
    }
}
