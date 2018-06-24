using Hands.Dominio.Entidade;
using System.Collections.Generic;

namespace Hands.Dominio.Servicos
{
    public interface IProdutoServico
    {
        void Adicionar(Produto obj);
        void Alterar(Produto obj);
        void Remover(int id);
        IEnumerable<Produto> Listar();
        Produto ObterId(int id);
    }
}
