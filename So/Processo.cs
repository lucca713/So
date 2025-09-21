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
            Pausado,
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
            if (ListaThreads.Count != 0)
            {
                foreach (Thread t in ListaThreads)
                {
                    Console.WriteLine("-----------------------------------------------\n");

                    Console.WriteLine(t.ToString());

                    Console.WriteLine("-----------------------------------------------\n");
                }
            }
            else {

                Console.WriteLine("Lista vazia");
               
            }
        }

        public void limparListaThread(){
        
             this.ListaThreads.Clear();
        
        }

        public void FinalizaThread()
        {
            //nome do processo
            Console.WriteLine($"ESTOU NO PROCESSO: {this.Nome}");
            Console.WriteLine("Qual processo você quer finalizar? \n");

            //listar todas as threads do processo
            ListarThreads();

            int Id_thread_removida = int.Parse(Console.ReadLine());

            //remover com linq
            ListaThreads.RemoveAll(t => t.Id == Id_thread_removida);

            Console.WriteLine("LISTA DE THREADS ATUALIZADA\n");

            ListarThreads();

        }

        //so para mostrar que da para mudar o status das threads
        public void IniciaThread()
        {
            //deixe fixo aqui para iniciar sempre a thread que esta em primeiro na lista para ficar mais facil por hora 
            ListaThreads[0].EstadoThread = Thread.Estado.Inicializado;
            
            ListarThreads();
           
        }

        public override string ToString()
        {
            return $"| Processo: {Id} | - | nome: {Nome} | - | Prioridade: {Prioridade} | - | Estado: {EstadoProcesso} |";
        }

    }
}
