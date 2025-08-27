namespace Alura.Adopet.Console.Comandos;

public class ComandosDoSistema
{
    IDictionary<string, IComando> comandos = new Dictionary<string, IComando>()
    {
        {"import", new Importar()},
        {"help", new Ajuda()},
        {"show", new Exibir()},
        {"list", new Listar()},
    };
    
    public IComando? this[string comando] => comandos.ContainsKey(comando) ? comandos[comando] : null;
}