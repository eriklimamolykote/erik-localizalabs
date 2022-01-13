using System;

namespace DIO.Series
{
    class Program{

        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main( String[] args )
        {
            
            // Console.WriteLine( "Hello World!" );
            string opcaoUsuario = ObterOpcaoUsuario();

            while ( opcaoUsuario.ToUpper() != "X" )
            {
                switch ( opcaoUsuario )
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizaSeries();
                        break;
                    case "4":
                        ExcluiSerie();
                        break;
                    case "5":
                        VisualizaSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();                            
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine( "Obrigado! Volte sempre!" );
            Console.ReadLine();
        }

        public static void ListarSeries() 
        {
            Console.Write( "Listar séries" );

            var lista = repositorio.Lista();

            if ( lista.Count == 0 ) 
            {
                Console.WriteLine( "Não há séries cadastradas" );
                return;
            }

            foreach (var serie in lista ) 
            {
                var excluido = serie.retornaExcluido();
                
                Console.WriteLine( "#ID {0}: - {1} - {2}", serie.retornaId, serie.retornaTitulo, ( excluido ? "Excluiído" : "" ) );
            }
        }

        public static void InserirSeries() 
        {
            Console.WriteLine( "Inserir uma nova série" );

            foreach ( int i in Enum.GetValues( typeof( Genero ) ) ) 
            {
                Console.Write( "{0} - {1}", i, Enum.GetName( typeof( Genero ), i ) );
            }

            Console.Write( "Digite o gênero entre as opções acima: " );
            int entradaGenero = int.Parse( Console.ReadLine() );

            Console.Write( "Digite o título da série: " );
            string entradaTitulo = Console.ReadLine();

            Console.Write( "Digite o ano de início da série: " );
            int entradaAno = int.Parse( Console.ReadLine() );

            Console.Write( "Digite a descrição da série: " );
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie( id: repositorio.ProximoId(), 
                                        genero: ( Genero ) entradaGenero, 
                                        titulo: entradaTitulo, 
                                        ano: entradaAno, 
                                        descricao: entradaDescricao );

            repositorio.Insere( novaSerie );                            
        }

        public static void AtualizaSeries() 
        {
            Console.WriteLine( "Atualizar uma série" );

            Console.Write( "Digite o id da série: " );
            int indiceSerie = int.Parse( Console.ReadLine() );

            foreach ( int i in Enum.GetValues( typeof( Genero ) ) )
            {
                Console.WriteLine( "{0} = {1}", i, Enum.GetName( typeof( Genero ), i ) );
            }

            Console.Write( "Digite o gênero entre as opções acima: " );
            int entradaGenero = int.Parse( Console.ReadLine() );

            Console.Write( "Digite o título da série: " );
            string entradaTitulo = Console.ReadLine();

            Console.Write( "Digite o ano de início da série: " );
            int entradaAno = int.Parse( Console.ReadLine() );

            Console.Write( "Digite a descrição da série: " );
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie( id: indiceSerie, 
                                            genero: ( Genero ) entradaGenero, 
                                            titulo: entradaTitulo, 
                                            ano: entradaAno, 
                                            descricao: entradaDescricao );

            repositorio.Atualiza( indiceSerie, atualizaSerie );                                
        }

        public static void ExcluiSerie() 
        {
            Console.WriteLine( "Excluir uma série" );

            Console.Write( "Digite o id da série: " );
            int indiceSerie = int.Parse( Console.ReadLine() );

            repositorio.Exclui( indiceSerie );
        }

        public static void VisualizaSerie() 
        {
            Console.WriteLine( "Visualizar uma série" );

            Console.Write( "Digite o id da série: " );
            int indiceSerie = int.Parse( Console.ReadLine() );

            var serie = repositorio.RetornaPorId( indiceSerie );

            Console.WriteLine( serie );
        }

        private static string ObterOpcaoUsuario() 
        {
            Console.WriteLine();
            Console.WriteLine( "Erik Localiza Labs - Criando cadastro de séries" );
            Console.WriteLine( "Escolha uma opção:" );

            Console.WriteLine( "1 - Listar séries" );
            Console.WriteLine( "2 - Inserir uma nova série" );
            Console.WriteLine( "3 - Atualizar uma série" );
            Console.WriteLine( "4 - Excluir uma série" );
            Console.WriteLine( "5 - Visualizar uma série" );
            Console.WriteLine( "C - Limpar a tela" );
            Console.WriteLine( "X - Sair do programa" );
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}