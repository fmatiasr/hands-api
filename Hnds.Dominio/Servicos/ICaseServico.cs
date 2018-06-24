using Hands.Dominio.Entidade;
using System.Collections.Generic;

namespace Hands.Dominio.Servicos
{
    public interface ICaseServico
    {
        void Adicionar(Case obj);
        void Alterar(Case obj);
        void Remover(int id);
        IEnumerable<Case> Listar();
        Case ObterId(int id);
    }
}
