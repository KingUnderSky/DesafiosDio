using System;

namespace Dio.Series
{
    class Program
    {
        //  Repositório
        static SerieRepositorio repositorio = new();

        // Main
        static void Main(string[] args)
        {
            //  Variáveis
            string opcaoUsuario = "";           

            do
            {
                //  Entrada de dados
                opcaoUsuario = ObterOpcaoUsuario();

                // Processamento
                switch(opcaoUsuario)
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
                case "X":
                    Console.WriteLine("Obrigado por usar nossos serviços");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();            
                }

            } while (opcaoUsuario.ToUpper() != "X");
        }

        //  Métodos
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Especial Room Séries a seu dispor");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine
            (
                "1 - Listar Séries" + Environment.NewLine +
                "2 - Inserir nova série" + Environment.NewLine + 
                "3 - Atualizar série" + Environment.NewLine + 
                "4 - Excluir série" + Environment.NewLine + 
                "5 - Visualizar série" + Environment.NewLine + 
                "C - Limpar Tela" + Environment.NewLine + 
                "X - Sair"
            );

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            lista.ForEach(serie => 
            {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido? "-Excluído-" : ""));
            });
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = Int32.Parse(Console.ReadLine());
            
            Console.Write("Digite o título da série: ");
            string? entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite o ano de início da série: ");
            int entradaAno = Int32.Parse(Console.ReadLine());
            
            Console.Write("Digite a descrição da série: ");
            string? entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(repositorio.ProximoId(), entradaTitulo, entradaDescricao, (Genero)entradaGenero, entradaAno); 
            repositorio.Insere(novaSerie);
        }
        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série:");
            int indiceSerie = Int32.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = Int32.Parse(Console.ReadLine());
            
            Console.Write("Digite o título da série: ");
            string? entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite o ano de início da série: ");
            int entradaAno = Int32.Parse(Console.ReadLine());
            
            Console.Write("Digite a descrição da série: ");
            string? entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(repositorio.ProximoId(), entradaTitulo, entradaDescricao, (Genero)entradaGenero, entradaAno);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série");
            int indiceSerie = Int32.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }
        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = Int32.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
    }

}
