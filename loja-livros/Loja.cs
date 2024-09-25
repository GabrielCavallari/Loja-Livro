using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loja_livros
{
    public class Loja
    {
        public string Nome { get; set; }
        private List<Livro> LivrosDisponiveis { get; set; } = new List<Livro>(); // private nas listas
        private List<Cliente> Clientes { get; set; } = new List<Cliente>(); // evitando que possam ser alteradas diretamente de fora da classe

        public Loja(string nome)
        {
            Nome = nome;   
        }

        public IReadOnlyList<Livro> ObterLivrosDisponiveis()
        {
            return LivrosDisponiveis.AsReadOnly(); // Retorna uma versão de somente leitura da lista
        }
        public IReadOnlyList<Cliente> ObterCliente()
        {
            return Clientes.AsReadOnly(); // Retorna uma versão de somente leitura da lista
        }
        public void AdicionarLivro(Livro livro)
        {
            LivrosDisponiveis.Add(livro);
        }

        public void RealizarVenda(Livro livro, Cliente cliente, int quantidade)
        {
            if (LivrosDisponiveis.Contains(livro) && livro.QuantidadeEstoque >= quantidade)  // Verifica se o livro está disponível e Verfica se tem no estoque
            {
                livro.VenderLivro(quantidade);
                for (int i = 0; i < quantidade; i++)
                {
                cliente.AdicionarLivro(livro); // Adiciona o livro a cada quantidade comprada
                }
                Console.WriteLine($"{quantidade} livro(s) vendido(s) com sucesso!");

                if (!Clientes.Contains(cliente))   // Adiciona o cliente a loja, se ele ainda não foi registrado.
                {
                    Clientes.Add(cliente);
                }
            }
            else
            {
                throw new InvalidOperationException("Estoque insuficiente ou livro não encontrado");
            }
        }

        public string ListarLivrosDisponiveis()
        {
            string lista = "Livros disponíveis na loja:\n";
            foreach (Livro livro in LivrosDisponiveis)
            {
                lista += $"- {livro.Titulo} - {livro.Autor} - R$ {livro.Preco:N2} (Estoque: {livro.QuantidadeEstoque})\n";
            }
            return lista;
        }


        public string ListarComprasClientes()
        {
            string compras = "Compras dos clientes:\n";
            foreach (Cliente cliente in Clientes) 
            {
                compras += $"{cliente.Nome}: R$ {cliente.ObterValorTotalGasto():N2}\n";
            }
            return compras;
        }
    }
}
