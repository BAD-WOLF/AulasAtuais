namespace Enterprise.Entitys {

    internal sealed class OutsourcedEmployee(String name, Int32 hour, Single valuePerHour, Single additionalCharge) : Employee(name, hour, valuePerHour) {
        private Single _additionalCharge = additionalCharge;

        public Single AdditionalCharge { get => this._additionalCharge; set => this._additionalCharge = value; }

        public override Single Payment() {
            Single value = base.Payment();
            return (this.AdditionalCharge * (110 / 100)) + value;
        }
    }
}
