using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Utilitarios;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "show", documentacao: "adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
public class Exibir : IComando
{
    public Task ExecutarAsync(string[] args)
    {
        this.ItensDoArquivo(caminhoDoArquivoASerExibido: args[1]);
        return Task.CompletedTask;
    }
    
    private void ItensDoArquivo(string caminhoDoArquivoASerExibido)
    {
        using (StreamReader sr = new StreamReader(caminhoDoArquivoASerExibido))
        {
            System.Console.WriteLine("----- Serão importados os dados abaixo -----");
            var leitorDeArquivos =  new LeitorDeArquivos();
            var pets = leitorDeArquivos.RealizarLeitura(caminhoDoArquivoASerExibido);
            foreach (var pet in pets) 
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}