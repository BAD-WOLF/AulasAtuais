namespace FeeCalculator.Entity {

    internal abstract class Pessoa {
        private String _nome;
        private Double _rendaAnual;

        internal Pessoa(String nome, Double rendaAnual) {
            this.Nome = nome;
            this.RendaAnual = rendaAnual;
        }

        internal String Nome { get => this._nome; set => this._nome = value; }
        internal Double RendaAnual { get => this._rendaAnual; set => this._rendaAnual = value; }

        internal abstract Double CaucularInposto();

        public override String ToString() {
            return
                $"nome da pessoa >> {this.Nome}" +
                $"\nsua renda anual foi de >> R$: {this.RendaAnual} (sem desconte imposto)";
        }
    }
}
