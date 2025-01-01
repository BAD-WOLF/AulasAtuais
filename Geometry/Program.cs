using Geometry.Entity;
using Geometry.Entity.Enum;

internal static class Program {

    private static List<Shape> _geometryObjList = [];

    private static void Main(string[] args) {

        Console.Write("What's Quantity >> ");
        Int32 N = Int32.Parse(Console.ReadLine() ?? "1");

        Char geometryType;
        Int32 choiceColor;
        Double shapeWidth, shapeHeight, shapeRadius;
        for( Int32 i = 0; i < N; i++ ) {
            Console.Write("\nWhat's Geometry Type [C|R] >> ");
            geometryType = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            switch( geometryType ) {
                case 'R': {
                    do {
                        Console.Write("Color [1 => Black | 2 => Blue | 3 => Red] >> ");
                    } while( !Int32.TryParse(Console.ReadLine() ?? "1", out choiceColor) );

                    do {
                        Console.Write("Width >> ");
                    } while( !Double.TryParse(Console.ReadLine() ?? "0.0", out shapeWidth) );

                    do {
                        Console.Write("Reight >> ");
                    } while( !Double.TryParse(Console.ReadLine() ?? "0.0", out shapeHeight) );

                    // Verifica se a cor escolhida é válida no enum Color
                    if( Enum.IsDefined(typeof(Color), choiceColor) ) {
                        Program._geometryObjList.Add(new Rectangle(( Color ) choiceColor, shapeWidth, shapeHeight));
                        break;
                    }
                    Console.WriteLine("A COR nao foi encontrada!!");
                    break;
                }
                case 'C': {
                    do {
                        Console.Write("Color [1 => Black | 2 => Blue | 3 => Red] >> ");
                    } while( !Int32.TryParse(Console.ReadLine() ?? "1", out choiceColor) );

                    do {
                        Console.Write("Radius >> ");
                    } while( !Double.TryParse(Console.ReadLine() ?? "0.0", out shapeRadius) );

                    if( Enum.IsDefined(typeof(Color), choiceColor) ) {
                        Program._geometryObjList.Add(new Circle(( Color ) choiceColor, shapeRadius));
                        break;
                    }
                    Console.WriteLine("A COR nao foi encontrada!!");
                    break;
                }
            }

            foreach( Shape j in Program._geometryObjList ) {
                switch( j ) {
                    case Rectangle: {
                        Console.WriteLine(j.ToString());
                        break;
                    }
                    case Circle: {
                        Console.WriteLine(j.ToString());
                        break;
                    }
                }
            }
        }
    }
}