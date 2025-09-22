Simulador Didático de Sistema Operacional
1. Visão Geral do Projeto
Este projeto é um simulador de sistema operacional desenvolvido como parte da disciplina de Sistemas Operacionais. O objetivo é modelar, de forma abstrata e didática, os componentes e algoritmos centrais que governam um SO moderno. Utilizando o paradigma de programação orientada a objetos, o simulador implementa conceitos como gerenciamento de processos e threads, escalonamento de CPU e alocação de memória, sem depender de recursos nativos do sistema operacional hospedeiro.

Linguagem: C# (.NET)

2. Arquitetura e Design
O simulador foi projetado seguindo os princípios de alta coesão e baixo acoplamento, com responsabilidades bem definidas para cada classe principal:

Sistema_operacional: Atua como o núcleo (kernel) do simulador. É responsável por gerenciar a lista global de processos, aplicar as políticas gerais do sistema (como limites de memória) e orquestrar as operações principais, como o escalonamento.

Processo: Modela um Processo e seu respectivo Bloco de Controle de Processo (PCB). Cada processo possui seus próprios atributos, como PID, estado, prioridade, e gerencia seus próprios recursos, incluindo uma lista de threads filhas.

Thread: Representa a unidade de execução dentro de um processo. Contém seu próprio Bloco de Controle de Thread (TCB), com atributos como ID, estado, prioridade e uma referência ao processo pai.

O design favorece a composição em vez da herança. Um Sistema_operacional tem uma lista de Processos, e um Processo tem uma lista de Threads, refletindo a relação hierárquica e de posse de recursos em um SO real.

3. Funcionalidades Implementadas (Primeira Entrega)
Nesta fase inicial, a fundação do simulador foi estabelecida, com foco na criação e gerenciamento manual dos componentes principais.

Gerenciamento de Processos:

Criação de processos com ID, nome e prioridade.

Modelagem dos estados do processo (Novo, Executando, Pausado, Finalizado).

Estrutura básica do PCB.

Gerenciamento de Threads:

Criação de threads que pertencem a um processo específico.

Modelagem dos estados da thread, análogos aos do processo.

Atribuição automática de prioridade baseada na prioridade do processo pai.

Simulação de Escalonador:

Uma fila de processos que é mantida ordenada por prioridade.

Implementação de um dispatcher manual, onde o usuário pode selecionar um processo para "executar", simulando a preempção e a troca de contexto ao mover o processo escolhido para a frente da fila.

Gerenciamento Básico de Memória:

Contabilização da memória total consumida por um processo, baseada na soma da memória de suas threads.

Uma regra global no Program que encerra a simulação se um processo ultrapassar um limite de memória pré-definido.

Interface de Usuário:

Menu interativo via console que permite ao usuário testar todas as funcionalidades implementadas de forma controlada.

4. Como Compilar e Executar
Clone o repositório do GitHub.

Abra o projeto em um ambiente de desenvolvimento .NET (como o Visual Studio).

Compile o projeto (Build Solution).

Execute o programa a partir do arquivo Program.cs.

Siga as instruções do menu no console para interagir com o simulador.


Lucca santos Cerasomma - RA: 113653
