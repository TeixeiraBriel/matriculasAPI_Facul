using Dapper;
using Infraestrutura;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apagarMatricula
{
    public class ApagarMatricula
    {
        private ConnectionString connectionString = new ConnectionString();

        public string apagarAlunoEspecifico(string id)
        {
            using (IDbConnection cnn = new SQLiteConnection(connectionString.carregarConnectionString(), true))
            {
                var saida = cnn.Execute("delete from Alunos where matriculaAluno='" + id + "'", new DynamicParameters());
                if (saida == 0)
                {
                    return "not found";
                }
                else
                {
                    return "success";
                }
            }
        }
    }
}
