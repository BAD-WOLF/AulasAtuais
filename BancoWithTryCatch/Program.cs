using BancoWithTryCatch.Entity;
using BancoWithTryCatch.Entity.Exception;

internal class Program {

    private static List<Accont> _accontList = [];

    private static void Main(string[] args) {
        try {
            Console.WriteLine("<< Banco With Try-Catch >>\n");

            Console.Write("Whats Quantity Of People Will Make Accont >> ");
            Int32 qntt =  Int32.Parse(Console.ReadLine()!);

            Console.WriteLine("\nProccessing Peoples");
            People pessoa;
            for( UInt32 i = 0; i < qntt; i++ ) {
                pessoa = new People(i, $"Pessoa-{i + 1}", 18 + i);
                Program._accontList.Add(new Accont(i, 2 * i, 1000, pessoa));
            }

            Console.WriteLine("\n[ Ok, All Good, We'll Show Now The Result ]\n");

            foreach( Accont i in Program._accontList ) {
                Console.WriteLine(i.ToString());
                Console.WriteLine(i.ID);
            }
        } catch (DomainException e) {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}