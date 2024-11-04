namespace Aulas.Entitys
{
    using System;

    internal class Departament
    {
        private String _departamentName;

        public String DepartamentName
        {
            get => this._departamentName; set => this._departamentName = value;
        }

#pragma warning disable CS8618
        // O campo não anulável precisa conter um valor não nulo ao sair do construtor.
        // Considere adicionar o modificador "obrigatório" ou declarar como anulável.
        public Departament(String departamentName) => this.DepartamentName = departamentName;
#pragma warning restore CS8618

    }
}
