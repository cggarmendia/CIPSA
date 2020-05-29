using CIPSA.Util.ConsoleApp.Enum.M_V;

namespace CIPSA.Util.ConsoleApp.Class.M_V
{
    public class BankAccount
    {
        #region Properties
        public long Number { get; set; }
        public decimal Balance { get; set; }
        public AccountType AccountType { get; set; }
        private static long nextBankAccountNumber = 123;
        #endregion

        #region Ctors
        public BankAccount()
        {
            Number = long.MinValue;
            Balance = decimal.MinValue;
            AccountType = AccountType.Corriente;
        }
        #endregion

        #region Methods
        public void Populate(decimal balance)
        {
            Number = NextBankAccountNumber();
            Balance = balance;
            AccountType = AccountType.Corriente;
        }

        public bool Withdraw(decimal amount)
        {
            var fondoSuficiente = Balance >= amount;
            if (fondoSuficiente)
            {
                Balance -= amount;
            }
            return fondoSuficiente;
        }

        public decimal Deposit(decimal amount)
        {
            Balance += amount;
            return Balance;
        }

        public void TransferOf(BankAccount cuentaFrom, decimal amount)
        {
            if (cuentaFrom.Withdraw(amount))
            {
                Deposit(amount);
            }
        }

        private static long NextBankAccountNumber()
        {
            return nextBankAccountNumber++;
        }
        #endregion

    }
}
