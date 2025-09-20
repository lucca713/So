namespace So
{
    public class Thread
    {
        //Lista dos estados que a thread tem
        public enum Estado
        {
            Novo,
            Inicializado,
            Finalizado,
            Executando,
        };
        public string Nome;

        public int Id;

        int Prioridade;
        //Quanto gasta de memoria
        public int Memoria;

        //nao sei como colocar processo pai (colocar um nome por exemplo guia1 google)
        public string ProcessoPai;

        //tipo Estado
        public Estado EstadoThread;
   
        //Construtor da Thread
        public Thread(int id,string nome ,int memoria, string processoPai, int prioridade)
        {

            Id = id;
            Nome = nome;
            Memoria = memoria;
            ProcessoPai = processoPai;
            Prioridade = prioridade;
            this.EstadoThread = Estado.Novo;
        }
    

        //Retorno padrao -> fazer meus testes
        public override string ToString()
        {
            return $"Thread ID: {Id}\n Prioridade: {Prioridade}\n Nome: {Nome}\n Processo Pai: {ProcessoPai}\n Memoria que ela gasta: {Memoria}\n Estado: {EstadoThread}\n";
        }
    }
}
