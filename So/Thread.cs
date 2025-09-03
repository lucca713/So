using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace So
{
    internal class Thread
    {
        public enum Estado
        {
            Inicializado,
            Finalizado,
            Executando,
        };

        public int Id;

        //Quanto gasta de memoria
        public int Memoria;

        //nao sei como colocar processo pai (colocar um nome por exemplo guia1 google)
        public string ProcessoPai;

        //tipo Estado
        public Estado EstadoThread;
   
        //Construtor da Thread
        public Thread(int id, int memoria, string processoPai)
        {

            Id = id;
            Memoria = memoria;
            ProcessoPai = processoPai;
            this.EstadoThread = Estado.Inicializado;
        }

   
        public void executa(){ 
            //receber todos os outros processos  
        }
    

        //Retorno padrao -> fazer meus testes
        public override string ToString()
        {
            return $"Thread ID: {Id}, Nome: {ProcessoPai}, Memoria que ela gasta: {Memoria}, Estado: {Estado.Inicializado}";
        }
    }
}
