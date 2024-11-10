using Enterprise.Entitys;

using static System.Int32;
using static System.Single;
// ReSharper disable BuiltInTypeReferenceStyle
// ReSharper disable SuggestVarOrType_SimpleTypes

namespace Enterprise;

internal sealed class Program {
    private static void Main(string[] args) {

        String name;
        // ReSharper disable once SuggestVarOrType_Elsewhere
        List<Employee> employees = [];
        Int32 employeeQuantity = ParseReadLineWithSuccess<Int32>("Quantity Of Employees >> ");


        for( int i = 0; i < employeeQuantity; i++ ) {

            Console.WriteLine($"employee #{i + 1}");

            do {
                Console.Write("Nome >> ");
            } while( (name = Console.ReadLine() ?? String.Empty).Length < 1 );

            Single valuePerHour = ParseReadLineWithSuccess<Single>("Value Per Hour >> ");

            Int32 hour = ParseReadLineWithSuccess<Int32>("Hour >> ");

            Console.Write("U is a Insourced employee? [Y/n]: ");
            char yesOrNo = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine(); // only jump line
            if( yesOrNo.Equals('Y') ) {
                employees.Add(new Employee(name, hour, valuePerHour));
                continue;
            }

            Single additionalCharge = ParseReadLineWithSuccess<Single>("Additional Charge >> ");
            employees.Add(new OutsourcedEmployee(name, hour, valuePerHour, additionalCharge));
        }

        foreach( Employee employee in employees ) {
            Console.WriteLine(employee.ToString());
        }

    }

    private static T ParseReadLineWithSuccess<T>(String txt) where T : struct {
        // ReSharper disable once TooWideLocalVariableScope
        T result;
        do {
            InitConvertType:
            Console.Write(txt);
            try {
                result = ( T ) Convert.ChangeType(Console.ReadLine()!, typeof(T));
            } catch {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error: Content Format Is Not Valid, Try Again!");
                Console.ResetColor();
                goto InitConvertType;
            }

            return result;
        } while( true );
    }

}