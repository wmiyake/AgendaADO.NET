using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AgendaADONET.DAO
{
    public class DAOUtils
    {
        public static DbConnection GetConexao()
        {
            //DbConnection conexao = new SqlConnection(@"Server=DESKTOP-0O66F3G,1433\SQLEXPRESS;Database=TreinaWebCSharp;User Id=sa;Password = Innfo@120;");
            DbConnection conexao = new MySqlConnection(@"Server=DESKTOP-0O66F3G;Port=3306;Database=treinawebcsharpintermediario;Uid=root;Pwd=Innfo@120;");
            conexao.Open();
            return conexao;
        }

        public static DbCommand GetComando(DbConnection conexao)
        {
            DbCommand comando = conexao.CreateCommand();
            return comando;
        }
        public static DbDataReader GetDataReader(DbCommand comando)
        {
            return comando.ExecuteReader();
        }
    }
}
