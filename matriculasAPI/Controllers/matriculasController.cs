using buscarTodasMatriculas;
using cadastrarMatriculas;
using Infraestrutura;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace matriculasAPI.Controllers
{
    public class MatriculasController : ApiController
    {
        Dependencias _dependencias = new Dependencias();

        // GET api/values
        public List<Aluno> Get()
        {
            return _dependencias.matriculas.carregarAlunos();
        }

        // GET api/values/5
        public Aluno Get(string id)
        {
            return _dependencias.matriculas.carregarAlunoEspecifico(id);

        }

        // POST api/values
        public string Post([FromBody]Aluno value)
        {
            return _dependencias.cadastros.cadastrarAluno(value);
        }

        // PUT api/values/5
        public Aluno Put(string id, [FromBody]Aluno value)
        {
            return _dependencias.modificarMatricula.modificarAluno(value, id);
        }

        // DELETE api/values/5
        public string Delete(string id)
        {
            return _dependencias.matriculasApagar.apagarAlunoEspecifico(id);
        }
    }
}
