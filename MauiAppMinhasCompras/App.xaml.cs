using MauiAppMinhasCompras.Helpers;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        //Declara um campo estático privado chamado _db.
        //Estático = existe uma única instância compartilhada por toda a aplicação
        //(padrão “singleton” manual).
        static SQLiteDatabaseHelper _db;

        //Define uma propriedade estática pública chamada DB.
        //Por ser estática, você acessa como NomeDaClasse.DB(sem precisar instanciar a classe).
        public static SQLiteDatabaseHelper DB 
        {
            //Só existe getter (leitura). Não há set, então ninguém de fora troca a instância.
            get
            {
                //Lazy initialization: se ainda não criamos o helper(_db é null),
                //vamos criar agora.
                //Isso faz com que o objeto só seja criado na primeira vez que for usado.
                if (_db == null)
                {
                    //Monta o caminho completo do arquivo do banco,
                    //pega a pasta de dados local do app/usuário de forma cross-platform
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");
                    //Cria a instância única do helper, apontando para o arquivo em path.
                    //Normalmente, o helper vai abrir/criar o banco se ainda não
                    //existir e preparar a conexão
                    _db = new SQLiteDatabaseHelper(path);
                }

                //Fecha o if e retorna a instância (nova na primeira vez,
                //reaproveitada nas próximas).
                return _db;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}
