using System.Globalization;

using FeeCalculator.Entity;

internal class Program {

    private static List<Pessoa> _pessoaList = [];
    private static Double _totalDeImpostos;

    internal static void Main(String[] args) {
        Console.WriteLine("Fee Calculator");

        Int32 qcontribuentes;

        do {
            Console.Write("Quantidade de contribuentes >> ");
        } while( !Int32.TryParse(Console.ReadLine() ?? "1", out qcontribuentes) );

        String nome;
        Double rendaAnual, gastosSaude;
        Int32 numeroFuncionarios;
        Pessoa pessoa;
        for( Int32 i = 0; i < qcontribuentes; i++ ) {

            Console.WriteLine($"\n>> pessoa #{i + 1} <<");

            do {
                Console.Write("Nome >> ");
            } while( !((nome = Console.ReadLine() ?? "None") != String.Empty) );

            do {
                Console.Write("Renda Anual >> ");
            } while( !Double.TryParse(Console.ReadLine() ?? "0.0", NumberStyles.Any, null, out rendaAnual) );

        choiceBlockPersonType:
            Console.Write("Qual Tipo De Pessoa Voce Esta Prestes A Se Basear \n[F => Fisica | J => Juridica] >> ");
            Char choicePersonType = Char.ToUpper(Console.ReadKey().KeyChar);
            switch( choicePersonType ) {
                case 'F': {
                    pessoa = new PessoaFisica(nome, rendaAnual);

                    do {
                        Console.Write("\nGastos Com Saude >> ");
                    } while( !Double.TryParse(Console.ReadLine(), out gastosSaude) );

                    (( PessoaFisica ) pessoa).GastosSaude = gastosSaude;
                    break;
                }

                case 'J': {
                    pessoa = new PessoaJuridica(nome, rendaAnual);

                    do {
                        Console.Write("\nQuantidade Funcionario >> ");
                    } while( !Int32.TryParse(Console.ReadLine(), out numeroFuncionarios) );

                    (( PessoaJuridica ) pessoa).NumeroFuncionario = numeroFuncionarios;
                    break;
                }

                default: {
                    Console.WriteLine("Opção Invalida");
                    goto choiceBlockPersonType;
                }
            } // endSwitch
            Program._pessoaList.Add(pessoa);
        } // endFor
        for( Int32 i = 0; i < Program._pessoaList.Count; i++ ) {
            // poderia ser com foreach mas eu estava querendo uma contagem
            // e eu nao achei elegante colocar uma variavel que seria usada somente nesse escopo
            // fora do mesmo
            // ela vai continuar fora do escopo, porem vai ficar elegante kkk

            // queria a contagem pra usar aqui
            Console.WriteLine($"\n>> pessoa #{i} <<");

            Pessoa p = Program._pessoaList[i];
            switch( p ) {
                case PessoaFisica: {
                    Console.WriteLine("\t[Pessoa Fisica]");
                    Console.WriteLine("\n" + p.ToString());
                    Program._totalDeImpostos += p.CaucularInposto();
                    break;
                }

                case PessoaJuridica: {
                    Console.WriteLine("\t[Pessoa Juridica]");
                    Console.WriteLine("\n" + p.ToString());
                    Program._totalDeImpostos += p.CaucularInposto();
                    break;
                }
            }
        } // endForeach
        Console.WriteLine("\n>>>>>>> Total de impostos arrecadados de todos <<<<<<<" +
            $"R$: {Program._totalDeImpostos}");
    } // endMain
} // endClass