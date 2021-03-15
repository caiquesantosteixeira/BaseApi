using Dapper;
using Base.Infra.Context;
using System;

namespace Base.Infra.Migrations.Configs
{
    public class CheckDatabase
    {
        public static void DatabaseExist(string connectionString)
        {

            var _dataBaseName = ExtractDataBaseName(connectionString);
            if (string.IsNullOrWhiteSpace(_dataBaseName))
            {
                throw new Exception("Não foi possivel identificar o banco de dados;");
            }

            // Remove o nome do banco de dados porque se o banco não existir não conseguirá conectar para criar.
            var _connectionSemBD = ConnectionRemoveDatabase(connectionString);

            // Cria o Banco caso não exista
            CheckOrCreateDatabaseSqlServer(_connectionSemBD, _dataBaseName);
        }      

        private static void CheckOrCreateDatabaseSqlServer(string connectionSemBD, string dataBase)
        {
            try
            {
                string sqlCheck = $"if not exists(select * from sys.databases where name='{dataBase}') BEGIN " +
                                   $"exec('Create database {dataBase}') END";

                var dapp = new ADOSqlServerContext(connectionSemBD);
                using (var conn = dapp.GetConection())
                {
                    conn.ExecuteScalar(sqlCheck);
                    conn.Dispose();
                }
                dapp.FecharConexao();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel identificar o banco de dados;");
            }
        }

        public static void CreateTablesSqlServer(string connectionComBD)
        {
            try
            {
                string sqlCheck = 
                    $" if exists(select * from sys.databases where name='base') BEGIN " +
                        " if not exists(select 1 from syscolumns where id = object_id('cliente'))"+
                        " begin" +
                        "    create table cliente(" +
                        "        id int identity(1,1) primary key," +
                        "        nome varchar(100) not null," +
                        "        cpf varchar(11) not null," +
                        "        saldo decimal(10, 2) not null," +
                        "        idusuario nvarchar(450) not null," +
                        "        FOREIGN KEY(idusuario) REFERENCES usuarios(Id)" +
                        "    );" +
                        " end" +

                        " if not exists(select 1 from syscolumns where id = object_id('saque'))" +
                        " begin" +
                        " create table saque" +
                        " (" +
                        "    id int identity(1,1) primary key," +
                        "    idCliente int not null," +
                        "    valor decimal(10, 2) not null," +
                        "    Data datetime," +
                        "    FOREIGN KEY(idCliente) REFERENCES cliente(Id)" +
                        " );" +
                        "               end" +

                        " if not exists(select 1 from syscolumns where id = object_id('deposito'))" +
                        " begin" +
                        " create table deposito" +
                        " (" +
                        "    id int identity(1,1) primary key," +
                        "    idCliente int not null," +
                        "    nomeRemetente varchar(100)," +
                        "    valor decimal(10, 2) not null," +
                        "    Data datetime," +
                        "    FOREIGN KEY(idCliente) REFERENCES cliente(Id)" +
                        " );" +
                        " end" +

                        " if not exists(select 1 from syscolumns where id = object_id('transferencia'))" +
                        " begin" +
                        " create table transferencia" +
                        " (" +
                        "    id int identity(1,1) primary key," +
                        "    idClienteRemetente int not null," +
                        "    idClienteDestinatario int not null," +
                        "    valor decimal(10, 2) not null," +
                        "    Data datetime," +
                        "    FOREIGN KEY(idClienteRemetente) REFERENCES cliente(Id)," +
                        "    FOREIGN KEY(idClienteDestinatario) REFERENCES cliente(Id)" +
                        " );" +
                        " end" +


                    " END ";

                var dapp = new ADOSqlServerContext(connectionComBD);
                using (var conn = dapp.GetConection())
                {
                    conn.ExecuteScalar(sqlCheck);
                    conn.Dispose();
                }
                dapp.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel identificar o banco de dados;");
            }
        }


        private static string ExtractDataBaseName(string connectionString)
        {
            string databaseName = "";

            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                var quebra1 = connectionString.Split(';');
                foreach (var part in quebra1)
                {
                    if (part.ToUpper().Contains("CATALOG"))
                    {
                        var part2 = part.Split("=");
                        databaseName = part2[1];
                    }       
                }
            }
            return databaseName;
        }

        private static string ConnectionRemoveDatabase(string connectionString)
        {
            string connection = "";

            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                var quebra1 = connectionString.Split(';');
                foreach (var part in quebra1)
                {                    
                    if (!string.IsNullOrWhiteSpace(part))
                    { 
                        if (!part.ToUpper().Contains("CATALOG"))
                        {
                            connection += part + ";";
                        }
                    }

                }
            }
            return connection;
        }
    }
}
