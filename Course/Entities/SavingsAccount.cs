namespace Course.Entities
{
    internal class SavingsAccount : Account
    {
        private Double _interestRate;
        public Double InterestRate { get => this._interestRate; set => this._interestRate = value; }


        internal SavingsAccount()
        {
        }

        internal SavingsAccount(Int32 number, String holder, Double balance, Double interestRate) : base(number, holder, balance)
        {
            this.InterestRate = interestRate;
        }

        internal void UpdateBalance()
        {
            this.Balance += this.Balance * this.InterestRate;
        }

        internal override void Withdraw(Double amount)
        {
            base.Withdraw(amount);
            this.Balance -= 2.0;
        }
    }
}
