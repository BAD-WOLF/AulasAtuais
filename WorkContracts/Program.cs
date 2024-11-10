using Aulas.Entitys;
using Aulas.Entitys.Enums;

internal class Program {

    private static void Main(String[] args) {
        Console.Write("What's Departament Name: ");
        String departamentName = Console.ReadLine() ?? throw new ArgumentNullException();

        Console.Write("What's Your Name: ");
        String workerName = Console.ReadLine() ?? throw new ArgumentNullException();


        Console.Write("What's Ur Level ( [0]Junior | [1]MidLevel| [2]Senior ): ");
        Int32 numberOfChoiceLevel = Int32.Parse(Console.ReadLine() ?? "0");
        WorkerLevel level;
        switch (numberOfChoiceLevel) {
            case 0: {
                level = WorkerLevel.JUNIOR;
                break;
            }
            case 1: {
                level = WorkerLevel.MID_LEVEL;
                break;
            }
            case 2: {
                level = WorkerLevel.SENIOR;
                break;
            }
            default: {
                throw new ArgumentOutOfRangeException(nameof(level), "Opção Não Listada!!");
            }
        }

        Console.WriteLine(level);

        Console.Write("What's Ur Base Salary: ");
        Single baseSalary = Single.Parse(Console.ReadLine() ?? "0.0");

        Console.Write("How Many Contracts To This Worker: ");
        Int32 QuantityOfContracts = Int32.Parse(Console.ReadLine() ?? "1");


        String messageToMouth = "Frist Insert The month: ";
        String messageToYear = "Now Insert The Year: ";
        HourContracts[] contractsData = new HourContracts[QuantityOfContracts];
        for (Int32 i = 0; i < QuantityOfContracts; i++) {
            Console.WriteLine($"\nContract #{i + 1}");

            Console.WriteLine("Enter The Date Of Contract");
            // month and year to insert in class DateOnly {
            Int32 month;
            Int32 year;
            // }

            // Instatiating the object DateOnly (date) {
            Console.Write(messageToMouth);
            while (!Int32.TryParse(Console.ReadLine(), out month))
                Console.Write(messageToMouth);

            Console.Write(messageToYear);
            while (!Int32.TryParse(Console.ReadLine() ?? DateTime.Now.Year.ToString() , out year))
                Console.Write(messageToYear);

            DateOnly date = new DateOnly(year, month, DateTime.Now.Day);
            // }

            
            Console.Write("What's Value Per Hour To This Contract: ");
            Single valuePerHour;
            while (!Single.TryParse(Console.ReadLine(), out valuePerHour))
                Console.Write("");
            

            Console.Write("Duration (Hours): ");
            Int32 hour;
            while (!Int32.TryParse(Console.ReadLine(), out hour))
                Console.Write("");

            // Instantiate each position of the type HourContracts of the Array (contractsData) {
            contractsData[i] = new HourContracts(date, valuePerHour, hour);
            // }
        }
        // ate entao so execultar
        // departamente name is meccessary
        Worker worker = new Worker(departamentName, workerName, level, baseSalary) { HourContracts = contractsData };

        Console.WriteLine($"departament name: {worker.DepartamentName}");
        Console.WriteLine($"worker name: {worker.WorkerName}");
        Console.WriteLine($"worker level: {worker.Level}");
        Console.WriteLine($"basy salary: {worker.BasySalary}");
        Console.WriteLine($"Hour Contracts: {worker.HourContracts}");
        Console.WriteLine("Cauculing salary value: ");
        Console.Write("month: ");
        #pragma warning disable CS8604 // Possível argumento de referência nula.
        Int32 monthC = Int32.Parse(Console.ReadLine());
        Console.Write("year: ");
        Int32 yearC = Int32.Parse(Console.ReadLine());
        #pragma warning restore CS8604
        Console.Write($"Incom: {worker.Income(monthC, yearC)}");
        Console.ReadKey();
    }
}