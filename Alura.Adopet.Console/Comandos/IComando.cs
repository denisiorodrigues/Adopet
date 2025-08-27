namespace Alura.Adopet.Console.Comandos;

public interface IComando
{
    Task ExecutarAsync(string[] args);
}