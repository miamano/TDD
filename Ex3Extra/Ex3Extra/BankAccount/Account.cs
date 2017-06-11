namespace BankAccount
{
    public class Account
    {
        public string Number;
        public string Name;
        public decimal Balance;

        public Account(string number, string name, decimal balance)
        {
            this.Number = number;
            this.Name = name;
            this.Balance = balance;
        }
    }
}