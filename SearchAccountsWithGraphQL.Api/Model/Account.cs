using System;
namespace SearchAccountsWithGraphQL.Api.Model
{
    public class Account
    {
        public Account(long id, AccountsType type, string number, DateTime openingDate , string personId)
        {
            Id = id;
            Type = type;
            Number = number;
            OpeningDate = openingDate;
            Closed = false;
            PersonId = personId;
            Blocked = false;
        }


        public long Id { get; private set; }

        public AccountsType Type { get; private set; }

        public string Number { get; private set; }

        public DateTime OpeningDate { get; private set; }

        public bool Closed { get; private set; }

        public DateTime? ClosingDate { get; private set; }

        public string PersonId { get; private set; }

        public bool Blocked { get; private set; }

        public void Close(DateTime date)
        {
            this.ClosingDate = date;
            this.Closed = true;
        }

        public void Block()
        {
            if (Closed)
            {
                throw new InvalidOperationException();
            }
            Blocked = true;
        }
    }
}
