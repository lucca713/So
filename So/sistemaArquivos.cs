using System;
using System.Collections.Generic;
using System.Linq;

namespace So
{
    
    public abstract class FCB
    {
        public string Nome { get; set; }
        public int Tamanho { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Permissoes { get; set; } 

        public FCB(string nome)
        {
            Nome = nome;
            DataCriacao = DateTime.Now;
            Permissoes = "RW"; 
            Tamanho = 0;
        }
    }

  
    public class Arquivo : FCB
    {
        public string Conteudo { get; set; }

        public Arquivo(string nome, string conteudo) : base(nome)
        {
            Conteudo = conteudo;
          
            Tamanho = conteudo.Length;
        }

        public override string ToString()
        {
            return $"[ARQ] {Nome} | {Tamanho}B | {DataCriacao}";
        }
    }

    
    public class Diretorio : FCB
    {
        public List<FCB> Filhos { get; set; } 

        public Diretorio(string nome) : base(nome)
        {
            Filhos = new List<FCB>();
            Tamanho = 0; 
        }

        public override string ToString()
        {
            return $" {Nome}/ | Itens: {Filhos.Count} | {DataCriacao}";
        }
    }

   

    public class SistemaArquivos
    {
        public Diretorio Raiz { get; private set; }
        public Diretorio DiretorioAtual { get; private set; }
        public List<Arquivo> TabelaGlobalArquivosAbertos { get; private set; }

        public SistemaArquivos()
        {
            Raiz = new Diretorio("root");
            DiretorioAtual = Raiz;
            TabelaGlobalArquivosAbertos = new List<Arquivo>();
        }

   

        public void CriarDiretorio(string nome)
        {
           
            if (DiretorioAtual.Filhos.Any(x => x.Nome == nome))
            {
                Console.WriteLine($"Já existe algo com o nome '{nome}' aqui.");
                return;
            }
            Diretorio novoDir = new Diretorio(nome);
            DiretorioAtual.Filhos.Add(novoDir);
            Console.WriteLine($"Diretório '{nome}' criado em '{DiretorioAtual.Nome}/'.");
        }

        public void CriarArquivo(string nome, string conteudo)
        {
            if (DiretorioAtual.Filhos.Any(x => x.Nome == nome))
            {
                Console.WriteLine($"Já existe algo com o nome '{nome}' aqui.");
                return;
            }
            Arquivo novoArq = new Arquivo(nome, conteudo);
            DiretorioAtual.Filhos.Add(novoArq);
            Console.WriteLine($"Arquivo '{nome}' criado com sucesso.");
        }

        public void ListarConteudo()
        {
            Console.WriteLine($"\n--- Conteúdo de '/{DiretorioAtual.Nome}' ---");
            if (DiretorioAtual.Filhos.Count == 0)
            {
                Console.WriteLine("(Vazio)");
            }
            else
            {
                foreach (var item in DiretorioAtual.Filhos)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.WriteLine("-----------------------------");
        }

        public void MudarDiretorio(string nomeDestino)
        {
            
            if (nomeDestino == "..")
            {
        
                DiretorioAtual = Raiz;
                Console.WriteLine("[FS] Voltando para a Raiz.");
                return;
            }

           
            var destino = DiretorioAtual.Filhos.OfType<Diretorio>().FirstOrDefault(d => d.Nome == nomeDestino);

            if (destino != null)
            {
                DiretorioAtual = destino;
                Console.WriteLine($"Entrou em '{DiretorioAtual.Nome}/'.");
            }
            else
            {
                Console.WriteLine($"Diretório '{nomeDestino}' não encontrado.");
            }
        }

        public void Deletar(string nome)
        {
            var alvo = DiretorioAtual.Filhos.FirstOrDefault(f => f.Nome == nome);
            if (alvo != null)
            {
                DiretorioAtual.Filhos.Remove(alvo);
                Console.WriteLine($"'{nome}' foi deletado.");
            }
            else
            {
                Console.WriteLine(" Arquivo ou diretório não encontrado.");
            }
        }
    }
}