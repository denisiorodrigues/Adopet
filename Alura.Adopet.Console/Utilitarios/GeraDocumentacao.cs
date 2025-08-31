using System.Reflection;
using Alura.Adopet.Console.Atributos;

namespace Alura.Adopet.Console.Utilitarios;

public class GeraDocumentacao
{
    public static Dictionary<string, DocComando> ObterTodos()
    {
        return Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetCustomAttributes<DocComando>().Any())
            .Select(t => t.GetCustomAttribute<DocComando>()!)
            .ToDictionary(t => t.Instrucao);
    }
}
