using System;

namespace biblioteca
{
    class Program
    {
        public static void Main(string[] args)
        {

            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("Seja Bem-Vindo à Biblioteca");
                Console.WriteLine("Escolha uma das opções: ");
                Console.WriteLine("1. Consultar acervo");
                Console.WriteLine("2. Realizar um cadastro");
                Console.WriteLine("3. Sair");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Lista dos livros");
                        //metodo para retornar os livros
                        break;

                    case "2":

                        bool voltar = false;

                        while (!voltar)
                        {
                            Console.WriteLine("1. Cadastrar novo Livro");
                            Console.WriteLine("2. Cadastrar nova Editora");
                            Console.WriteLine("3. Voltar");

                            string? opcao2 = Console.ReadLine();

                            switch (opcao2)
                            {
                                case "1":

                                    using (var context = new BibliotecaDbContext())
                                    {
                                        CadastrarNovoLivro(context);
                                    }

                                    break;

                                case "2":

                                    using (var context = new BibliotecaDbContext())
                                    {
                                        CadastrarEditora(context);
                                    }
                                    

                                    break;

                                case "3":
                                    voltar = true;
                                    break;

                                default:
                                    Console.WriteLine("Opção inválida");
                                    break;

                            }
                        }

                        break;

                    case "3":
                        sair = true;
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }


            }

        }

        static void CadastrarNovoLivro(BibliotecaDbContext context)
        {
            

            Console.WriteLine("Digite o nome do livro: ");
            string? titulo = Console.ReadLine();

            Console.WriteLine("Digite Categoria: ");
            string? categoria = Console.ReadLine();

            Console.WriteLine("Digite o nome do Autor: ");
            string? nome = Console.ReadLine();

            var editoras = context.Editoras.ToList();

            //Listando as editora
            Console.WriteLine("Escolha a editora: ");
            for (int i = 0; i< editoras.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {editoras[i].NomeEditora}");
            }

            Console.WriteLine("Digite o numero correspondente a editora: ");

            if (int.TryParse(Console.ReadLine(), out int escolhaEditora) && escolhaEditora > 0 && escolhaEditora <= editoras.Count)
            {
            
            Livro novoLivro = new Livro { Titulo = titulo, Categoria = categoria, Autor = nome, Editora = editoras[escolhaEditora - 1] };

            context.Livros.Add(novoLivro);
            context.SaveChanges();

            Console.WriteLine("Livro cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Escolha de editora inválida.");
            }
            
        }

         static void CadastrarEditora(BibliotecaDbContext context)
        {
            Console.WriteLine("Digite o nome da Editora: ");
            string? nome = Console.ReadLine();

            Editora novaEditora = new Editora { NomeEditora = nome};

            context.Editoras.Add(novaEditora);
            context.SaveChanges();

            Console.WriteLine("Editora cadastrada com sucesso!");
        }
    }


}

