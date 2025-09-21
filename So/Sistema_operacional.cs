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
            //Ordena pelo vetor o processo
            FilaProcessos = FilaProcessos.OrderByDescending(processo => processo.Prioridade).ToList();
            Console.WriteLine("Eba!!!! processo criado com sucesso");
        }

        public void listarProcesso() 
        {
            for (int i = 0; i < FilaProcessos.Count; i++)
            {
                Console.WriteLine("##############################################\n");

                Console.WriteLine($"[{i}]");

                Console.WriteLine(FilaProcessos[i].ToString());

                Console.WriteLine("##############################################\n");
            }
        }

        public int SolicitarCriacaoThread(int indice, int qtd_memoria, string nome_thread){
            /*
            quando o processo recebe uma thread nova ele vai para cima da fila de prioridade pois ele tem uma thread nova e talvez seja executada
             */
            if (indice == 0)
            {
                var processo = FilaProcessos[indice];

                int Total_memoria = processo.CriarThread(cont, qtd_memoria, nome_thread, processo.Nome);
                cont++;

                return Total_memoria;
            }

            else
            {
                //faz swap

                var aux = FilaProcessos[0];
                var processo = FilaProcessos[indice];
                FilaProcessos[0] = processo;
                FilaProcessos[indice] = aux;

                int Total_memoria = processo.CriarThread(cont, qtd_memoria, nome_thread, processo.Nome);
                cont++;

                return Total_memoria;
            }
        }

        //ver de novo essa lista, pois devia ser uma lista de processo, ele vai retornar o processor(arrumar o tipo dela)
        public void proximoProcesso( List<int>processo) { 
            //aqui ele vai pegar esse array com todos os processor e levar para o proximo, vai andar entre os processor, for each talvez?
        } 

        public void FinalizarProcesso()
        {
            //vai receber um retur 0 para para o processo td    
        }

        public void Executaprocesso(int nome, int numero, int id, List<int>processo) { 
            
        }

        public void pausaProcesso() { 
        
        }


    }
}
