﻿using Dapper;
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
        public string cadastrarAluno(Aluno aluno)
        {
            using (IDbConnection cnn = new SQLiteConnection(carregarConnectionString(), true))
            {
                var saida = cnn.Query<int>("select Count() from Alunos", new DynamicParameters()).FirstOrDefault();
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
        
        private static string carregarConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}