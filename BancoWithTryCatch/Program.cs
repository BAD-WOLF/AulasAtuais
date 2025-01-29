using System.Text.Json;

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
                Program._accontList.Add(new Accont(i, 2 * i, 50, pessoa));
            }

            Console.WriteLine("\n[ Ok, All Good, We'll Show Now The Result ]\n");

            foreach( Accont i in Program._accontList ) {
                Console.WriteLine(i.ToString());
            }

            Accont accont1 = Program._accontList[0];
            accont1.Deposit(51);
            Console.WriteLine($"\nThe {accont1.Pessoa.Name} Person's Accont Has Now Its Data Modified: \n");

            String jsonAccontModified = JsonSerializer.Serialize(accont1, new JsonSerializerOptions() {WriteIndented=true});

            Console.WriteLine(jsonAccontModified);

            Double withdraw = 50;

            accont1.Withdraw(withdraw);

            Console.WriteLine($"\nI Do A Withdrawal Of {withdraw} Dollas And The Balance Now Is: \n");

            Console.WriteLine($"Balance: {accont1.Balance}\n");

            Console.WriteLine("New withdrow of only one dolla: ");

            accont1.Withdraw(1);

            Console.WriteLine($"Balance: {accont1.Balance}");
        } catch (DomainException e) {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}