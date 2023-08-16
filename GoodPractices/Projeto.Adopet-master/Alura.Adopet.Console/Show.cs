using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    [DocComando(instrucao: "show", documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    internal class Show
    {
        public void ExibeConteudoArquivo(string caminhoDoArquivoASerExibido)        {
          
            LeitorDeArquivo leitor = new LeitorDeArquivo();

            var listaDePets = leitor.RealizaLeitura(caminhoDoArquivoASerExibido);

            foreach(var pet in listaDePets)
            {
                System.Console.WriteLine(pet);
            }
            
        }
    }
}
