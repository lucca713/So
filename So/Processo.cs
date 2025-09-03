using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace So
{
    internal class Processo
    {
        public string Nome;

        //relacao composicao Eh um
        public List <Thread> NumeroThreads;

        //acho que nao vai precisar mais a thread vem com o estaod? 
        public string Estado;

        public int Id;

        //pensar qual vai ser o tipo da lista de threds
        public void CriarThread(string nome, ) { 
            
            
        }

        public void FinalizaThread()
        {
            //recebner tipo 3 para parar 
        }

        public void pausaThread(int valor) { 
        
            //esse valor para o loop
        }


    }
}
