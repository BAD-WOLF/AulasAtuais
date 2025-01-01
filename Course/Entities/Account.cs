namespace Course.Entities {
    internal class Account {

        private Int32 _number;
        public Int32 Number { get => this._number; set => this._number = value; }

        private String _holder;
        public String Holder { get => this._holder; set => this._holder = value; }

        private Double _balance;
        public Double Balance { get => this._balance; set => this._balance = value; }


        #pragma warning disable CS8618
        // O campo não anulável precisa conter um valor não nulo ao sair do construtor.
        // Considere adicionar o modificador "obrigatório" ou declarar como anulável.
        internal Account() {
        }
        #pragma warning restore CS8618

        #pragma warning disable CS8618
        // O campo não anulável precisa conter um valor não nulo ao sair do construtor.
        // Considere adicionar o modificador "obrigatório" ou declarar como anulável.
        internal Account(Int32 number, String holder, Double balance) {
            this.Number = number;
            this.Holder = holder;
            this.Balance = balance;
        }
        #pragma warning restore CS8618

        internal virtual void Withdraw(Double amount) {
            this.Balance -= amount + 5.0;
        }

        internal void Deposit(Double amount) {
            this.Balance += amount;
        }
    }
}
