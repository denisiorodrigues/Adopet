using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Utilitariosç;
using FluentResults;

Console.ForegroundColor = ConsoleColor.Green;
string [] comandos = ["import", "lista.csv"];

var comandoDoSistema = new ComandosDoSistema(args);

//Console.WriteLine("Comandos digitados : ", args);
//for (int i = 0; i < args.Length; i++)
//{
//    Console.WriteLine($"Argumento {i}: {args[i]}");
//}



string comando = args[0].Trim();
//string comando = "help";
IComando? cmd = comandoDoSistema[comando];
if (cmd is not null)
{
    var resultado = await cmd.ExecutarAsync(args);
    ConsoleUI.ExibeResultadoNaTela(resultado);
}
else
{
    ConsoleUI.ExibeResultadoNaTela(Result.Fail("Comando inválido!"));
}
