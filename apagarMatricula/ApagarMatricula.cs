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
        public string apagarAlunoEspecifico(string id)
        {
            using (IDbConnection cnn = new SQLiteConnection(carregarConnectionString(), true))
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
