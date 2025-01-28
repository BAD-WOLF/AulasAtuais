namespace Hotel.Entity.Exceptions {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class DomainException : ApplicationException {
        internal DomainException(String? message) : base(message) {

        }
    }
}
