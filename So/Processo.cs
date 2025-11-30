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

  
        public List<Thread> ListaThreads = new List<Thread>();

       
        public List<Arquivo> ArquivosAbertos { get; private set; } = new List<Arquivo>();

      
        public List<int> TabelaDePaginas = new List<int>();

        public Processo(int id, string nome, int prioridade)
        {
            Id = id;
            Nome = nome;
            Prioridade = prioridade;
            this.EstadoProcesso = Estados.Novo;
        }

        public int CriarThread(int id, int memoria, string nome_thread, string Nome_processo_pai)
        {
            int soma_prioridade = this.ListaThreads.Count;
            Thread Novathread = new Thread(id, nome_thread, memoria, Nome_processo_pai, soma_prioridade);
            this.TotalMemoria += Novathread.Memoria;
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
            else
            {
                Console.WriteLine("Lista vazia");
            }
        }

        public void LimparListaDeThreads()
        {
            this.ListaThreads.Clear();
        }

        public void FinalizaThread()
        {
            Console.WriteLine($"ESTOU NO PROCESSO: {this.Nome}");
            Console.WriteLine("Qual thread você quer finalizar? \n");
            ListarThreads();

            int Id_thread_removida = int.Parse(Console.ReadLine());
            ListaThreads.RemoveAll(t => t.Id == Id_thread_removida);

            Console.WriteLine("LISTA DE THREADS ATUALIZADA\n");
            ListarThreads();
        }

        public void IniciaThread()
        {
            if (ListaThreads.Count > 0)
            {
                ListaThreads[0].EstadoThread = Thread.Estado.Inicializado;
                ListarThreads();
            }
        }

        public override string ToString()
        {
            return $"| Processo: {Id} | - | nome: {Nome} | - | Prioridade: {Prioridade} | - | Estado: {EstadoProcesso} |";
        }
    }
}