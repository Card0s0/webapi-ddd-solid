using Manager.Domain.Entities;
using Manager.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Data.Context
{
    public class ManagerContext : DbContext
    {
        public ManagerContext()
        { }

        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        { }

        public virtual DbSet<User> Users { get; set; }


        //Para Criar Migrations
        //Criar Migration: dotnet ef migration add NOME_DA_MIGRATION(Ex: InitialMiration)
        //Atualizar Base:  dotnet ef database update
        //protected override void OnConfiguring(DbContextOptionsBuilder optiondBuild)
        //{
        //    //SQLServer local do VisualStudio

        //  optiondBuild.UseSqlServer();
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }
    }
}
