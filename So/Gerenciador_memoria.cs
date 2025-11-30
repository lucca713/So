using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace So
{
    public class Gerenciador_memoria
    {
        public int TamanhoPagina { get; set; }

        public int TotalMemoriaFisica { get; set; }

        //Simular a memoria ram
        private int[] MapaMoldura;
        
        public Gerenciador_memoria(int totalMemoria, int tamanhoPgina) { 
        
            this.TamanhoPagina = tamanhoPgina;
            this.TotalMemoriaFisica = totalMemoria;

            int qtdMoldura = totalMemoria / tamanhoPgina;

            MapaMoldura = new int[qtdMoldura];

            //iniciar com -1
            for (int i = 0; i < qtdMoldura; i++) {
                MapaMoldura[i] = -1;         
            }
                    
        }

        public bool AlocarMemoria(int ProcessoId, int memoriaNecessaria, out List<int> moldurasAlocadas) {

            moldurasAlocadas = new List<int>();

            //ver quantas paginas vao precisar 
            int paginasNecessarias = (int)Math.Ceiling((double)memoriaNecessaria / TamanhoPagina);

            //verificar espaco
            int molduraLivres = MapaMoldura.Count(m => m == -1);

            if (molduraLivres < paginasNecessarias) {

                return false;
            }

            //pegar a primeira livre

            for (int i = 0; i < paginasNecessarias; i++) 
            {
                if (paginasNecessarias == 0) break;

                if (MapaMoldura[i] == -1) {
                    MapaMoldura[i] = ProcessoId;
                    moldurasAlocadas.Add(i);
                    paginasNecessarias--;
                }
            
            }

            return true;
        }
        
        public void RetirarMemorial(int ProcessoId)
        {
            for(int i = 0; i<MapaMoldura.Length; i++)
            {
                if(MapaMoldura [i] == ProcessoId)
                {
                    MapaMoldura[i] = -1;
                }
                Console.WriteLine($"MEMORIA: todas as molduras {ProcessoId} foram liberadas");
            }
        }

        public void ImprimirMapa()
        {
            Console.WriteLine("\n--- MAPA DE MOLDURAS (MEMÓRIA FÍSICA) ---");
            Console.WriteLine($"Total: {TotalMemoriaFisica}MB | Página: {TamanhoPagina}MB | Total de Molduras: {MapaMoldura.Length}");

          
            for (int i = 0; i < MapaMoldura.Length; i++)
            {
     
                if (i > 0 && i % 10 == 0) Console.WriteLine();

                if (MapaMoldura[i] == -1)
                {
                  
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[LIVRE] ");
                }
                else
                {
                
                    Console.ForegroundColor = ConsoleColor.Red;
                  
                    Console.Write($"[P:{MapaMoldura[i]:00}] ");
                }
            }
            Console.ResetColor();
            Console.WriteLine("\n------------------------------");


        }


    }
}
