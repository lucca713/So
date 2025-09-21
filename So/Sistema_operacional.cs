using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace So
{
    public class Sistema_operacional
    {
        public int Limite_de_memoria {  get; set; }
        public int NumeroProcessos { get; set; }

        public List<Processo> FilaProcessos = new List<Processo>();
        public int escalonador { get; set; }

        public int cont = 0;
        public Sistema_operacional()
        {
            
        }

        //depois ver o que ela vai retonar
        public void criarProcesso(int id, string nome, int prioridade) {
            Processo NovoProcesso = new Processo(id,nome, prioridade);
            FilaProcessos.Add(NovoProcesso);

            //Ordena a fila de processo -> maior valor de prioridade na frente, dps isso muda com o escalonados
            FilaProcessos = FilaProcessos.OrderByDescending(processo => processo.Prioridade).ToList();          
        }

        public void listarProcesso() 
        {
            for (int i = 0; i < FilaProcessos.Count; i++)
            {
                Console.WriteLine("##############################################\n");

                //Console.WriteLine($"IDICE DO PROCESSO NA LISTA: [{i}]");

                Console.WriteLine($" IDICE DO PROCESSO NA LISTA: [{i}]: {FilaProcessos[i].ToString()}");
                Console.WriteLine("\n");
                Console.WriteLine("##############################################\n");
            }
        }

        public int SolicitarCriacaoThread(int indice, int qtd_memoria, string nome_thread){
                  
                var processo = FilaProcessos[indice];

                int Total_memoria = processo.CriarThread(cont, qtd_memoria, nome_thread, processo.Nome);
                cont++;
                return Total_memoria;         
        }

        //ver de novo essa lista, pois devia ser uma lista de processo, ele vai retornar o processor(arrumar o tipo dela)
    
        public void FinalizarProcesso(int indice)
        {
            var processo = FilaProcessos[indice];
            processo.limparListaThread();
            FilaProcessos.Remove(processo);
         
            Console.WriteLine("LISTA DE PROCESSOS ATUALIZADA");
            listarProcesso();
        }

        public void RemoverThread(int indice)
        {
            var processo = FilaProcessos[indice];
            processo.FinalizaThread();
        }

        public void Executaprocesso(int indice) {
            if (indice == 0)
            {
                var processo = FilaProcessos[indice];
                processo.EstadoProcesso = Processo.Estados.Executando;
            }
            else { 
                //fazer Swap para smular escalonador -> pausar o processo que esta na pocisao 0 do momento
                var aux = FilaProcessos[0];
                var processo = FilaProcessos[indice];
                FilaProcessos[0] = processo;
                FilaProcessos[indice] = aux;

                if (aux.EstadoProcesso == Processo.Estados.Executando)
                {
                    pausaProcesso(aux);
                }
               
                processo.EstadoProcesso = Processo.Estados.Executando;     
            
            }
        }

        public void pausaProcesso(Processo p) {
            p.EstadoProcesso = Processo.Estados.Pausado;
        }


    }
}
