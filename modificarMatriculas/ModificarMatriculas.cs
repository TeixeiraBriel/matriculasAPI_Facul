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
        public Aluno modificarAluno(Aluno aluno, string id)
        {
            using (IDbConnection cnn = new SQLiteConnection(carregarConnectionString(), true))
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

        public static string carregarConnectionString(string id = "Default")
        {
            var path = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            var caminho = ConfigurationManager.ConnectionStrings[id].ConnectionString;

            path = path.Replace("file:\\", "");

            caminho = caminho.Replace("|Diretorio|", path);

            return caminho;
        }
    }
}
