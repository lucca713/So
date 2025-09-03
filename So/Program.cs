namespace So
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread();

            //aqui a thread vai consumir 2 de memoria
            t1.Memoria = 2;
            t1.ProcessoPai = "gui aberta";
            //t1.Estado = true;


        }
    }
}
