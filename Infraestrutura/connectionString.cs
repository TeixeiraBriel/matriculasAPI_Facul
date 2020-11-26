using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura
{
    public class ConnectionString
    {
        public string carregarConnectionString(string id = "Default")
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
