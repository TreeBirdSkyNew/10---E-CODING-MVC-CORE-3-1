using _4___E_CODING_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL
{

    public class TemplateProjectDbContext : DbContext
    {

        public TemplateProjectDbContext(DbContextOptions<TemplateProjectDbContext> options)
            : base(options)
        {}

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
                optionsBuilder.UseSqlServer("Server=DESKTOP-2TG0VPH\\SQLEXPRESS;database=ECODING;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
            modelBuilder.Entity<TemplateParameter>(entity =>
            {
                entity.HasKey(e => e.TemplateParameterId);
                entity.Property(p => p.TemplateParameterId)
                .ValueGeneratedOnAdd();

                entity.HasOne(d => d.TemplateTechniqueItem)
                    .WithMany(p => p.TemplateParameter)
                    .HasForeignKey(d => d.TemplateTechniqueItemId);
            });*/

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

            modelBuilder.Entity<TemplateProject>()
            .HasData(new TemplateProject()
            {
                TemplateProjectId=1,
                TemplateProjectDescription = "TemplateProjectDescription1",
                TemplateProjectName = "TemplateProjectName1",
                TemplateProjectTitle = "TemplateProjectTitle1",
                TemplateProjectVersion = "TemplateProjectVersion1",
                TemplateProjectVersionNet = "TemplateProjectVersionNet1",
            });

            modelBuilder.Entity<TemplateProject>()
            .HasData(new TemplateProject()
            {
                TemplateProjectId = 2,
                TemplateProjectDescription = "TemplateProjectDescription2",
                TemplateProjectName = "TemplateProjectName2",
                TemplateProjectTitle = "TemplateProjectTitle2",
                TemplateProjectVersion = "TemplateProjectVersion2",
                TemplateProjectVersionNet = "TemplateProjectVersionNet2",
            });

            modelBuilder.Entity<TemplateTechnique>()
            .HasData(
            new TemplateTechnique
            {
                TemplateTechniqueId = 1,
                TemplateTechniqueDescription = "TemplateTechniqueDescription1",
                TemplateTechniqueName = "TemplateTechniqueName1",
                TemplateTechniqueTitle = "TemplateTechniqueTitle1",
                TemplateTechniqueVersion = "TemplateTechniqueVersion1",
                TemplateTechniqueVersionNET = "TemplateTechniqueVersionNET1",
                TemplateProjectId = 1
            });

           modelBuilder.Entity<TemplateTechnique>()
           .HasData(
           new TemplateTechnique
            {
                TemplateTechniqueId = 2,
                TemplateTechniqueDescription = "TemplateTechniqueDescription2",
                TemplateTechniqueName = "TemplateTechniqueName2",
                TemplateTechniqueTitle = "TemplateTechniqueTitle2",
                TemplateTechniqueVersion = "TemplateTechniqueVersion2",
                TemplateTechniqueVersionNET = "TemplateTechniqueVersionNET2",
                TemplateProjectId = 1
           });

            modelBuilder.Entity<TemplateTechniqueItem>()
            .HasData(new TemplateTechniqueItem
            {
                TemplateTechniqueItemId=1,
                TemplateTechniqueItemDescription = "TemplateTechniqueItemDescription1",
                TemplateTechniqueItemName = "TemplateTechniqueItemName1",
                TemplateTechniqueItemTitle = "TemplateTechniqueItemTitle1",
                TemplateTechniqueItemVersion = "TemplateTechniqueItemVersion1",
                TemplateTechniqueItemVersionNET = "TemplateTechniqueItemVersionNET1",
                TemplateTechniqueId = 1
            });

            modelBuilder.Entity<ProjectTechnique>()
            .HasData(
            new ProjectTechnique
            {
                TemplateProjectId = 1,
                TemplateTechniqueId=1
            });

            modelBuilder.Entity<ProjectTechnique>()
            .HasData(
            new ProjectTechnique
            {
                TemplateProjectId = 1,
                TemplateTechniqueId = 2
            });

            modelBuilder.Entity<TemplateFonctionnel>()
            .HasData(new TemplateFonctionnel
            {
                TemplateFonctionnelId=1,
                TemplateFonctionnelDescription = "TemplateFonctionnelDescription",
                TemplateFonctionnelName = "TemplateFonctionnelName",
                TemplateFonctionnelTitle = "TemplateFonctionnelTitle",
                TemplateFonctionnelContent = "TemplateFonctionnelContent",
                TemplateFonctionnelEFVersion = "TemplateFonctionnelEFVersion",
                TemplateProjectId = 1
            });

            modelBuilder.Entity<TemplateFonctionnelEntity>()
            .HasData(new TemplateFonctionnelEntity()
            {
                TemplateFonctionnelEntityId = 1,
                TemplateFonctionnelId = 1,
                TemplateFonctionnelEntityDescription = "TemplateFonctionnelEntityDescription",
                TemplateFonctionnelEntityName = "TemplateFonctionnelEntityName",
                TemplateFonctionnelEntityTitle = "TemplateFonctionnelEntityTitle",
                TemplateFonctionnelEntityContent = "TemplateFonctionnelEntityContent",
                TemplateFonctionnelEntityVersionEF = "TemplateFonctionnelEntityVersionEF",
                TemplateFonctionnelEntityVersionNET = "TemplateFonctionnelEntityVersionNET",
                TemplateFonctionnelEntityTypeNet = "TemplateFonctionnelEntityTypeNet",
                TemplateFonctionnelEntityTypeSQL = "TemplateFonctionnelEntityTypeSQL"
            });

            modelBuilder.Entity<TemplateFonctionnelProperty>()
            .HasData(new TemplateFonctionnelProperty()
            {
                TemplateFonctionnelPropertyId = 1,
                TemplateFonctionnelEntityId = 1,
                TemplateFonctionnelId = 1,
                TemplateFonctionnelPropertyDescription = "TemplateFonctionnelPropertyDescription",
                TemplateFonctionnelPropertyName = "TemplateFonctionnelPropertyName",
                TemplateFonctionnelPropertyTitle = "TemplateFonctionnelPropertyTitle",
                TemplateFonctionnelPropertyVersionEF = "TemplateFonctionnelPropertyVersionEF",
                TemplateFonctionnelPropertyVersionNET = "TemplateFonctionnelPropertyVersionNET"
            });

            modelBuilder.Entity<TemplateFonctionnelProperty>()
            .HasData(new TemplateFonctionnelProperty()
            {
                TemplateFonctionnelPropertyId = 2,
                TemplateFonctionnelEntityId = 1,
                TemplateFonctionnelId = 1,
                TemplateFonctionnelPropertyDescription = "TemplateFonctionnelPropertyDescription",
                TemplateFonctionnelPropertyName = "TemplateFonctionnelPropertyName",
                TemplateFonctionnelPropertyTitle = "TemplateFonctionnelPropertyTitle",
                TemplateFonctionnelPropertyVersionEF = "TemplateFonctionnelPropertyVersionEF",
                TemplateFonctionnelPropertyVersionNET = "TemplateFonctionnelPropertyVersionNET"
            });

            
            modelBuilder.Entity<TemplateResult>()
            .HasData(new TemplateResult
            {
                TemplateResultId = 1,
                TemplateProjectId = 1,
                TemplateResultDescription = "TemplateResultDescription",
                TemplateResultName = "TemplateResultName",
                TemplateResultTitle = "TemplateResultTitle",
                TemplateResultVersion = "TemplateResultVersion",
                TemplateResultVersionNET = "TemplateResultVersionNET",
             });

            modelBuilder.Entity<TemplateResult>()
            .HasData(new TemplateResult
            {
                TemplateResultId = 2,
                TemplateProjectId = 1,
                TemplateResultDescription = "TemplateResultDescription",
                TemplateResultName = "TemplateResultName",
                TemplateResultTitle = "TemplateResultTitle",
                TemplateResultVersion = "TemplateResultVersion",
                TemplateResultVersionNET = "TemplateResultVersionNET",
            });

            modelBuilder.Entity<TemplateResultItem>()
            .HasData(new TemplateResultItem
            {
                TemplateResultItemId=1,
                TemplateResultItemDescription = "TemplateResultItemDescription",
                TemplateResultItemName = "TemplateResultItemName",
                TemplateResultItemTitle = "TemplateResultItemTitle",
                TemplateResultItemVersion = "TemplateResultItemVersion",
                TemplateResultItemVersionNET = "TemplateResultItemVersionNET",
                TemplateTechniqueId = 1,
                TemplateFonctionnelId = 1,
                TemplateResultId=1,
                TemplateResultFinalContent= "TemplateResultFinalContent",
                TemplateResultInitialContent= "TemplateResultInitialContent"
            });

            modelBuilder.Entity<TemplateResultItem>()
            .HasData(new TemplateResultItem
            {
                TemplateResultItemId = 2,
                TemplateResultItemDescription = "TemplateResultItemDescription",
                TemplateResultItemName = "TemplateResultItemName",
                TemplateResultItemTitle = "TemplateResultItemTitle",
                TemplateResultItemVersion = "TemplateResultItemVersion",
                TemplateResultItemVersionNET = "TemplateResultItemVersionNET",
                TemplateTechniqueId = 1,
                TemplateFonctionnelId = 1,
                TemplateResultId = 2,
                TemplateResultFinalContent = "TemplateResultFinalContent",
                TemplateResultInitialContent = "TemplateResultInitialContent"
            });

            modelBuilder.Entity<ProjectResult>()
            .HasData(new ProjectResult
            {
                TemplateProjectId = 1,
                TemplateResultId = 1
            });

            modelBuilder.Entity<ProjectResult>()
            .HasData(new ProjectResult
            {
                TemplateProjectId = 1,
                TemplateResultId = 2
            });
        }

     }

    
}