using FluentResults;

namespace Alura.Adopet.Console.Utilitarios
{
    internal class SucessoComDocumentacao : Success
    {
        public IEnumerable<string> Documentacoes { get; }

        public SucessoComDocumentacao(IEnumerable<string> documentacoes)
        {
            Documentacoes = documentacoes;
        }
    }
}
