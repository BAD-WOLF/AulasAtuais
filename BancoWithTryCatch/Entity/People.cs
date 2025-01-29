namespace BancoWithTryCatch.Entity {
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using BancoWithTryCatch.Entity.Exception;

    internal class People {

        [JsonInclude]
        private UInt32 _id;
        [JsonInclude]
        private String _name;
        [JsonInclude]
        private UInt32 _age;

        internal People(UInt32 id, String name, UInt32 age) {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        internal UInt32 Id {
            get {
                return this._id;
            }

            private set {
                this._id = value;
            }
        }

        internal String Name {
            get {
                return this._name;
            }

            set {
                this._name = value;
            }
        }

        internal UInt32 Age {
            get {
                return this._age;
            }

            set {
                if( value < 18 ) {
                    throw new DomainException("Children Not Allowed");
                }
                this._age = value;
            }
        }

        public override String ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() {WriteIndented = true});
        }
    }
}