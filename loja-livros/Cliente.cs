using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loja_livros
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public List<Livro> LivrosComprados { get; set; } // LivrosComprados armazenará uma lista de objetos do tipo Livro
        public Cliente(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
            LivrosComprados = new List<Livro>(); // Inicializando a lista de livros
        }

        public void AdicionarLivro(Livro livro)
        {
            LivrosComprados.Add(livro);
        }
        public void RemoverLivro(Livro livro)
        {
            LivrosComprados.Remove(livro);
        }

        public double ObterValorTotalGasto()
        {
            double total = 0;
            foreach (Livro livro in LivrosComprados) // O foreach percorre cada livro na lista de livros comprados.
            {
                total += livro.Preco; // A cada iteração, o preço do livro atual é adicionado ao total.
            }
            return total;
        }

    }
}
