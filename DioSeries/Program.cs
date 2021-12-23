using System;
using System.Collections.Generic;

namespace DioSeries
{
    public class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            List<Serie> lista = repositorio.Lista();

            Console.WriteLine();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (Serie serie in lista)
            {
                bool excluido = serie.retornaExcluido();
                Console.WriteLine($"#ID {serie.retornaId()}: {serie.retornaTitulo()}{(excluido ? " *Excluído*" : "")}");
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            Serie novaSerie = DadosSerie(repositorio.ProximoId());

            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar série");

            Console.Write("Digie o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            Serie serieAtualizada = DadosSerie(idSerie);

            repositorio.Atualiza(idSerie, serieAtualizada);
        }

        public static Serie DadosSerie(int entradaid)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Serie serie = new Serie(id: entradaid,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                descricao: entradaDescricao,
                ano: entradaAno);

            return serie;
        }

        public static void ExcluirSerie()
        {
            Console.WriteLine("Excluir série");

            Console.Write("Digie o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(idSerie);
        }

        public static void VisualizarSerie()
        {
            Console.WriteLine("Visualizar série");

            Console.Write("Digie o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine(repositorio.RetornaPorId(idSerie));
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
