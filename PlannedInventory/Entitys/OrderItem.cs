namespace PlannedInventory.Entitys {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class OrderItem {
        private Int32 _quantity;
        private Single _price;
        private Product _product;

        public OrderItem(String name, Single price, Int32 quantity) {
            this._quantity = quantity;
            this._price = price;
            this._product = new Product();
            this.Product(name, price);
        }

        internal Int32 Quantity { get => this._quantity; set => this._quantity = value; }
        internal Single Price { get => this._price; set => this._price = value; }

        internal Product Product(String name, Single price) {
            (this._product.Name, this._product.Price) = (name, price);
            return this._product;
        }

        internal Product Product() {
            return this._product;
        }

        internal Single SubTotal() {
            return this.Quantity * this.Price;
        }
    }
}
