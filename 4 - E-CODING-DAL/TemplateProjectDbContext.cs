using _4___E_CODING_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL
{
    //Add-Migration AddingEFExtensions -Context TemplateProjectDbContext -Project E-CODING-DAL -StartupProject E-CODING-MVC-NET6-0
    public class TemplateProjectDbContext : DbContext
    {

        public TemplateProjectDbContext(DbContextOptions<TemplateProjectDbContext> options)
            : base(options)
        {}

        public virtual DbSet<TemplateSolution> TemplateSolution { get; set; }
        public virtual DbSet<TemplateProject> TemplateProject { get; set; }        
        public virtual DbSet<TemplateFonctionnel> TemplateFonctionnel { get; set; }
        public virtual DbSet<TemplateFonctionnelEntity> TemplateFonctionnelEntity { get; set; }
        public virtual DbSet<TemplateFonctionnelProperty> TemplateFonctionnelProperty { get; set; }
        public virtual DbSet<TemplateTechnique> TemplateTechnique { get; set; }
        public virtual DbSet<TemplateTechniqueItem> TemplateTechniqueItem { get; set; }
        public virtual DbSet<TemplateResult> TemplateResult { get; set; }
        public virtual DbSet<TemplateResultItem> TemplateResultItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-2TG0VPH\\SQLEXPRESS;database=ECODING;Trusted_Connection=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TemplateSolution>()
              .HasMany(s => s.ChildSolutions)
              .WithOne(s => s.ParentSolution)
              .HasForeignKey(s => s.ParentSolutionId);


            modelBuilder.Entity<TemplateProject>(entity =>
            {
                entity.HasKey(z => z.TemplateProjectId);
                entity.Property(p => p.TemplateProjectId)
                .ValueGeneratedOnAdd();

                entity.HasOne(d => d.TemplateSolution)
                    .WithMany(p => p.TemplateProject)
                    .HasForeignKey(d => d.TemplateSolutionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<TemplateTechnique>(entity =>
            {
                entity.HasKey(e => e.TemplateTechniqueId);
                entity.Property(p => p.TemplateTechniqueId)
                .ValueGeneratedOnAdd();

                entity.HasOne(d => d.TemplateProject)
                    .WithMany(p => p.TemplateTechnique)
                    .HasForeignKey(d => d.TemplateProjectId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TemplateTechniqueItem>(entity =>
            {
                entity.HasKey(e => e.TemplateTechniqueItemId);
                entity.Property(p => p.TemplateTechniqueItemId)
                .ValueGeneratedOnAdd();

                entity.HasOne(d => d.TemplateTechnique)
                    .WithMany(p => p.TemplateTechniqueItem)
                    .HasForeignKey(d => d.TemplateTechniqueId);
            });


            /*
             
    entity.Property(p => p.TemplateFonctionnelId)
    .ValueGeneratedOnAdd();

    entity.HasOne<TemplateProject>(ad => ad.TemplateProject)
    .WithOne(s => s.TemplateFonctionnel)
    .HasForeignKey<TemplateFonctionnel>(ad => ad.TemplateProjectId);
});

modelBuilder.Entity<TemplateFonctionnelEntity>(entity =>
{
    entity.HasKey(e => e.TemplateFonctionnelEntityId);
    entity.Property(p => p.TemplateFonctionnelEntityId)
    .ValueGeneratedOnAdd();

    entity.HasOne(d => d.TemplateFonctionnel)
        .WithMany(p => p.TemplateFonctionnelEntity)
        .HasForeignKey(d => d.TemplateFonctionnelId);
});

modelBuilder.Entity<TemplateFonctionnelProperty>(entity =>
{
    entity.HasKey(e => e.TemplateFonctionnelPropertyId);
    entity.Property(p => p.TemplateFonctionnelPropertyId)
    .ValueGeneratedOnAdd();

    entity.HasOne(d => d.TemplateFonctionnelEntity)
        .WithMany(p => p.TemplateFonctionnelProperty)
        .HasForeignKey(d => d.TemplateFonctionnelEntityId);
});
             */

        }
    }
}