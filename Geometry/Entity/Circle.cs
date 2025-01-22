namespace Geometry.Entity {
    using Geometry.Entity.Enum;

    internal class Circle : Shape {
        
        private Double _radius;
        public Double Radius { get => this._radius; set => this._radius = value; }

        public Circle(Color color, Double radius) : base(color) {
            this.Radius = radius;
        }

        internal override Double  Area() {
            this.AreaValue = Math.PI * Math.Pow(this.Radius, 2);
            return this.AreaValue;
        }

        public override String ToString() =>
            $"This Shape Is A Circle With {this.Radius} Radius\nArea: {this.Area()}\nColor: {this.Color}";
    }
}
