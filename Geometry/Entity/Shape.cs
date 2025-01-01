namespace Geometry.Entity {
    using Geometry.Entity.Enum;

    internal abstract class Shape {

        private Color _color;
        internal Color Color { get => this._color; set => this._color = value; }

        private Double _areaValue;
        internal Double AreaValue { get => this._areaValue; set => this._areaValue = value; }

        internal Shape(Color color) => this.Color = color;

        internal abstract Double Area();

    }
}
