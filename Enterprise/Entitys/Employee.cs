namespace Enterprise.Entitys {
    using System;

    internal class Employee {
        private String _name;
        private Int32 _hour;
        private Single _valuePerHour;

        public Employee(String name, Int32 hour, Single valuePerHour) {
            this._name = name;
            this._hour = hour;
            this._valuePerHour = valuePerHour;
        }

        public String Name { get => this._name; set => this._name = value; }
        public Int32 Hour { get => this._hour; set => this._hour = value; }
        public Single ValuePerHour { get => this._valuePerHour; set => this._valuePerHour = value; }

        public virtual Single Payment() {
            return this.ValuePerHour * this.Hour;
        }
    }
}
