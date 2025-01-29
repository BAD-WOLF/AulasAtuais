namespace BancoWithTryCatch.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using BancoWithTryCatch.Entity.Exception;

    internal class Accont {

        [JsonInclude]
        private UInt32 _id;
        [JsonInclude]
        private Double _balance;
        [JsonInclude]
        private Double _withdrowLimit;
        [JsonInclude]
        private People _pessoa;

        internal Accont(UInt32 id, Double balance, Double withdrawLimit, People pessoa) {
            this.ID = id;
            this.Balance = balance;
            this.WithdrawLimit = withdrawLimit;
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

            private set {
                this._balance = value;
            }
        }

        internal Double WithdrawLimit {
            get {
                return this._withdrowLimit;
            }

            private set {
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

        internal void Withdraw(Double amaunt) {
            if( this.Balance < 0.1 ) {
                throw new DomainException("Balance Is Low That 0.1");
            }

            if( this.WithdrawLimit < amaunt ) {
                throw new DomainException("Withdraw Limit Is Low That amaunt");
            }

            this.Balance -= amaunt;
        }

        public override String ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() {WriteIndented = true});
        }
    }
}
