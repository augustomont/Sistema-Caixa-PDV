using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_caixa_pdv
{
    class Conexao
    {
        public MySqlConnection conexao = null;
        public string data_source = "datasource=localhost;username=root;password=1234;database=pdv";

        public void abrirConexao()
        {
            conexao = new MySqlConnection(data_source);
            conexao.Open();
        }
        public void fecharConexao()
        {
            conexao= new MySqlConnection(data_source);
            conexao.Close();
            conexao.Dispose();//derruba algumas conxoes abertas
            conexao.ClearAllPoolsAsync();//metodo de limpesa
        }
    }
}
