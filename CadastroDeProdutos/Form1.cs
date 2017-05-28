using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CadastroDeProdutos
{

    
    public partial class Form1 : Form
    {
      

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            CarregaCombo();
        }

        private void CarregaCombo()
        {

            comboBox1.DataSource = ProdutosDAL.RetornaLista();
            comboBox1.DisplayMember = "codigoProduto";
            comboBox1.ValueMember = "descricaoProduto";

            carregaTexto();





        }

      private void carregaTexto()
        {
            
            
            //textNome.Text = comboBox1.Text;


        }


        private void botaoCadastrar_Click(object sender, EventArgs e)
        {

            string Nome = textNome.Text;
            string Descricao = textDescricao.Text;
             string CONFIG = "server=127.0.0.1; userid=root;database=bd";


            MySqlConnection conexao = new MySqlConnection(CONFIG);
            MySqlCommand query = new MySqlCommand();

            query.Connection = conexao;

            conexao.Open();

            query.CommandText ="INSERT INTO produto (nome,descricao) values (@nome, @descricao)";

            query.Parameters.AddWithValue("@nome", Nome);
            query.Parameters.AddWithValue("@descricao", Descricao);
            query.ExecuteNonQuery();
            query.Connection.Close();

            MessageBox.Show("Produto cadastrado!");

            CarregaCombo();




        }

        private void textNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string CONFIG = "server=127.0.0.1; userid=root;database=bd";
            MySqlConnection conexao = new MySqlConnection(CONFIG);

            var deleteQuery = "DELETE FROM produto WHERE Codigo= ' " + comboBox1.Text.ToString() + " '";

            conexao.Open();
            MySqlCommand command = new MySqlCommand(deleteQuery,conexao);
                    
                if (command.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Produto Deletado");
                    CarregaCombo();
                }
                else
                {
                    MessageBox.Show("Produto não Deletado");

                }


            } catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }



            





        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void codigoProduto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
