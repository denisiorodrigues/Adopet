using System;
using System.Reflection;

namespace Alura.Adopet.Console;

[DocComando(instrucao: "help", documentacao: "comando que exibe informações de ajuda.\n" +
                                        "adopet help <parametro> ous simplemente adopet help comando que exibe informações de ajuda dos comandos. ")]
public class Ajuda
{
    private Dictionary<string, DocComando> docs;

    public Ajuda()
    {
        docs = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetCustomAttributes<DocComando>().Any())
            .Select(t => t.GetCustomAttribute<DocComando>()!)
            .ToDictionary(t => t.Instrucao);
    }
    
    public void Executar(string[] parametrosInformados) 
    {
        System.Console.WriteLine("Lista de comandos.");
        // se não passou mais nenhum argumento mostra help de todos os comandos
        if (parametrosInformados.Length == 1)
        {
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: ");
            // System.Console.WriteLine("\t adopet help <parametro> ous simplemente adopet help comando que exibe informações de ajuda dos comandos.");
            // System.Console.WriteLine("\t adopet import <arquivo> comando que realiza a importação do arquivo de pets.");
            // System.Console.WriteLine("\t adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado." + "\n\n");
            // System.Console.WriteLine("Execute 'adopet.exe help [comando]' para obter mais informações sobre um comando." + "\n");

            foreach (var doc in docs.Values)
            {
                System.Console.WriteLine(doc.Documentacao);
            }
        }
        // exibe o help daquele comando específico
        else if (parametrosInformados.Length == 2)
        {
            string comandoASerExibido = parametrosInformados[1];

            if (docs.ContainsKey(comandoASerExibido))
            {
                var comando = docs[comandoASerExibido];
                System.Console.WriteLine(comando.Documentacao);
            }
            else
            {
                System.Console.WriteLine($"adopet comando não encontrado.");
            }
            // if (comandoASerExibido.Equals("import"))
            // {
            //     System.Console.WriteLine(" adopet import <arquivo> " +
            //                             "comando que realiza a importação do arquivo de pets.");
            // }
            // if (comandoASerExibido.Equals("show"))
            // {
            //     System.Console.WriteLine(" adopet show <arquivo>  comando que " +
            //                              "exibe no terminal o conteúdo do arquivo importado.");
            // }
            // if (comandoASerExibido.Equals("list"))
            // {
            //     System.Console.WriteLine($"adopet list comando que exibe no nterminal o conteúdo cadastrado");
            // }
        }
    }
}