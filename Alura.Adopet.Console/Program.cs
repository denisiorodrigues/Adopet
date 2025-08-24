using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console;

Console.ForegroundColor = ConsoleColor.Green;

try
{
    string comando = args[0].Trim(); 
    
    switch (comando)
    {
        case "import":
            var importar = new Importar();
            await importar.ArquivoPetAsync(caminhoDoArquivoParaImportacao: args[1].Trim());
            break;
        case "help":
            var ajuda = new Ajuda();
            ajuda.Executar(args);
;           break;
        case "show":
            string caminhoDoArquivoASerExibido =  args[1];
            var exibir = new Exibir();
            exibir.ItensDoArquivo(caminhoDoArquivoASerExibido);
            break;
        case "list":
            var listar = new Listar();
            await listar.Pets();
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
