using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Hands.Dominio.Entidade;
using Hands.Dominio.Repositorios;

namespace Hands.Repositorio.Repositorios
{
    public class CaseRepositorio : ICaseRepository
    {
        public string strConexao = ConfigurationManager.ConnectionStrings["conexaoHands"].ConnectionString;
        
        public void Adicionar(Case obj)
        {
            using (var db = new SqlConnection(strConexao))
            {
                db.Execute(@"INSERT INTO
                            [Hands].[dbo].[Case](Nome, Imagem, Ativo) 
                            VALUES (@Nome, @Imagem, 1)", obj);
            }
        }

        public void Alterar(Case obj)
        {
            using (var sqlConnection = new SqlConnection(strConexao))
            {
                sqlConnection.Execute(@"UPDATE [Hands].[dbo].[Case]
                                       SET Nome = @Nome, 
                                           Imagem = @Imagem,
                                           Ativo = @Ativo
                                       WHERE Id = @Id", obj);
            }
        }

        public IEnumerable<Case> Listar()
        {
            using (var db = new SqlConnection(strConexao))
            {
                return db.Query<Case>("Select Id, Nome, Imagem, Ativo from [Hands].[dbo].[Case] WHERE Ativo = 1"); 
            }
        }

        public Case ObterId(int id)
        {
            using (var db = new SqlConnection(strConexao))
            {
                return db.Query<Case>(@"SELECT Id, Nome, Imagem, Ativo 
                                            FROM [Hands].[dbo].[Case] 
                                        WHERE Id = @Id AND Ativo = 1", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remover(int id)
        {
            using (var sqlConnection = new SqlConnection(strConexao))
            {
                sqlConnection.Execute(@"UPDATE [Hands].[dbo].[Case]
                                         SET Ativo = 0
                                       WHERE Id = @Id", new { Id = id });
            }
        }
    }
}
