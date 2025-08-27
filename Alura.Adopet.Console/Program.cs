using Alura.Adopet.Console.Comandos;

Console.ForegroundColor = ConsoleColor.Green;

try
{
    string comando = args[0].Trim(); 
    
    switch (comando)
    {
        case "import":
            var importar = new Importar();
            await importar.ExecutarAsync(args);
            break;
        case "help":
            var ajuda = new Ajuda();
            await ajuda.ExecutarAsync(args);
;           break;
        case "show":
            var exibir = new Exibir();
            await exibir.ExecutarAsync(args);
            break;
        case "list":
            var listar = new Listar();
            await listar.ExecutarAsync(args);
            break;
        default:
            Console.WriteLine("Comando inválido!");
            break;
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
