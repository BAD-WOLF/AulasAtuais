namespace Test.Entity {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    internal class MinhaClasse {

        private int _id;
        private string _nome;

        public MinhaClasse(Int32 id, String nome) {
            this.Id = id;
            this.Nome = nome;
        }

        public Int32 Id {
            get {
                return this._id;
            }

            set {
                this._id = value;
            }
        }

        public String Nome {
            get {
                return this._nome;
            }

            set {
                this._nome = value;
            }
        }

        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }
    }
}
