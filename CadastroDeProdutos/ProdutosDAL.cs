using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CadastroDeProdutos
{
    public class ProdutosDAL
    {
        public static List<Produto> RetornaLista()
        {
            string CONFIG = "server=127.0.0.1; userid=root;database=bd";
            MySqlConnection conn = new MySqlConnection(CONFIG);

            var sql = "Select nome, descricao, Codigo from produto";

            var comando = new MySqlCommand(sql, conn);
            var lista = new List<Produto>();

            conn.Open();

            var leitor = comando.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    var perfil = new Produto();
                    perfil.nomeProduto = leitor["Nome"].ToString();
                    perfil.descricaoProduto = leitor["Descricao"].ToString();
                    perfil.codigoProduto = Convert.ToInt32(leitor["Codigo"]);
                    lista.Add(perfil);
                }

            }

            conn.Close();
            return lista;

        }
     }
}
