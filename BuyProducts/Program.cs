using System.Collections.Generic;
using System.Linq;

using BuyProducts.Entity;

internal static class Program {

    private static Dictionary<String, Char[]> _choiceProductType { get; } = new Dictionary<String, Char[]>() {
        {"Product",  new char[2] {'1', 'p'} },
        {"ImportedProduct", new Char[2] {'2', 'i'} },
        {"UsedProduct", new Char[2] {'3', 'u'} }
    };

    private static String? _name;
    private static Single _price;

    internal static String? Name { get => Program._name; set => Program._name = value; }
    internal static Single Price { get => Program._price; set => Program._price = value; }


    private static String[] _choiceStates = [];
    internal static dynamic ChoiceState {
        get => Program._choiceStates;
        set => ArrayBuilder.Add(ref Program._choiceStates, value);
    }

    private static Product[] _products = [];
    internal static dynamic Products {
        get => Program._products;
        set => ArrayBuilder.Add(ref Program._products, value);
    }

    private static void Main(String[] args) {
        // Variaveis base para telas dentro do for
        Console.Write("Quantos Produdos Vão Ser? >> ");
        Char choiceProductType;
        int NProducts = int.Parse(Console.ReadLine() ?? "1");

        // A bricadeira começa aqui lol
        for( Int32 i = 0; i < NProducts; i++ ) {
            Console.WriteLine("\nQual Vai Ser?");
            Console.WriteLine("1 - (P): Produto Normal\n2 - (I): Produto Inter\n3 - (U): Produto Usado");

           ChoiceBlockProductTypeLoop:
            do {
                Console.Write("P / I / U >> ");
            } while( (!Char.TryParse(Console.ReadLine()?.ToLower(), result: out choiceProductType)) );
            if( !Program._choiceProductType.Values.Any(XArray => XArray.Contains(choiceProductType)) ) {
                Console.WriteLine("Opção Invalida.");
                goto ChoiceBlockProductTypeLoop;
            }

            do {
                Console.Write("Name >> ");
            } while( !((Program.Name = Console.ReadLine()) != String.Empty) );

            do {
                Console.Write("Price >> ");
            } while( !(Single.TryParse(Console.ReadLine(), out Program._price)) );

            switch( Program._choiceProductType ) {
                case var CPT when CPT["Product"].Contains(choiceProductType):
                Program.ChoiceState = "[ 1 - P ]";
                Console.WriteLine("Processando Pedido [ 1 - P ] Produto Local ....");
                Program.Products = new Product(Program.Name, Program.Price);
                break;

                case var CPT when CPT["ImportedProduct"].Contains(choiceProductType):
                Program.ChoiceState = "[ 2 - I ]";
                Console.WriteLine("Processando Pedido [ 2 - I ] Produto Internacional ....");
                Console.WriteLine("Porem, Antes Devemos Lhe Requerir A Taxinha Do Amor ....");

                Double customsFee;
                do {
                    Console.Write("Custom Fee >> ");
                } while( !(Double.TryParse(Console.ReadLine(), out customsFee)) );

                Program.Products = new ImportedProduct(Program.Name!, Program.Price, customsFee);
                break;

                case var CPT when CPT["UsedProduct"].Contains(choiceProductType): {
                    Program.ChoiceState = "[ 3 - U ]";
                    Console.WriteLine("Processando Pedido [ 3 - U ] Produto Usado ...");
                    Console.WriteLine("Porem, Como É Um Produto Usado, Devemos Lhe Requerir A Data De Fabricaçao ....");
                    DateTime manufactureDate;
                    do {
                        Console.Write("Manufacture Date >> ");
                    } while( !DateTime.TryParseExact(Console.ReadLine(), new String[2] { "dd/MM/yyyy", "dd-MM-yyyy" }, System.Globalization.CultureInfo.InvariantCulture, default, out manufactureDate) );
                    Program.Products = new UsedProduct(Program.Name!, Program.Price, manufactureDate);
                    break;
                }

                default: {
                    goto ChoiceBlockProductTypeLoop; // Se nenhuma das condições for atendida
                }
            }
            Console.WriteLine("".ToLower());
            Console.WriteLine("Produto Processado!");
        }

        Console.WriteLine("\n{ Ordem De Registro }");
        foreach( String str in Program.ChoiceState ) {
            Console.WriteLine($"Pedido: {str}");
        }

        foreach( Product product in Program.Products ) {
            switch( product ) {
                case ImportedProduct: {
                    Console.WriteLine(product.PriceTag());
                    break;
                }
                case UsedProduct: {
                    Console.WriteLine(product.PriceTag());
                    break;
                }
            }
            if( product.GetType().Equals(typeof(Product)) ) {
                Console.WriteLine(product.PriceTag() + "\n");
            }
        }
    }
}

internal static class ArrayBuilder {
    internal static T[] Add<T>(ref T[] array, T content) {
        Array.Resize(ref array, array.Length + 1);
        array[^1] = content;
        return array;
    }
}
