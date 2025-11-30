# 🖥️ Simulador de Sistema Operacional (C#)

Este projeto é um **simulador de Sistema Operacional em C#**, desenvolvido com fins **didáticos**, com o objetivo de demonstrar conceitos fundamentais de Sistemas Operacionais, como:

- Processos
- Threads
- Escalonamento
- Gerenciamento de Memória (Paginação)
- Sistema de Arquivos
- Estados de Processo e Thread

---

## 📚 Funcionalidades

### ✅ Gerenciamento de Processos
- Criar processos com **ID, nome e prioridade**
- Listar processos ativos
- Executar ou trocar processos (simulação de escalonador por prioridade)
- Pausar e finalizar processos
- Finalização automática libera memória e threads

---

### ✅ Gerenciamento de Threads
- Criar múltiplas threads por processo
- Cada thread possui:
  - ID
  - Nome
  - Prioridade
  - Estado (Novo, Inicializado, Executando, Finalizado)
  - Consumo de memória
- Remover threads específicas
- Controlar o consumo total de memória por processo

---

### ✅ Gerenciamento de Memória (Paginação)
- Simulação de memória física
- Memória dividida em **páginas e molduras**
- Controle de alocação e liberação por processo
- Exibição do **Mapa de Memória**
- Detecção de falha por falta de molduras livres

---

### ✅ Sistema de Arquivos Simulado
- Estrutura em árvore (estilo Unix)
- Diretório raiz (`/root`)
- Criar e deletar:
  - Arquivos
  - Diretórios
- Navegação entre diretórios
- Controle de tamanho e data de criação
- Estrutura baseada em **FCB (File Control Block)**

---

## 🧩 Estrutura do Projeto

---

## ⚙️ Parâmetros da Simulação

- **Memória total:** 1000 MB
- **Tamanho da página:** 20 MB
- **Limite máximo por processo:** 1000 MB
- **Alocação de memória:** baseada em paginação

---

## ▶️ Como Executar

1. Abra o projeto no **Visual Studio** ou **VS Code**
2. Compile e execute (`dotnet run`)
3. Utilize o menu para interagir com o simulador


## ▶️ UML

classDiagram
    class Sistema_operacional {
        +List~Processo~ FilaProcessos
        +Gerenciador_memoria GerenciadorMemoria
        +SistemaArquivos SistemaArquivos
        +criarProcesso()
        +listarProcesso()
        +SolicitarCriacaoThread()
        +Executaprocesso()
        +FinalizarProcesso()
        +ExibirMapa()
    }

    class Processo {
        +int Id
        +string Nome
        +Estados EstadoProcesso
        +int Prioridade
        +List~Thread~ ListaThreads
        +List~int~ TabelaDePaginas
        +CriarThread()
        +FinalizaThread()
        +ListarThreads()
    }

    class Thread {
        +int Id
        +string Nome
        +int Memoria
        +Estado EstadoThread
        +string ProcessoPai
    }

    class Gerenciador_memoria {
        +int TamanhoPagina
        +int TotalMemoriaFisica
        +AlocarMemoria()
        +RetirarMemorial()
        +ImprimirMapa()
    }

    class SistemaArquivos {
        +Diretorio Raiz
        +Diretorio DiretorioAtual
        +CriarArquivo()
        +CriarDiretorio()
        +ListarConteudo()
        +MudarDiretorio()
        +Deletar()
    }

    class FCB {
        <<abstract>>
        +string Nome
        +int Tamanho
        +DateTime DataCriacao
        +string Permissoes
    }

    class Arquivo {
        +string Conteudo
    }

    class Diretorio {
        +List~FCB~ Filhos
    }

    Sistema_operacional --> Processo
    Sistema_operacional --> Gerenciador_memoria
    Sistema_operacional --> SistemaArquivos
    Processo --> Thread
    Processo --> Arquivo
    SistemaArquivos --> Diretorio
    FCB <|-- Arquivo
    FCB <|-- Diretorio
#AUTOR: Lucca Santos Cerasomma RA:113653
