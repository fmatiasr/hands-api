using System.Collections.Generic;
using Hands.Dominio.Entidade;
using Hands.Dominio.Repositorios;

namespace Hands.Dominio.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        IProdutoRepository _rep;

        public ProdutoServico(IProdutoRepository rep)
        {
            _rep = rep;
        }

        public void Adicionar(Produto obj)
        {
            _rep.Adicionar(obj);
        }

        public void Alterar(Produto obj)
        {
            _rep.Alterar(obj);
        }

        public IEnumerable<Produto> Listar()
        {
            return _rep.Listar();
        }

        public Produto ObterId(int id)
        {
            return _rep.ObterId(id);
        }

        public void Remover(int id)
        {
            _rep.Remover(id);
        }
    }
}
