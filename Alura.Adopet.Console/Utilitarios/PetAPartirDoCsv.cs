using Alura.Adopet.Console.Modelo;

namespace Alura.Adopet.Console.Utilitarios;

public static class PetAPartirDoCsv
{
    public static Pet ConverteDoTexto(this string linha)
    {
        string[] propriedades = linha.Split(';');
        return new Pet(
            Guid.Parse(propriedades[0]),
            propriedades[1],
            TipoPet.Cachorro
        );
    } 
}