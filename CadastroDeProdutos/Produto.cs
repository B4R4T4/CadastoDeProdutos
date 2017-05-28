using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeProdutos
{
    public class Produto
    {
        public string nomeProduto { get; set; }
        public string descricaoProduto { get; set; } //bando de dados é Produto

        public int codigoProduto { get; set; } //auto incrementado no mysql
        //..

    }
}
