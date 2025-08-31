using Alura.Adopet.Console.Modelo;

namespace Alura.Adopet.Console.Utilitarios;

public static class PetAPartirDoCsv
{
    public static Pet ConverteDoTexto(this string? linha)
    {
        string[]? propriedades = linha?.Split(';') ?? throw new ArgumentException("A linha n�o pode ser nula.");

        if (string.IsNullOrEmpty(linha))
        {
            throw new ArgumentException("A linha n�o pode ser vazia.");
        }

        if (propriedades.Length < 3)
        {
            throw new ArgumentException("A linha n�o cont�m campos suficientes.");
        }

        if (!Guid.TryParse(propriedades[0], out Guid petId))
        {
            throw new ArgumentException("O ID do pet n�o est� em um formato v�lido.");
        }

        var sucesso = int.TryParse(propriedades[2], out int tipoPet);
        if (!sucesso || (tipoPet != 0 && tipoPet != 1))
        {
            throw new ArgumentException("O tipo do pet � inv�lido. Use 0 para Gato e 1 para Cachorro.");
        }

        return new Pet(
            petId,
            propriedades[1],
            tipoPet == 0 ? TipoPet.Gato : TipoPet.Cachorro
        );
    } 
}