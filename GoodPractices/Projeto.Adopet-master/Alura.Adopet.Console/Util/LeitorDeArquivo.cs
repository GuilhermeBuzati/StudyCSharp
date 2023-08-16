

using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util
{
    internal class LeitorDeArquivo
    {

        public List<Pet> RealizaLeitura(string caminhoDoArquivoASerLido)
        {
            List<Pet> listaDePets = new List<Pet>();
            using (StreamReader sr = new StreamReader(caminhoDoArquivoASerLido))
            {
                System.Console.WriteLine("----- Dados a serem importados -----");
                while (!sr.EndOfStream)
                {
                    
                }
            }

            return listaDePets;
        }
    }
}
