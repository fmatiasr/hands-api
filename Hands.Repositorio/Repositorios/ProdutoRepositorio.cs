using Dapper;
using Hands.Dominio.Entidade;
using Hands.Dominio.Repositorios;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Hands.Repositorio.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepository
    {
        protected string strConexao;

        public ProdutoRepositorio()
        {
            strConexao = ConfigurationManager.ConnectionStrings["conexaoHands"].ConnectionString;
        }

        public void Adicionar(Produto obj)
        {
            using (var db = new SqlConnection(strConexao))
            {
                db.Execute(@"INSERT INTO
                            Produto(Nome, Url, Ativo) 
                            VALUES (@Nome, @Url, @Ativo)", obj);
            }
        }

        public void Alterar(Produto obj)
        {
            using (var sqlConnection = new SqlConnection(strConexao))
            {
                sqlConnection.Execute(@"UPDATE Produto
                                       SET Nome = @Nome, 
                                           Url = @Url,
                                           Ativo = @Ativo
                                       WHERE Id = @Id", obj);
            }
        }

        public IEnumerable<Produto> Listar()
        {
            using (var db = new SqlConnection(strConexao))
            {
                return db.Query<Produto>("Select Id, Nome, Url, Ativo from Produto");
            }
        }

        public Produto ObterId(int id)
        {
            using (var db = new SqlConnection(strConexao))
            {
                return db.Query<Produto>(@"SELECT Id, Nome, Url, Ativo 
                                            FROM Produto 
                                        WHERE Id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remover(int id)
        {
            using (var sqlConnection = new SqlConnection(strConexao))
            {
                sqlConnection.Execute(@"UPDATE Produto
                                         SET Ativo = 0
                                       WHERE Id = @Id", new { Id = id });
            }
        }
    }
}
