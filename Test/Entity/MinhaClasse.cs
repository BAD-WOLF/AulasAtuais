namespace Test.Entity {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    internal class MinhaClasse {

        [JsonInclude]
        private int _id;
        [JsonInclude]
        private string _nome;

        internal MinhaClasse(Int32 id, String nome) {
            this.Id = id;
            this.Nome = nome;
        }

        internal Int32 Id {
            get {
                return this._id;
            }

            set {
                this._id = value;
            }
        }

        internal String Nome {
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
