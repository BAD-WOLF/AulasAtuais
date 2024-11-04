namespace PlannedInventory.Entitys {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Product {
        private  String _name;
        internal Single _price;

        internal String Name { get => this._name; set => this._name = value; }
        internal Single Price { get => this.Price; set => this._price = value; }

        public Product(String name, Single price) {
            this._name = name;
            this._price = price;
        }

        internal Product() { }
    }
}
