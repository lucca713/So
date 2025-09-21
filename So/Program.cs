namespace So
{
    internal class Program
    {
        static void Main(string[] args)
        {
          Sistema_operacional So = new Sistema_operacional();

            So.Limite_de_memoria = 10;

            So.criarProcesso(0,"Google",10);
            So.criarProcesso(0, "Fire Fox ", 1);
            So.criarProcesso(0, "Minecraft", 5);

            So.listarProcesso();

           So.SolicitarCriacaoThread(0, 2, "")



        }
    }
}
