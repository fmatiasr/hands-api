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
                            Case(Nome, Url, Ativo) 
                            VALUES (@Nome, @Url, @Ativo)", obj);
            }
        }

        public void Alterar(Case obj)
        {
            using (var sqlConnection = new SqlConnection(strConexao))
            {
                sqlConnection.Execute(@"UPDATE Case
                                       SET Nome = @Nome, 
                                           Url = @Url,
                                           Ativo = @Ativo
                                       WHERE Id = @Id", obj);
            }
        }

        public IEnumerable<Case> Listar()
        {
            using (var db = new SqlConnection(strConexao))
            {
                return db.Query<Case>("Select Id, Nome, Url, Ativo from Case"); 
            }
        }

        public Case ObterId(int id)
        {
            using (var db = new SqlConnection(strConexao))
            {
                return db.Query<Case>(@"SELECT Id, Nome, Url, Ativo 
                                            FROM Case 
                                        WHERE Id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remover(int id)
        {
            using (var sqlConnection = new SqlConnection(strConexao))
            {
                sqlConnection.Execute(@"UPDATE Case
                                         SET Ativo = 0
                                       WHERE Id = @Id", new { Id = id });
            }
        }
    }
}
