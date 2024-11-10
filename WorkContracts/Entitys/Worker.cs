namespace Aulas.Entitys {
    using System;

    using Aulas.Entitys.Enums;

    internal class Worker : Departament {
        private String _workerName;
        private WorkerLevel _level;
        private Single _basySalary;
        private HourContracts[] _hourContracts; // = new HourContracts[0];

        public String WorkerName {
            get => this._workerName; set => this._workerName = value;
        }
        public Single BasySalary {
            get => this._basySalary; set => this._basySalary = value;
        }
        internal WorkerLevel Level {
            get => this._level; set => this._level = value;
        }
        internal required HourContracts[] HourContracts {
            get => this._hourContracts;
            set {
                // Array.Resize(ref this._hourContracts, value.Length);
                this._hourContracts = value;
            }
        }


#pragma warning disable CS8618
        // O campo não anulável precisa conter um valor não nulo ao sair do construtor.
        // Considere adicionar o modificador "obrigatório" ou declarar como anulável.
        public Worker(
            String departamentName,
            String workerName,
            WorkerLevel workerLevel,
            Single basySalary
            ) : base(departamentName) {
            // Scop Content ...               
            this.WorkerName = workerName;
            this.Level = workerLevel;
            this.BasySalary = basySalary;
        }
#pragma warning restore CS8618

        internal void AddContract(HourContracts[] hourContracts) {
            this.HourContracts = hourContracts;
        }

        internal void RemoveContract(HourContracts hourContracts) {
            Array.Clear(this._hourContracts, Array.IndexOf(this.HourContracts, hourContracts), 1);
        }

        internal Single Income(Int32 month, Int32 year) => this.HourContracts
                .Where(x => x.Date.Month == month && x.Date.Year == year)
                .Select(x => x.TotalValue())
                .ToArray()
                .Sum() + this.BasySalary;
    }
}
