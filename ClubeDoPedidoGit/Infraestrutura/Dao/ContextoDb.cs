using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Dominio.Modelo;
using Infraestrutura.Mapeamento;

namespace Infraestrutura.Dao
{
    public class ContextoDb : DbContext
    {
        //Construtor
        public ContextoDb()
            : base("ConnStrgClubePedido")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        //DbSet's
        public DbSet<Usuario> UsuarioDb { get; set; }
        public DbSet<Endereco> EnderecoDb { get; set; }
        public DbSet<Parceiro> ParceiroDb { get; set; }
        public DbSet<ConfiguracaoParceiro> ConfiguracaoParceiroDb { get; set; }
        public DbSet<Plano> PlanoDb { get; set; }
        public DbSet<Produto> ProdutoDb { get; set; }
        public DbSet<Token> TokenDb { get; set; }
        public DbSet<PlanoContratado> PlanoContratadoDb { get; set; }
        public DbSet<Pedido> PedidoDb { get; set; }
        public DbSet<PedidoItem> PedidoItemDb { get; set; }
        public DbSet<EnderecoVinculo> EnderecoVinculoDb { get; set; }
        public DbSet<PedidoPromocao> PedidoPromocaoDb { get; set; }
        public DbSet<Promocao> PromocaoDb { get; set; }
        public DbSet<RamoAtividade> RamoAtividadeDb { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new ParceiroMap());
            modelBuilder.Configurations.Add(new ConfiguracaoParceiroMap());
            modelBuilder.Configurations.Add(new PlanoMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new TokenMap());
            modelBuilder.Configurations.Add(new PlanoContratadoMap());
            modelBuilder.Configurations.Add(new PedidoMap());
            modelBuilder.Configurations.Add(new PedidoItemMap());
            modelBuilder.Configurations.Add(new EnderecoVinculoMap());
            modelBuilder.Configurations.Add(new PedidoPromocaoMap());
            modelBuilder.Configurations.Add(new PromocaoMap());
            modelBuilder.Configurations.Add(new RamoAtividadeMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
