namespace Hotel.Entity {
    using System;
    using Hotel.Entity.Exceptions;

    internal class Reservation {


        private UInt32    _roomNumber;
        private DateTime _checkin = DateTime.Now;
        private DateTime _checkout = DateTime.MaxValue;

        internal Reservation(UInt32 roomNumber, DateTime checkin, DateTime checkout) {
            if( roomNumber <= 0 ) {
                throw new DomainException("Error: O Numero De Rooms (Quartos) Deve Ser Maior Que 0");
            }

            if( checkin < DateTime.Now.Date ) {
                throw new DomainException($"Error: O Chechin Deve Ser Uma Data Presente Ou Futura, hoje é {DateTime.Now}");
            }

            if( checkout <= checkin ) {
                throw new DomainException("Error: O Checkout Deve Ser Uma Data Futura");
            }
            this.RoomNumber = roomNumber;
            this.Checkin = checkin;
            this.Checkout = checkout;
        }

        internal void UpdateDates((UInt32 roomNumber, DateTime checkin, DateTime checkout) data) {
            if( data.roomNumber <= 0 ) {
                throw new DomainException("Error: O Numero De Rooms (Quartos) Deve Ser Maior Que 0");
            }

            if( data.checkin < DateTime.Now.Date ) {
                throw new DomainException("Error: O Chechin Deve Ser Uma Data Presente Ou Futura");
            }

            if( data.checkout <= data.checkin) {
                throw new DomainException("Error: O Checkout Deve Ser Uma Data Mior Que A De Checkin");
            }

            this.RoomNumber = data.roomNumber;
            this.Checkin = data.checkin;
            this.Checkout = data.checkout;

        }

        internal UInt32 RoomNumber {
            get {
                return this._roomNumber;
            }

            set {
                this._roomNumber = value;
            }
        }

        internal DateTime Checkin {
            get {
                return this._checkin;
            }

            set {
                this._checkin = value;
            }
        }

        internal DateTime Checkout {
            get {
                return this._checkout;
            }

            set {
                this._checkout = value;
            }
        }

        internal Int32 Duration() {
            return this.Checkout.Subtract(this.Checkin).Days;
        }

        public override String ToString() {
            return
                $"\nNumero De Quartos: {this.RoomNumber}" +
                $"\nData De checkin: {this.Checkin}" +
                $"\nData Checkout: {this.Checkout}" +
                $"\nDias Que Vou Ficar: {this.Duration()}";
        }
    }
}
