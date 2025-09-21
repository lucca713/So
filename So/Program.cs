using System;
using So;

namespace So
{
    internal class Program
    {
        const int LIMITE_MEMORIA_GLOBAL = 1000;
        static void Main(string[] args)
        {
            Sistema_operacional so = new Sistema_operacional();
            bool executando = true;

            Console.WriteLine("--- BEM-VINDO AO SIMULADOR DE SISTEMA OPERACIONAL ---");
            Console.WriteLine($"AVISO: O limite de memória para qualquer processo é de {LIMITE_MEMORIA_GLOBAL}MB.");

            while (executando)
            {
                Console.WriteLine("\n================== MENU PRINCIPAL ==================");
                Console.WriteLine("1. Criar Novo Processo");
                Console.WriteLine("2. Listar Processos Ativos");
                Console.WriteLine("3. Criar Thread para um Processo");
                Console.WriteLine("4. Executar/Trocar Processo (Simular Escalonador)");
                Console.WriteLine("5. Finalizar uma Thread específica");
                Console.WriteLine("6. Finalizar um Processo inteiro");
                Console.WriteLine("7. Listar Threads de um Processo");
                Console.WriteLine("0. Sair da Simulação");
                Console.Write("Escolha uma opção: ");

                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        Console.Write("Digite o ID do processo: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Digite o Nome do processo: ");
                        string nome = Console.ReadLine();
                        Console.Write("Digite a Prioridade do processo: ");
                        int prioridade = int.Parse(Console.ReadLine());
                        so.criarProcesso(id, nome, prioridade);
                        break;

                    case "2":
                        so.listarProcesso();
                        break;

                    case "3":
                        Console.WriteLine("\n--- Criar Thread ---");
                        so.listarProcesso();
                        Console.Write("Digite o ÍNDICE do processo que receberá a nova thread: ");
                        int indiceProcesso = int.Parse(Console.ReadLine());

                        Console.Write("Digite o Nome da nova thread: ");
                        string nomeThread = Console.ReadLine();
                        Console.Write("Digite a Memória que a thread consumirá (MB): ");
                        int memoriaThread = int.Parse(Console.ReadLine());

                        try
                        {
                            int memoriaTotal = so.SolicitarCriacaoThread(indiceProcesso, memoriaThread, nomeThread);

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"[INFO] Memória do processo agora é: {memoriaTotal}MB de {LIMITE_MEMORIA_GLOBAL}MB.");
                            Console.ResetColor();

                            if (memoriaTotal > LIMITE_MEMORIA_GLOBAL)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                                Console.WriteLine($"!!! ESTOURO DE MEMÓRIA! Processo consumiu {memoriaTotal}MB.");
                                Console.WriteLine("!!! ENCERRANDO A SIMULAÇÃO CONFORME AS REGRAS.");
                                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                                executando = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"[ERRO] Não foi possível criar a thread. O índice pode ser inválido. ({ex.Message})");
                            Console.ResetColor();
                        }
                        break;

                    case "4":
                        Console.WriteLine("\n--- Escalonar Processo ---");
                        so.listarProcesso();
                        Console.Write("Digite o ÍNDICE do processo que deve ser executado: ");
                        int indiceExec = int.Parse(Console.ReadLine());
                        so.Executaprocesso(indiceExec);
                        break;

                    case "5":
                        try
                        {
                            Console.WriteLine("\n--- Finalizar Thread ---");
                            so.listarProcesso();
                            Console.Write("Digite o ÍNDICE do processo pai da thread: ");
                            int indicePai = int.Parse(Console.ReadLine());
                            so.RemoverThread(indicePai);
                        }
                        catch (InvalidOperationException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n[ERRO FATAL DETECTADO] Ocorreu um erro ao tentar remover a thread.");
                            Console.WriteLine("MOTIVO: O código está tentando remover um item de uma lista dentro de um loop 'foreach'.");
                            Console.WriteLine("Use o método 'RemoveAll' para corrigir este problema.");
                            Console.ResetColor();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"[ERRO] Operação falhou. O índice pode ser inválido. ({ex.Message})");
                            Console.ResetColor();
                        }
                        break;

                    case "6":
                        try
                        {
                            Console.WriteLine("\n--- Finalizar Processo ---");
                            so.listarProcesso();
                            Console.Write("Digite o ÍNDICE do processo a ser finalizado: ");
                            int indiceFinalizar = int.Parse(Console.ReadLine());
                            so.FinalizarProcesso(indiceFinalizar);
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"[ERRO] Não foi possível finalizar o processo. O índice pode ser inválido. ({ex.Message})");
                            Console.ResetColor();
                        }
                        break;

                    case "7":
                        try
                        {
                            Console.WriteLine("\n--- Listar Threads de um Processo ---");
                            so.listarProcesso();
                            Console.Write("Digite o ÍNDICE do processo para ver suas threads: ");
                            int indiceListar = int.Parse(Console.ReadLine());
                            so.FilaProcessos[indiceListar].ListarThreads();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"[ERRO] Não foi possível listar as threads. O índice pode ser inválido. ({ex.Message})");
                            Console.ResetColor();
                        }
                        break;

                    case "0":
                        executando = false;
                        Console.WriteLine("Encerrando simulador...");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Opção inválida, por favor, tente novamente.");
                        Console.ResetColor();
                        break;
                }
            }

            Console.WriteLine("Simulação finalizada. Pressione qualquer tecla para sair.");
            Console.ReadKey();
        }
    }
}
