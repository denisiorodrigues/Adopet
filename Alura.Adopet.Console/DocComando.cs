namespace Alura.Adopet.Console;

[AttributeUsage(AttributeTargets.Class)]
public class DocComando : Attribute
{
    public DocComando(string comando, string instrucao)
    {
        Comando = comando;
        Instrucao = instrucao;
    }

    public string Comando { get; }

    public string Instrucao { get; }
}