using Alura.Adopet.Console.Comandos;

Console.ForegroundColor = ConsoleColor.Green;

var comandoDoSistema = new ComandosDoSistema(args);

try
{
    //string comando = args[0].Trim();
    string comando = "help";
    IComando? cmd = comandoDoSistema[comando];
    if (cmd is not null)
    {
        await cmd.ExecutarAsync(args);
    }
    else
    {
        Console.WriteLine("Comando inválido!");
    }
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}
