namespace FeeCalculator.Entity {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class PessoaJuridica(String nome, Double rendaAnual) : Pessoa(nome, rendaAnual) {
        private Int32  _numeroFuncionario;

        public Int32 NumeroFuncionario { get => this._numeroFuncionario; set => this._numeroFuncionario = value; }

        internal override Double CaucularInposto() {
            switch( this.NumeroFuncionario ) {
                case Int32 nfuncionarios when(nfuncionarios < 10): {
                    return (16 * this.RendaAnual) / 100; 
                }

                default: {
                    return (14 * this.RendaAnual) / 100;
                }
            }
        }

        public override String ToString() {

            Dictionary<Int32, Object[]> upDownDictionary = new Dictionary<Int32, Object[]>() {
                {
                    0, new Object[2]
                    {
                        "acima",
                        14
                    }
                },

                {
                    1, new Object[2]
                    {
                        "abaixo",
                        16
                    }
                },
            };

            Object[] selectedUpDownArray = this.NumeroFuncionario < 10? upDownDictionary[0] : upDownDictionary[1];

            return
                base.ToString() +
                $"\nsua renda anual com {selectedUpDownArray[1]}% descontado é >> R$: {this.RendaAnual - this.CaucularInposto()} (desconto de {selectedUpDownArray[1]}% na renda porque seu numero de funcionarios esta {selectedUpDownArray[1]} de 10)" +
                $"\ncom quanto o governo ficou do seu dinheiro >> R$: {this.CaucularInposto()}";
        }
    }
}
