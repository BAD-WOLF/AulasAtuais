namespace Enterprise.Entitys {

    internal sealed class OutsourcedEmployee(String name, Int32 hour, Single valuePerHour, Single additionalCharge) : Employee(name, hour, valuePerHour) {
        public Single AdditionalCharge { get; set; } = additionalCharge;

        public override Single Payment() {
            Single value = base.Payment();
            return (this.AdditionalCharge * (110 / 100)) + value;
        }
    }
}
