namespace Hotel.Entity {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;

    internal class Reservation {
        private UInt32    _roomNumber;
        private DateTime _checkin = DateTime.Now;
        private DateTime _checkout = DateTime.MaxValue;

        internal Reservation(UInt32 roomNumber, DateTime checkin, DateTime checkout) {
            this.RoomNumber = roomNumber;
            this.Checkin = checkin;
            this.Checkout = checkout;
        }

        internal Reservation((UInt32 roomNumber, DateTime checkin, DateTime checkout) data) {
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
            ;
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
