using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Utilitariosç;
using FluentResults;

Console.ForegroundColor = ConsoleColor.Green;
string [] comandos = ["import", "lista.csv"];

var comandoDoSistema = new ComandosDoSistema(args);

string comando = args[0].Trim();
//string comando = "help";
IComando? cmd = comandoDoSistema[comando];
if (cmd is not null)
{
    var resultado = await cmd.ExecutarAsync();
    ConsoleUI.ExibeResultadoNaTela(resultado);
}
else
{
    ConsoleUI.ExibeResultadoNaTela(Result.Fail("Comando inválido!"));
}
