using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Utilitariosç;
using FluentResults;

Console.ForegroundColor = ConsoleColor.Green;

var comandoDoSistema = FabricaDeComandos.CriarComando(args);

if (comandoDoSistema is not null)
{
    var resultado = await comandoDoSistema.ExecutarAsync();
    ConsoleUI.ExibeResultadoNaTela(resultado);
}
else
{
    ConsoleUI.ExibeResultadoNaTela(Result.Fail("Comando inválido!"));
}
