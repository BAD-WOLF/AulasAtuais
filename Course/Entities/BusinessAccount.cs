namespace Course.Entities {
    internal class BusinessAccount : Account {

        private Double _loanLimit;
        internal Double LoanLimit { get => this._loanLimit; set => this._loanLimit = value; }

        internal BusinessAccount() {
        }

        internal BusinessAccount(Int32 number, String holder, Double balance, Double loanLimit) : base(number, holder, balance) {
            this.LoanLimit = loanLimit;
        }

        internal void Loan(Double amount) {
            if( amount <= this.LoanLimit ) {
                this.Balance += amount;
            }
        }
    }
}
