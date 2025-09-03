using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace So
{
    internal class Thread
    {
        public int Id;

        //Quanto gasta de memoria
        public int Memoria;

        //nao sei como colocar processo pai (colocar um nome por exemplo guia1 google)
        public string ProcessoPai;

        public bool Estado;

    
        public void executa(){ 
            //receber todos os outros processos  
        }

        //Retorno padrao -> fazer meus testes
        public override string ToString()
        {
            return $"Thread ID: {Id}, Nome: {ProcessoPai}, Memoria que ela gasta: {Memoria}, Estado: {Estado}";
        }
    }
}
