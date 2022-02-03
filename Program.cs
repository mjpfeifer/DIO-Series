using System;
using System.Collections.Generic;
using System.Globalization;
using DIO.Series.Classe;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X"){

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
                        throw new ArgumentOutOfRangeException();
                }

                 opcaoUsuario = ObterOpcaoUsuario();

            }
            
        }
    

        private static void ListarSeries()
        {
            System.Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();
            if ( lista.Count == 0 )
            {
                System.Console.WriteLine("Nenhum Série cadastrada !!!");
                return;
            }
            /*for (int i = 0; i < lista.Count; i++)
            {
                System.Console.WriteLine($"#ID {lista[i].Id} - {lista[i].RetornaTitulo()} - {lista[i].retornaExcluido()} ");
            }*/
            foreach (var serie in lista)
            {
                string stringExcluido = "Não";
                bool excluido = serie.retornaExcluido();
                if (excluido)
                {
                    stringExcluido = "Sim";
                }
                System.Console.WriteLine($"#ID {serie.Id} - {serie.RetornaTitulo()} - {stringExcluido} ");
                
            }
        }

        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Visualir Série");
            System.Console.Write("Qual o id da Série:");
            int id = int.Parse( Console.ReadLine() );

            Serie serie = repositorio.RetornaPorId(id);
            System.Console.WriteLine(serie);
        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir Série");

            foreach (int i in Enum.GetValues(typeof (Genero)) )
            {
                System.Console.WriteLine(i + "-" + Enum.GetName(typeof(Genero), i));
            }

            System.Console.Write("Digite o Gênero entre as opções acima:");
            int genero = int.Parse( Console.ReadLine() );
            System.Console.Write("Digite o Título da Série: ");
            string titulo = Console.ReadLine();
            System.Console.Write("Digite o Ano de Início da Série: ");
            int ano = int.Parse( Console.ReadLine() );
            System.Console.Write("Digite a Descrição da Série: ");
            string descricao = Console.ReadLine();

            Serie novaSerie = new Serie( repositorio.ProximoId(), (Genero)genero, titulo, descricao, ano);
            repositorio.Insere(novaSerie);
            
        }

        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Excluir Série");
            System.Console.Write("Qual o id da Série:");
            int id = int.Parse( Console.ReadLine() );

            repositorio.Exclui(id);

        }


        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Atualizar Série");
            System.Console.Write("Qual o id da Série:");
            int id = int.Parse( Console.ReadLine() );                        

            foreach (int i in Enum.GetValues(typeof (Genero)) )
            {
                System.Console.WriteLine(i + "-" + Enum.GetName(typeof(Genero), i));
            }

            System.Console.Write("Digite o Gênero entre as opções acima:");
            int genero = int.Parse( Console.ReadLine() );
            System.Console.Write("Digite o Título da Série: ");
            string titulo = Console.ReadLine();
            System.Console.Write("Digite o Ano de Início da Série: ");
            int ano = int.Parse( Console.ReadLine() );
            System.Console.Write("Digite a Descrição da Série: ");
            string descricao = Console.ReadLine();

            //Serie novaSerie = new repositorio.RetornaPorId(id);
            Serie novaSerie = new Serie( id, (Genero)genero, titulo, descricao, ano);
            repositorio.Atualiza(id, novaSerie);
            
        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Dio Séries a seu dispor !!!!");
            System.Console.WriteLine("Informe a opção deseja:");

            System.Console.WriteLine("1-Listar Séries");
            System.Console.WriteLine("2-Inserir nova Série");
            System.Console.WriteLine("3-Atualizar Série");
            System.Console.WriteLine("4-Excluir Série");
            System.Console.WriteLine("5-Visualizar Série");
            System.Console.WriteLine("C-Limpar Tela");
            System.Console.WriteLine("X-Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    }
}
