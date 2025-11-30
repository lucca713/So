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

        public Gerenciador_memoria GerenciadorMemoria { get; set; }

        public SistemaArquivos SistemaArquivos;
        public Sistema_operacional()
        {
            GerenciadorMemoria = new Gerenciador_memoria(1000, 20);
            SistemaArquivos = new SistemaArquivos();

        }

        public void ExibirMapa()
        {
            GerenciadorMemoria.ImprimirMapa();
        
        }

        //depois ver o que ela vai retonar
        public void criarProcesso(int id, string nome, int prioridade) {
            Processo NovoProcesso = new Processo(id,nome, prioridade);
            FilaProcessos.Add(NovoProcesso);

           
            FilaProcessos = FilaProcessos.OrderByDescending(processo => processo.Prioridade).ToList();          
        }

        public void listarProcesso() 
        {
            for (int i = 0; i < FilaProcessos.Count; i++)
            {
             
                Console.WriteLine($" IDICE DO PROCESSO NA LISTA: [{i}]: {FilaProcessos[i].ToString()}");
                    
            }
        }

        public int SolicitarCriacaoThread(int indice, int qtd_memoria, string nome_thread){
                  
            var processo = FilaProcessos[indice];

            List<int> NovasMolduras;
            bool ConseguiuAlocar = GerenciadorMemoria.AlocarMemoria(processo.Id, qtd_memoria, out NovasMolduras);

            if (!ConseguiuAlocar)
            {
                Console.WriteLine($"Falha na paginação: Não tem molduras livres para alocar");
            }
            
            processo.TabelaDePaginas.AddRange(NovasMolduras);
                int Total_memoria = processo.CriarThread(cont, qtd_memoria, nome_thread, processo.Nome);
                cont++;
               GerenciadorMemoria.ImprimirMapa();
                return Total_memoria;         
        }

        //ver de novo essa lista, pois devia ser uma lista de processo, ele vai retornar o processor(arrumar o tipo dela)
        //limpar o mapa e a lisat de folhas
        public void FinalizarProcesso(int indice)
        {
            var processo = FilaProcessos[indice];
            GerenciadorMemoria.RetirarMemorial(processo.Id);

            processo.TabelaDePaginas.Clear();

            processo.LimparListaDeThreads();
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
