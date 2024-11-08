namespace Enterprise.Entitys {

    internal sealed class OutsourcedEmployee(String name, Int32 hour, Single valuePerHour, Int32 additionalCharge) : Employee(name, hour, valuePerHour) {
        private Int32 _additionalCharge = additionalCharge;

        public Int32 AdditionalCharge { get => this._additionalCharge; set => this._additionalCharge = value; }

        public override Single Payment() {
            Single value = base.Payment();
            return value * (this.AdditionalCharge / 100);
        }
    }
}
