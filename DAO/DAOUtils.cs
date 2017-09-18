﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            string server = ConfigurationManager.AppSettings["server"].ToString();
            string database = ConfigurationManager.AppSettings["database"].ToString();
            string user = ConfigurationManager.AppSettings["user"].ToString();
            string password = ConfigurationManager.AppSettings["password"].ToString();
            DbConnection conexao = null;
            string connectionString = "";
            if (ConfigurationManager.AppSettings["provider"].ToString().Equals("MSSQL"))
            {
                connectionString = @"Server=" + server + ";Database=" + database + ";User Id=" + user + ";Password =" + password + ";";
                conexao = new SqlConnection(connectionString);
            }
            else
            {
                connectionString = @"Server=" + server +";Database=" + database +";Uid=" +user+";Pwd="+password+";";
                conexao = new MySqlConnection(connectionString);
            }


            //DbConnection conexao = new SqlConnection(@"Server =DESKTOP-0O66F3G,1433\SQLEXPRESS;Database=TreinaWebCSharp;User Id=sa;Password = Innfo@120;");
            //DbConnection conexao = new MySqlConnection(@"Server=DESKTOP-0O66F3G;Port=3306;Database=treinawebcsharpintermediario;Uid=root;Pwd=Innfo@120;");

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
        public static DbParameter GetParameter(string nome, object valor)
        {
            DbParameter parametro = null;
            if (ConfigurationManager.AppSettings["provider"].ToString().Equals("MSSQL"))
            {
                parametro = new SqlParameter(nome, valor);
            }else
            {
                parametro = new MySqlParameter(nome, valor);
            }
            return parametro;
        }
    }
}
