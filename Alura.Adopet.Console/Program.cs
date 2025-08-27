using Alura.Adopet.Console.Comandos;

Console.ForegroundColor = ConsoleColor.Green;

IDictionary<string, IComando> comandos = new Dictionary<string, IComando>()
{
    {"import", new Importar()},
    {"help", new Ajuda()},
    {"show", new Exibir()},
    {"list", new Listar()},
};

try
{
    string comando = args[0].Trim();
    if (comandos.ContainsKey(comando))
    {
        var cmd = comandos[comando];
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
