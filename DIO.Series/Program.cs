using System;
using DIO.Series.Classes;

namespace DIO.Series
{
    class Program
    {
        static SerieRepo repo = new SerieRepo();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcao();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1": Listar(); break;
                    case "2": Inserir(); break;
                    case "3": Atualizar(); break;
                    case "4": Excluir(); break;
                    case "5": Vizualizar(); break;
                    case "C": Console.Clear(); break;
                    default: throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcao();
            }
            Console.WriteLine("ok");
            Console.ReadLine();
        }

        private static void Vizualizar()
        {
            Console.WriteLine("id da serie pra ver");
            int id = int.Parse(Console.ReadLine());
            var serie = repo.retornaPorID(id);
            Console.WriteLine(serie.ToString());
        }
        private static void Excluir()
        {
            Console.WriteLine("id a excluir");
            int id = int.Parse(Console.ReadLine());
            repo.Exclui(id);
        }
        private static void Atualizar()
        {
            Console.WriteLine("Atualizar id da serie");
            int idserie = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Escolha o Genero");
            int genero = int.Parse(Console.ReadLine());

            Console.WriteLine("Escolha o Titulo");
            string titulo = Console.ReadLine();

            Console.WriteLine("Escolha o Ano");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Escolha a Descricao");
            string desc = Console.ReadLine();

            Serie editSerie = new Serie(idserie, (Genero)genero, titulo, desc, ano);
            repo.Atualiza(idserie, editSerie);
        }

        private static void Inserir()
        {
            Console.WriteLine("Inserir");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Escolha o Genero");
            int genero = int.Parse(Console.ReadLine());

            Console.WriteLine("Escolha o Titulo");
            string titulo = Console.ReadLine();

            Console.WriteLine("Escolha o Ano");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Escolha a Descricao");
            string desc = Console.ReadLine();

            Serie newSerie = new Serie(repo.ProximoId(), (Genero)genero, titulo, desc, ano);
            repo.Insere(newSerie);
        }
        private static void Listar()
        {
            Console.Write("Listar" + Environment.NewLine);
            var lista = repo.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Sem series");
                return;
            }

            foreach (var item in lista)
            {
                Console.Write(Environment.NewLine + "#ID {0}: {1} - {2}", item.retornaIdo(), item.retornaTitulo(), item.retornaExc());
            }
        }
        private static string ObterOpcao()
        {
            Console.WriteLine();
            Console.WriteLine("Series a seu dispor");
            Console.WriteLine("Utilize a opcao: ");

            Console.WriteLine("1 - Listar");
            Console.WriteLine("2 - Inserir");
            Console.WriteLine("3 - Atualizar");
            Console.WriteLine("4 - Excluir");
            Console.WriteLine("5 - Visualizar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string op = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return op;
        }
    }
}
