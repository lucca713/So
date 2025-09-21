using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace So
{
    public class Processo
    {
        public enum Estados
        {
            Novo,
            Executando,
            Finalizado

        }

        public int Id;

        public string Nome;

        public Estados EstadoProcesso;

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
            this.EstadoProcesso = Estados.Novo;
        }
       
        //pensar qual vai ser o tipo da lista de threds
        public int CriarThread(int id, int memoria, string nome_thread, string Nome_processo_pai) {
           
            int soma_prioridade = this.ListaThreads.Count;

            //aqui vai passar a a classe da thread, instanciar aqui  
            Thread Novathread = new Thread(id, nome_thread, memoria, Nome_processo_pai, soma_prioridade);

            //soma memoria
            this.TotalMemoria += Novathread.Memoria;
            //Adiciona na Lista
            ListaThreads.Add(Novathread);
 
            return TotalMemoria;
        }

        public void ListarThreads()
        {

            foreach (Thread t in ListaThreads)
            {
                Console.WriteLine("##############################################\n");

                Console.WriteLine(t.ToString());

                Console.WriteLine("##############################################\n");
            }

        }
        public void FinalizaThread()
        {
            //nome do processo
            Console.WriteLine(this.Nome);
            Console.WriteLine("Qual processo você quer finalizar? \n");

            //listar todas as threads do processo
            foreach (Thread t in ListaThreads)
            {
                Console.WriteLine("##############################################\n");

                Console.WriteLine(t.ToString());

                Console.WriteLine("##############################################\n");
             }

            int Id_thread_removida = int.Parse(Console.ReadLine());
            foreach (Thread t in ListaThreads)
            {
                if (t.Id == Id_thread_removida)
                {
                    ListaThreads.Remove(t);
                }
            }
        }

        public void IniciaThread()
        {
            ListaThreads[0].EstadoThread = Thread.Estado.Inicializado;
            this.EstadoProcesso = Estados.Executando;
            foreach (Thread t in ListaThreads)
            {
                Console.WriteLine("##############################################\n");

                Console.WriteLine(t.ToString());

                Console.WriteLine("##############################################\n");
            }
        }

        public override string ToString()
        {
            return $"Processo: {Id}, nome: {Nome}, Prioridade: {Prioridade}, Estado{EstadoProcesso}";
        }

    }
}
