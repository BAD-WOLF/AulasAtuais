namespace BancoWithTryCatch.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text.Json;

    using BancoWithTryCatch.Entity.Exception;

    internal class Accont {
        private UInt32 _id;
        private Double _balance;
        private Double _withdrowLimit;
        private People _pessoa;

        internal Accont(UInt32 id, Double balance, Double withdrowLimit, People pessoa) {
            this.ID = id;
            this.Balance = balance;
            this.WithdrowLimit = withdrowLimit;
            this.Pessoa = pessoa;
        }


        internal UInt32 ID {
            get {
                return this._id;
            }

            private set {
                this._id = value;
            }
        }

        internal Double Balance {
            get {
                return this._balance;
            }

            set {
                this._balance = value;
            }
        }

        internal Double WithdrowLimit {
            get {
                return this._withdrowLimit;
            }

            set {
                this._withdrowLimit = value;
            }
        }

        internal People Pessoa {
            get {
                return this._pessoa;
            }

            set {
                this._pessoa = value;
            }
        }

        internal void Deposit(Double amaunt) {
            this.Balance = amaunt;
        }

        internal void Withdrow(Double amaunt) {
            if( this.Balance < 0.1 ) {
                throw new DomainException("Balance Is Low That 0.1");
            }

            if( this.WithdrowLimit < amaunt ) {
                throw new DomainException("Withdrow Limit Is Low That amaunt");
            }

            this.Balance -= amaunt;
        }

        public override String ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() {WriteIndented = true});
        }
    }
}
