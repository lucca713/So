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

        //inicio construtor
        public Processo() { 
            this.NumeroThreads = new List<Thread>();
        }
       

        //pensar qual vai ser o tipo da lista de threds
        public Thread CriarThread(int id, int memoria, string nome) {
            //aqui vai passar a a classe da thread, instanciar aqui
            Thread Novathread = new Thread(id, memoria, nome);
            NumeroThreads.Add(Novathread);
            foreach (Thread t in NumeroThreads) {
                Console.WriteLine(t);  
            }
            return Novathread;
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
