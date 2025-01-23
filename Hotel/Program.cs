using Hotel.Entity;

internal class Program {

    private static List<Reservation> _resevationList = [];

    private static void Main(string[] args) {

        Console.Write("Numero De Reservas A Serem Feitas >> ");
        Int32 N = Int32.Parse(Console.ReadLine()!);
        for( Int32 i = 0; i < N; i++ ) {
            Program.GetDatasInConsole();
            Console.WriteLine();
        }

        Program.ShowDataList();

        // Usuario Quer Editar Algum Dado?
        char y_n;
        while( true ) {
            Console.Write("Deseja alterar alguma? [Y/n]: ");
            y_n = Char.ToUpper(Console.ReadKey().KeyChar);
            if( y_n.Equals('N') ) {
                Console.WriteLine("\nOk, Finalizado Então!!");
                return;
            }
            Program.EditReservationList();
            Program.ShowDataList();
        }

    }

    private static void ShowDataList() {
        Console.WriteLine("[ Até Então Vc Tem As Seguintes Reserves ]");
        for( Int32 i = 0; i < Program._resevationList.Count; i++ ) {
            Console.Write($"\nNumero Do Resistro => # {i + 1}");
            Reservation reservation = Program._resevationList[i];
            Console.WriteLine(reservation);
        }
    }

    private static (UInt32 roomNumber, DateTime checkin, DateTime checkout) GetDatasInConsole(Boolean saveInList = true) {
        UInt32 roomNumber;
        DateTime checkin, checkout;

        do {
            Console.Write("Numero De Quartos >> ");
        } while( !UInt32.TryParse(Console.ReadLine()!, default, out roomNumber) );

        do {
            Console.Write("Checkin >> ");
        } while( !DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, default, out checkin) && checkin >= DateTime.Now);

        do {
            Console.Write("Checkout >> ");
        } while( !DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, default, out checkout) && checkout > checkin );
        if( saveInList ) {
            Program._resevationList.Add(new Reservation(roomNumber, checkout, checkout));
        }
        return (roomNumber, checkin, checkout);
    }

    private static void EditReservationList() {

        Int32 reservationIndex;
        do {
            Console.Write("Numero Representativo De Reservation >> ");
        } while( !Int32.TryParse(Console.ReadLine()!, null, out reservationIndex) );

        Program._resevationList[reservationIndex - 1].UpdateDates(Program.GetDatasInConsole(false));

    }
}






