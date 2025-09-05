namespace So
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Processo processo = new Processo();

            processo.Nome = "Guia google";

            processo.Id = 1;

            int Memoria = 12;

            processo.CriarThread(processo.Id, Memoria, processo.Nome);
        }
    }
}
