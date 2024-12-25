namespace BuyProducts.Entity {

    internal class ImportedProduct : Product {

        private Double _customsFee;
        internal Double CustomsFee { get => this._customsFee; set => this._customsFee = value; }

        internal ImportedProduct(String name, Double price, Double customsFee) : base(name, price) {
            this.CustomsFee = customsFee;
        }

        

        internal override String PriceTag() {
            return base.PriceTag() + $" Porem, Foi Acrecido Uma Taxinha Do Amor de: R$: {this.CustomsFee}\nvalor total de R$: {this.TotalPrice()}\n";
        }

        internal Double TotalPrice() {
            return this.Price + this.CustomsFee;
        }
    }
}
