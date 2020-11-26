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

namespace modificarMatriculas
{
    public class ModificarMatriculas
    {
        private ConnectionString connectionString = new ConnectionString();

        public Aluno modificarAluno(Aluno aluno, string id)
        {
            using (IDbConnection cnn = new SQLiteConnection(connectionString.carregarConnectionString(), true))
            {
                cnn.Execute("UPDATE Alunos " +
                    "SET escolaAluno = @escolaAluno," +
                    "nomeAluno = @nomeAluno," +
                    "dataNascimentoAluno = @dataNascimentoAluno," +
                    "sexo = @sexo," +
                    "maeAluno = @maeAluno," +
                    "cepAluno = @cepAluno" +
                    " WHERE matriculaAluno='" + id + "'", aluno);
            }

            return aluno;
        }
    }
}
