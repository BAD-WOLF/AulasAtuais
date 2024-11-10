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

            Console.Write("U is a sourced employee? [Y/n]: ");
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
        T result;
        do {
            Console.Write(txt);
        } while( !TryParse(Console.ReadLine(), out result) );
        return result;
    }

    private static bool TryParse<T>(string input, out T result) where T : struct {
        result = default;

        var tryParseMethod = typeof(T).GetMethod("TryParse", new[] { typeof(string), typeof(T).MakeByRefType() });

        if( tryParseMethod != null ) {
            var parameters = new object[] { input, null };
            bool success = (bool)tryParseMethod.Invoke(null, parameters);

            if( success )
                result = ( T ) parameters[1];

            return success;
        }

        return false;
    }

}