using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace So
{
    internal class Sistema_operacional
    {
        public int Limite_de_memoria {  get; set; }
        public int NumeroProcessos { get; set; }
        public List<int> FilaProcessos { get; set; }
        public int ContadorTempo { get; set; }


        //depois ver o que ela vai retonar
        public void criarProcesso( int procesos) {
            //aqui ele vai somar um processo cont ++
            //e colocar esse processo na lista

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
