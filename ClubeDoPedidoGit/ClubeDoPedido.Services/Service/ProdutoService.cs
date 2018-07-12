using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ClubeDoPedido.Modelo.Modelo;
using Newtonsoft.Json.Linq;

namespace ClubeDoPedido.Services.Service
{
    public class ProdutoService
    {
        const string constantRoute = "http://localhost:50820/";
        //const string constantRoute = "http://localhost:9091/";

        public async Task<List<ProdutoDto>> BuscaProdutos()
        {
            using (var cliente = new HttpClient())
            {
                var url = string.Format(constantRoute + "usuario/buscaUsuarios");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var resposta = await cliente.GetAsync(url);
                var conteudo = await resposta.Content.ReadAsStringAsync();
                var json = JArray.Parse(conteudo);

                var repositorios = new List<ProdutoDto>();
                foreach (var item in json)
                {
                    var produto = new ProdutoDto();
                    produto.Imagem = item.Value<string>("imagem");
                    produto.DescricaoReduzida = item.Value<string>("descricaoReduzida");
                    produto.DescricaoDetalhada = item.Value<string>("descricaoDetalhada");
                    produto.ValorUnitario = item.Value<decimal>("valorUnitario");
                    produto.ParceiroID = item.Value<int>("parceiroID");
                    produto.DataAlteracao = item.Value<DateTime>("dataAlteracao");
                    produto.DataInclusao = item.Value<DateTime>("dataInclusao");
                    repositorios.Add(produto);
                }

                return repositorios;
            }
        }
    }
}
