using System;
using System.Reflection;

namespace Alura.Adopet.Console;

[DocComando(instrucao: "help", documentacao: "comando que exibe informações de ajuda.ao ")]
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
        if (parametrosInformados.Length == 1)
        {
            System.Console.WriteLine(
                "adopet help <parametro> ous simplemente adopet help comando que exibe informações de ajuda dos comandos.");
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: ");

            foreach (DocComando comando in docs.Values)
            {
                System.Console.WriteLine(comando.Documentacao);
            }
        }
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
        }
    }
}