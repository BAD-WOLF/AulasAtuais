namespace BancoWithTryCatch.Entity.Exception {
    using System;
    using System.Collections.Generic;

    internal class DomainException(String? message) : ApplicationException(message) {

    }
}
