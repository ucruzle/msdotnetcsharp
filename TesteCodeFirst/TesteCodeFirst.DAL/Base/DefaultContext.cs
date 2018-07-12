using System;
using System.Data.Entity;
using TesteCodeFirst.Entities;

namespace TesteCodeFirst.DAL.Base
{
    public class DefaultContext : DbContext
    {
        public DbSet<Ocupacao> Ocupacoes { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
    }
}