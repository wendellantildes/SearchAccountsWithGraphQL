using System;
using GraphQL.Types;

namespace SearchAccountsWithGraphQL.Api.Model.GraphQL
{
    public class AccountType :ObjectGraphType<Account>
    {
        public AccountType()
        {
            Name = "Account";

            Field<AccountTypeEnum>("Type", "Type of account: Checking or Savings");

            Field(x => x.Number).Description("Account number");

            Field(x => x.OpeningDate).Description("Date which the account was created");

            Field(x => x.Closed).Description("It indicates if the account is closed");

            Field(x => x.ClosingDate, nullable: true).Description("Date which the account was closed");

            Field(x => x.Blocked).Description("It indicates if the account is blocked");

            Field(x => x.PersonId).Description("Owner's identification document");
        }
    }
}
