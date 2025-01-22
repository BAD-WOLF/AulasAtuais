namespace FeeCalculator.Entity {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class PessoaFisica(String nome, Double rendaAnual) : Pessoa(nome, rendaAnual) {
        private Double _gastosSaude;

        internal Double GastosSaude { get => this._gastosSaude; set => this._gastosSaude = value; }

        internal override Double CaucularInposto() {
            switch( this.RendaAnual ) {
                case Double renda when(renda < 20000.00): {
                    return ((15 * renda) / 100) - ((50 * this.GastosSaude) / 100);
                }

                default: {
                    return ((25 * this.RendaAnual) / 100) - ((50 * this.GastosSaude) / 100);
                }
            } // endSwitch
        } // endConstruct

        public override String ToString() {

            Dictionary<Int32, Object[]> upDownDictionary =  new Dictionary<Int32, Object[]>() {
                {
                    0, new object[2]
                    {
                        "acima",
                        25
                    }
                },
                {
                    1, new object[2]
                    {
                        "abaixo",
                        15
                    }
                },
            };

            Object[] selectedUpDownArray = this.RendaAnual < 20000.00 ? upDownDictionary[1] : upDownDictionary[0];
            return
                base.ToString()! +
                $"\nsua renda foi {selectedUpDownArray[0]} de >> RS: 20000.00" +
                $"\nsua renda anual ja que ela foi {selectedUpDownArray[0]} vai ser descontado {selectedUpDownArray[1]}% de imposto" +
                $"\nsua renda anual com {selectedUpDownArray[1]}% descontado é >> R$: {this.RendaAnual - this.CaucularInposto()} (desconto de {selectedUpDownArray[1]}% na renda menos 50% dos gastos com saúde)" +
                $"\ncom quanto o governo ficou do seu dinheiro >> R$: {this.CaucularInposto()}";
        }
    } // endClass
}
