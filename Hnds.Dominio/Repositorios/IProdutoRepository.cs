using Hands.Dominio.Entidade;
using System.Collections.Generic;

namespace Hands.Dominio.Repositorios
{
    public interface IProdutoRepository
    {
        void Adicionar(Produto obj);
        void Alterar(Produto obj);
        void Remover(int id);
        IEnumerable<Produto> Listar();
        Produto ObterId(int id);
    }
}
