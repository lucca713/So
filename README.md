classDiagram
    class Program {
        +Main()
    }

    class Sistema_operacional {
        +int Limite_de_memoria
        +List~Processo~ FilaProcessos
        +Gerenciador_memoria GerenciadorMemoria
        +SistemaArquivos SistemaArquivos
        +criarProcesso()
        +SolicitarCriacaoThread()
        +FinalizarProcesso()
        +Executaprocesso()
    }

    class Processo {
        +int Id
        +string Nome
        +List~Thread~ ListaThreads
        +List~Arquivo~ ArquivosAbertos
        +List~int~ TabelaDePaginas
        +CriarThread()
        +FinalizaThread()
    }

    class Thread {
        +int Id
        +int Prioridade
        +int Memoria
        +Processo ProcessoPai
    }

    class Gerenciador_memoria {
        +int TamanhoPagina
        +int[] MapaMoldura
        +AlocarMemoria()
        +RetirarMemorial()
        +ImprimirMapa()
    }

    class SistemaArquivos {
        +Diretorio Raiz
        +Diretorio DiretorioAtual
        +CriarArquivo()
        +CriarDiretorio()
        +MudarDiretorio()
    }

    class FCB {
        <<Abstract>>
        +string Nome
        +int Tamanho
        +DateTime DataCriacao
    }

    class Arquivo {
        +string Conteudo
    }

    class Diretorio {
        +List~FCB~ Filhos
    }

    %% Relações
    Program ..> Sistema_operacional : Instancia
    Sistema_operacional *-- Gerenciador_memoria : Composição
    Sistema_operacional *-- SistemaArquivos : Composição
    Sistema_operacional "1" o-- "*" Processo : Gerencia
    Processo "1" *-- "*" Thread : Contém
    
    SistemaArquivos "1" *-- "1" Diretorio : Raiz
    
    Diretorio --|> FCB : Herança
    Arquivo --|> FCB : Herança
    Diretorio o-- FCB : Agregação (Composite)
