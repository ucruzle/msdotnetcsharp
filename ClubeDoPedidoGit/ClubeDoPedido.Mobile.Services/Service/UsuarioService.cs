using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ClubeDoPedido.Mobile.Model.Modelo;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClubeDoPedido.Mobile.Services.Service
{
    public class UsuarioService
    {
        const string constantRoute = "http://localhost:50820/";
        //const string constantRoute = "http://localhost:9091/";

        public async Task<List<Usuario>> BuscaUsuarios()
        {
            using (var cliente = new HttpClient())
            {
                var url = string.Format(constantRoute + "usuario/buscaUsuarios");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var resposta = await cliente.GetAsync(url);
                var conteudo = await resposta.Content.ReadAsStringAsync();
                var json = JArray.Parse(conteudo);

                var repositorios = new List<Usuario>();
                foreach (var item in json)
                {
                    var usuario = new Usuario();
                    usuario.ID = item.Value<int>("id");
                    usuario.Nome = item.Value<string>("nome");
                    usuario.Email = item.Value<string>("email");
                    usuario.Senha = item.Value<string>("senha");
                    usuario.Celular = item.Value<string>("celular");
                    usuario.Foto = item.Value<string>("foto");
                    usuario.EnderecoID = item.Value<int?>("enderecoID");
                    repositorios.Add(usuario);
                }

                return repositorios;
            }
        }

        public async Task RegistrarUsuario(Usuario usuario)
        {
            HttpResponseMessage response = null;
            var jsonRequest = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
            var url = string.Format(constantRoute + "usuario/registroUsuarioMobile");

            using (var cliente = new HttpClient())
            {
                response = await cliente.PostAsync(url, content);
                var result = response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
