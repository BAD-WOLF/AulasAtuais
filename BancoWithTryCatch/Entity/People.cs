namespace BancoWithTryCatch.Entity {
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using BancoWithTryCatch.Entity.Exception;

    internal class People {
        public UInt32 _id;
        public String _name;
        public UInt32 _age;

        public People(UInt32 id, String name, UInt32 age) {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        public UInt32 Id {
            get {
                return this._id;
            }

            private set {
                this._id = value;
            }
        }

        public String Name {
            get {
                return this._name;
            }

            set {
                this._name = value;
            }
        }

        public UInt32 Age {
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