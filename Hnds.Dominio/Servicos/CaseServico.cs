using System.Collections.Generic;
using Hands.Dominio.Entidade;
using Hands.Dominio.Repositorios;

namespace Hands.Dominio.Servicos
{
    public class CaseServico : ICaseServico
    {
        protected ICaseRepository _rep;

        public CaseServico(ICaseRepository rep)
        {
            _rep = rep;
        }

        public void Adicionar(Case obj)
        {
            _rep.Adicionar(obj);
        }

        public void Alterar(Case obj)
        {
            _rep.Alterar(obj);
        }

        public IEnumerable<Case> Listar()
        {
            return _rep.Listar();
        }

        public Case ObterId(int id)
        {
            return _rep.ObterId(id);
        }

        public void Remover(int id)
        {
            _rep.Remover(id);
        }
    }
}
