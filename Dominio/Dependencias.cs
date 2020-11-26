using apagarMatricula;
using buscarTodasMatriculas;
using cadastrarMatriculas;
using modificarMatriculas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura
{
    public class Dependencias
    {
        public CadastrarMatricula cadastros = new CadastrarMatricula();

        public BuscarTodasMatriculas matriculas = new BuscarTodasMatriculas();

        public ApagarMatricula matriculasApagar = new ApagarMatricula();

        public ModificarMatriculas modificarMatricula = new ModificarMatriculas();

    }
}
