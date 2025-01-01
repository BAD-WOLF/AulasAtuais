namespace Geometry.Entity {
    using Geometry.Entity.Enum;

    internal class Rectangle : Shape {

        private Double _width;
        internal Double Width { get => this._width; set => this._width = value; }

        private Double _height;
        internal Double Height { get => this._height; set => this._height = value; }

        public Rectangle(Color color, Double width, Double height) : base(color: color) {
            this.Width = width;
            this.Height = height;
        }

        internal override Double Area() {
            this.AreaValue = ( Double ) this.Width * ( Double ) this.Height;
            return this.AreaValue;
        }

        public override String ToString() => 
            $"This Shape Is A Rectangle With {this.Width} Width And {this.Height} Height\nArea: {this.AreaValue}\nColor: {this.Color}";
    }
}
