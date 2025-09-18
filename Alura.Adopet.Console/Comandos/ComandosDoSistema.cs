using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Utilitarios;

namespace Alura.Adopet.Console.Comandos;

public class ComandosDoSistema
{
    private HttpClientPet httpClientPet;
    private IDictionary<string, IComando> comandos;
    private LeitorDeArquivos leitorDeArquivos;

    public ComandosDoSistema(string[] args)
    {
        httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
        if(args.Length > 1)
        {
            leitorDeArquivos = new LeitorDeArquivos(args[1]);
        }

        comandos = new Dictionary<string, IComando>()
        {
            {"import", new Importar(httpClientPet, leitorDeArquivos)},
            {"help", new Ajuda()},
            {"show", new Exibir()},
            {"list", new Listar(httpClientPet)},
        };
    }
    
    public IComando? this[string comando] => comandos.ContainsKey(comando) ? comandos[comando] : null;
}