using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestrutura;
using Dapper;
using System.Configuration;

namespace buscarTodasMatriculas
{
    public class BuscarTodasMatriculas
    {
        public List<Aluno> carregarAlunos()
        {
            using (IDbConnection cnn = new SQLiteConnection(carregarConnectionString(), true))
            {
                var saida = cnn.Query<Aluno>("select * from Alunos", new DynamicParameters());
                return saida.ToList();
            }
        }

        public Aluno carregarAlunoEspecifico(string id)
        {
            using (IDbConnection cnn = new SQLiteConnection(carregarConnectionString(), true))
            {
                var saida = cnn.Query<Aluno>("select * from Alunos where matriculaAluno='" + id + "'", new DynamicParameters()).FirstOrDefault();
                return saida;
            }
        }

        private static string carregarConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
