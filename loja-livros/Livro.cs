using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loja_livros
{
    public class Livro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public double Preco { get; private set; } // Somente Leitura
        public int QuantidadeEstoque { get; private set; }
        public Livro(string titulo, string autor, string isbn, double preco, int quantidade)
        {

            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            Preco = preco >= 0 ? preco : throw new ArgumentException("Preço deve ser positivo");
            QuantidadeEstoque = quantidade >= 0 ? quantidade : throw new ArgumentException("O estoque deve ser positivo");
            /* O operador ternário permite que você atribua um valor a uma variável com base em uma condição de forma concisa.
             * É como um "if-else" em uma única linha. */
        }

        public void AtualizarPreco(double novoPreco)
        {
            if (novoPreco >= 0)
            {
                Preco = novoPreco;
            }
            else
            {
                throw new ArgumentException("Preço deve ser positivo");
            }
        }

        public void VenderLivro(int quantidade)
        {
            if (quantidade > 0 && quantidade <= QuantidadeEstoque)
            {
                QuantidadeEstoque -= quantidade;
                Console.WriteLine($"{quantidade} livros vendidos com sucesso!");
            }
            else
            {
                Console.WriteLine("Quantidade insuficiente no estoque");
            }
        }

        public void AdicionarLivro(int quantidade)
        {
            if (quantidade > 0)
            {
                QuantidadeEstoque += quantidade;
                Console.WriteLine($"{quantidade} livros adicionados com sucesso!");
            }
            else
            {
                Console.WriteLine("Quantidade insuficiente");
            }
        }

        public void InformacoesLivro()
        {
            Console.WriteLine($"Titulo: {Titulo}, Autor: {Autor}, ISBN: {ISBN}, Preço: R${Preco:N2}");
        }
    }
}
