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

namespace cadastrarMatriculas
{
    public class CadastrarMatricula
    {
        private ConnectionString connectionString = new ConnectionString();

        public string cadastrarAluno(Aluno aluno)
        {
            using (IDbConnection cnn = new SQLiteConnection(connectionString.carregarConnectionString(), true))
            {
                var saida = cnn.Query<int>("select matriculaAluno from Alunos order by matriculaAluno desc  LIMIT 1", new DynamicParameters()).FirstOrDefault();
                aluno.matriculaAluno = (saida + 1).ToString();
                cnn.Execute("insert into Alunos" +
                            "(escolaAluno," +
                            "matriculaAluno," +
                            "nomeAluno," +
                            "dataNascimentoAluno," +
                            "sexo," +
                            "maeAluno," +
                            "cepAluno) values (" +
                            "@escolaAluno," +
                            "@matriculaAluno," +
                            "@nomeAluno," +
                            "@dataNascimentoAluno," +
                            "@sexo," +
                            "@maeAluno," +
                            "@cepAluno" +
                            ")"
                            , aluno);

                return "Gerado com o ID: " + aluno.matriculaAluno;
            }
        }
    }
}
