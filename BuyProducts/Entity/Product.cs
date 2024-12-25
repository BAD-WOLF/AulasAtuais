namespace BuyProducts.Entity {
    using System;

    internal class Product {
        private String _name;
        private Double _price;

        #pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere adicionar o modificador "obrigatório" ou declarar como anulável.
        public Product(String name, Double price) {
            this.Name = name;
            this.Price = price;
        }
        #pragma warning restore CS8618 

        internal String Name { get => this._name; set => this._name = value; }
        internal Double Price { get => this._price; set => this._price = value; }

        internal virtual String PriceTag() {
            return $"O Preço Do {this.Name} É: R$: {this.Price}";
        }
    }
}
