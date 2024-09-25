using loja_livros;

namespace loja_livros
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criando uma loja
            Loja livraria = new Loja("Livraria do João");

            // Criando livros e clientes
            Livro livro1 = new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", "0-345-33970-3", 50.0, 10);
            Livro livro2 = new Livro("O Hobbit", "J.R.R. Tolkien", "0-345-33970-2", 30.0, 5);
            Cliente cliente1 = new Cliente("João da Silva", "12345678900");

            // Adicionando livros à loja
            livraria.AdicionarLivro(livro1);
            livraria.AdicionarLivro(livro2);

            Console.WriteLine("Lista de livros disponíveis:");
            Console.WriteLine(livraria.ListarLivrosDisponiveis());

            try
            {
                // Realizando uma venda de 2 exemplares de "O Senhor dos Anéis"
                livraria.RealizarVenda(livro1, cliente1, 2);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro ao realizar venda: {ex.Message}");
            }

            // Exibindo novamente a lista de livros disponíveis após a venda
            Console.WriteLine("\nLista de livros disponíveis após a venda:");
            Console.WriteLine(livraria.ListarLivrosDisponiveis());

            // Exibindo as compras do cliente
            Console.WriteLine("\nCompras dos clientes:");
            Console.WriteLine(livraria.ListarComprasClientes());

            // Tentativa de realizar uma venda com estoque insuficiente
            try
            {
                livraria.RealizarVenda(livro1, cliente1, 9);  // Estoque insuficiente
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro ao realizar venda: {ex.Message}");
            }
        }
    }
}
