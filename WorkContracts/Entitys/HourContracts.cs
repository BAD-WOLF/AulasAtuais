namespace Aulas.Entitys
{
    using System;

    internal class HourContracts
    {
        private DateOnly _date;
        private Single _valuePerHour;
        private Int32 _hour;

        public DateOnly Date
        {
            get => this._date; set => this._date = value;
        }
        public Single ValuePerHour
        {
            get => this._valuePerHour; set => this._valuePerHour = value;
        }
        public Int32 Hour
        {
            get => this._hour; set => this._hour = value;
        }

        public HourContracts(DateOnly date, Single valuePerHour, Int32 hour)
        {
            this.Date = date;
            this.ValuePerHour = valuePerHour;
            this.Hour = hour;
        }

        internal Single TotalValue()
        {
            return this.ValuePerHour * this.Hour;
        }
    }

}
