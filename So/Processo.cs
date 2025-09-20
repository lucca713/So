using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace So
{
    public class Processo
    { 
        public int Id;

        public string Nome;

        public string Estado;

        public int Prioridade;
        int TotalMemoria = 0;
        //relacao composicao Eh um
        public List <Thread> ListaThreads = new List<Thread>();

        //acho que nao vai precisar mais a thread vem com o estaod? 
        

        

        //inicio construtor
        public Processo(int id, string nome, int prioridade) { 
            Id = id;
            Nome = nome;
            Prioridade = prioridade;
        }
       
        //pensar qual vai ser o tipo da lista de threds
        public (Thread,int) CriarThread(int id, int memoria, string nome, string nomePai) {
            
            int soma_prioridade = this.Prioridade + this.ListaThreads.Count;

            //aqui vai passar a a classe da thread, instanciar aqui  
            Thread Novathread = new Thread(id,nome,memoria, nomePai, soma_prioridade);

            //soma memoria
            this.TotalMemoria += Novathread.Memoria;
            //Adiciona na Lista
            ListaThreads.Add(Novathread);
 
            return (Novathread, TotalMemoria);
        }

        public void FinalizaThread()
        {
            Console.WriteLine(this.Nome);
            Console.WriteLine("Qual processo você quer finalizar? \n");

            //listar todas as threads do processo
            foreach (Thread t in ListaThreads)
            {
                Console.WriteLine(t.ToString());     
;            }

            int Id_thread_removida = int.Parse(Console.ReadLine());
            foreach (Thread t in ListaThreads)
            {
                if (t.Id == Id_thread_removida)
                {
                    ListaThreads.Remove(t);
                }
            }
        }

    }
}
