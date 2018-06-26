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
        public string strConexao = ConfigurationManager.ConnectionStrings["conexaoHands"].ConnectionString;
        
        public void Adicionar(Produto obj)
        {
            using (var db = new SqlConnection(strConexao))
            {
                db.Execute(@"INSERT INTO
                            [Hands].[dbo].[Produto](Nome, Imagem, Ativo) 
                            VALUES (@Nome, @Imagem, 1)", obj);
            }
        }

        public void Alterar(Produto obj)
        {
            using (var sqlConnection = new SqlConnection(strConexao))
            {
                sqlConnection.Execute(@"UPDATE [Hands].[dbo].[Produto]
                                       SET Nome = @Nome, 
                                           Imagem = @Imagem,
                                           Ativo = @Ativo
                                       WHERE Id = @Id", obj);
            }
        }

        public IEnumerable<Produto> Listar()
        {
            using (var db = new SqlConnection(strConexao))
            {
                return db.Query<Produto>("Select Id, Nome, Imagem, Ativo from [Hands].[dbo].[Produto] WHERE Ativo = 1");
            }
        }

        public Produto ObterId(int id)
        {
            using (var db = new SqlConnection(strConexao))
            {
                return db.Query<Produto>(@"SELECT Id, Nome, Imagem, Ativo 
                                            FROM [Hands].[dbo].[Produto] 
                                        WHERE Id = @Id AND Ativo = 1", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remover(int id)
        {
            using (var sqlConnection = new SqlConnection(strConexao))
            {
                sqlConnection.Execute(@"UPDATE [Hands].[dbo].[Produto]
                                         SET Ativo = 0
                                       WHERE Id = @Id", new { Id = id });
            }
        }
    }
}
