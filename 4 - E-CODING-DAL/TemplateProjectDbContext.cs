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
            modelBuilder.Entity<TemplateSolution>(entity =>
            {
                entity.HasKey(z => z.TemplateSolutionId);
                entity.Property(p => p.TemplateSolutionId)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<SolutionProject>()
                .HasKey(sc => new { sc.TemplateSolutionId, sc.TemplateProjectId });

            modelBuilder.Entity<SolutionProject>()
                .HasOne<TemplateSolution>(sc => sc.TemplateSolution)
                .WithMany(s => s.SolutionProject)
                .HasForeignKey(sc => sc.TemplateSolutionId);

            modelBuilder.Entity<SolutionProject>()
                .HasOne<TemplateProject>(sc => sc.TemplateProject)
                .WithMany(s => s.SolutionProject)
                .HasForeignKey(sc => sc.TemplateProjectId);

            modelBuilder.Entity<TemplateProject>(entity =>
            {
                entity.HasKey(z => z.TemplateProjectId);
                entity.Property(p => p.TemplateProjectId)
                .ValueGeneratedOnAdd();
            });
            
            modelBuilder.Entity<TemplateFonctionnel>(entity =>
            {
                entity.HasKey(e => e.TemplateFonctionnelId);
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

            modelBuilder.Entity<ProjectTechnique>()
                .HasKey(sc => new { sc.TemplateProjectId, sc.TemplateTechniqueId });

            modelBuilder.Entity<ProjectTechnique>()
                .HasOne<TemplateProject>(sc => sc.TemplateProject)
                .WithMany(s => s.ProjectTechnique)
                .HasForeignKey(sc => sc.TemplateProjectId);

            modelBuilder.Entity<ProjectTechnique>()
                .HasOne<TemplateTechnique>(sc => sc.TemplateTechnique)
                .WithMany(s => s.ProjectTechnique)
                .HasForeignKey(sc => sc.TemplateTechniqueId);

            modelBuilder.Entity<TemplateTechnique>(entity =>
            {
                entity.HasKey(e => e.TemplateTechniqueId);
                entity.Property(p => p.TemplateTechniqueId)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TechniqueParameter>(entity =>
            {
                entity.HasKey(e => e.TechniqueParameterId);
                entity.Property(p => p.TechniqueParameterId)
                .ValueGeneratedOnAdd();

                entity.HasOne(d => d.TemplateTechnique)
                    .WithMany(p => p.TechniqueParameter)
                    .HasForeignKey(d => d.TemplateTechniqueId);
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
            
            modelBuilder.Entity<TemplateResult>(entity =>
            {
                entity.HasKey(e => e.TemplateResultId);
                entity.Property(p => p.TemplateResultId)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ProjectResult>()
                .HasKey(sc => new { sc.TemplateProjectId, sc.TemplateResultId });

            modelBuilder.Entity<ProjectResult>()
                .HasOne<TemplateProject>(sc => sc.TemplateProject)
                .WithMany(s => s.ProjectResult)
                .HasForeignKey(sc => sc.TemplateProjectId);

            modelBuilder.Entity<ProjectResult>()
                .HasOne<TemplateResult>(sc => sc.TemplateResult)
                .WithMany(s => s.ProjectResult)
                .HasForeignKey(sc => sc.TemplateResultId);           

            modelBuilder.Entity<TemplateResultItem>(entity =>
            {
                entity.HasKey(e => e.TemplateResultItemId);
                entity.Property(p => p.TemplateResultItemId)
                .ValueGeneratedOnAdd();

                entity.HasOne(d => d.TemplateResult)
                    .WithMany(p => p.TemplateResultItem)
                    .HasForeignKey(d => d.TemplateResultId);
            });
        }
     }
}