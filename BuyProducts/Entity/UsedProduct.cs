namespace BuyProducts.Entity {

    internal class UsedProduct : Product {

        private DateTime _manufactureDate;
        internal DateTime ManufactureDate { get => this._manufactureDate; set => this._manufactureDate = value; }

        internal UsedProduct(String name, Double price, DateTime manufactureDate) : base(name, price) {
            this.ManufactureDate = manufactureDate;
        }

        internal override String PriceTag() {
            return base.PriceTag() + $" Porem, Esse Produto Já Foi Usado, Mas Já Logo Avisando Que Não Tem Desconto\nData De Fabricação: [{this.ManufactureDate}]\n";
        }
    }
}
