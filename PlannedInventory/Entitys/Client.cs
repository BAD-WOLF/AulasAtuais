﻿namespace PlannedInventory.Entitys {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Client {
        private String _name;
        private String _email;
        private DateOnly _birthDate;

        public Client() {
        }

        public Client(String name, String email, DateOnly birthDate) {
            this._name = name;
            this._email = email;
            this._birthDate = birthDate;
        }

        internal String Name { get => this._name; set => this._name = value; }
        internal String Email { get => this._email; set => this._email = value; }
        internal DateOnly BirthDate { get => this._birthDate; set => this._birthDate = value; }

    }
}