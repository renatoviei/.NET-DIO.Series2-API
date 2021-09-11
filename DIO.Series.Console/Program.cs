using System;
using DIO.Series;

namespace DIO.Series.Console
{
    class Program
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
                        System.Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();


                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por usar nossos serviços");
            System.Console.ReadLine();

        }

        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série");
            int indiceSerie = int.Parse(System.Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            System.Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Digite o id da série");
            int indiceSerie = int.Parse(System.Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série");
            int indiceSerie = int.Parse(System.Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            System.Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite o título da série: ");
            string entradaTitulo = System.Console.ReadLine();

            System.Console.Write("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite a descrição da série: ");
            string entradaDescricao = System.Console.ReadLine();

            Serie novaSerie = new Serie(indiceSerie,
                                        (Genero)entradaGenero,
                                        entradaTitulo,
                                        entradaDescricao,
                                        entradaAno);

            repositorio.Atualiza(indiceSerie, novaSerie);
        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite o título da série: ");
            string entradaTitulo = System.Console.ReadLine();

            System.Console.Write("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite a descrição da série: ");
            string entradaDescricao = System.Console.ReadLine();

            Serie novaSerie = new Serie(repositorio.ProximoId(),
                                        (Genero)entradaGenero,
                                        entradaTitulo,
                                        entradaDescricao,
                                        entradaAno);

            repositorio.Insere(novaSerie);

        }

        private static void ListarSeries()
        {
            System.Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                System.Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "|Excluido|" : ""));


            }
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("DIO Series ao seu dispor!!!");
            System.Console.WriteLine("Informe a opção desejada:");

            System.Console.WriteLine("1- Listar series");
            System.Console.WriteLine("2- Inserir nova série");
            System.Console.WriteLine("3- Atualizar série");
            System.Console.WriteLine("4- Excluir série");
            System.Console.WriteLine("5- Visualizar série");
            System.Console.WriteLine("C- Limpar tela");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();

            string opcaoUsuario = System.Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
