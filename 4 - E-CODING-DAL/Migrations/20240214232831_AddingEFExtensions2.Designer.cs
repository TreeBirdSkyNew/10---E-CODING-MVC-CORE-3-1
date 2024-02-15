﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _4___E_CODING_DAL;

#nullable disable

namespace _4___E_CODING_DAL.Migrations
{
    [DbContext(typeof(TemplateProjectDbContext))]
    [Migration("20240214232831_AddingEFExtensions2")]
    partial class AddingEFExtensions2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("_4___E_CODING_DAL.Models.ProjectResult", b =>
                {
                    b.Property<int>("TemplateProjectId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateResultId")
                        .HasColumnType("int");

                    b.HasKey("TemplateProjectId", "TemplateResultId");

                    b.HasIndex("TemplateResultId");

                    b.ToTable("ProjectResult");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.ProjectTechnique", b =>
                {
                    b.Property<int>("TemplateProjectId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateTechniqueId")
                        .HasColumnType("int");

                    b.HasKey("TemplateProjectId", "TemplateTechniqueId");

                    b.HasIndex("TemplateTechniqueId");

                    b.ToTable("ProjectTechnique");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.SolutionProject", b =>
                {
                    b.Property<int>("TemplateSolutionId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateProjectId")
                        .HasColumnType("int");

                    b.HasKey("TemplateSolutionId", "TemplateProjectId");

                    b.HasIndex("TemplateProjectId");

                    b.ToTable("SolutionProject");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TechniqueParameter", b =>
                {
                    b.Property<int>("TechniqueParameterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TechniqueParameterId"), 1L, 1);

                    b.Property<string>("TechniqueParameterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechniqueParameterValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemplateTechniqueId")
                        .HasColumnType("int");

                    b.HasKey("TechniqueParameterId");

                    b.HasIndex("TemplateTechniqueId");

                    b.ToTable("TechniqueParameter");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateFonctionnel", b =>
                {
                    b.Property<int>("TemplateFonctionnelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TemplateFonctionnelId"), 1L, 1);

                    b.Property<string>("TemplateFonctionnelContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateFonctionnelDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateFonctionnelEFVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateFonctionnelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateFonctionnelTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemplateProjectId")
                        .HasColumnType("int");

                    b.HasKey("TemplateFonctionnelId");

                    b.HasIndex("TemplateProjectId")
                        .IsUnique();

                    b.ToTable("TemplateFonctionnel");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateFonctionnelEntity", b =>
                {
                    b.Property<int>("TemplateFonctionnelEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TemplateFonctionnelEntityId"), 1L, 1);

                    b.Property<string>("TemplateFonctionnelEntityContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateFonctionnelEntityDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateFonctionnelEntityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateFonctionnelEntityTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateFonctionnelEntityTypeNet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateFonctionnelEntityTypeSQL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateFonctionnelEntityVersionEF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateFonctionnelEntityVersionNET")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemplateFonctionnelId")
                        .HasColumnType("int");

                    b.HasKey("TemplateFonctionnelEntityId");

                    b.HasIndex("TemplateFonctionnelId");

                    b.ToTable("TemplateFonctionnelEntity");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateFonctionnelProperty", b =>
                {
                    b.Property<int>("TemplateFonctionnelPropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TemplateFonctionnelPropertyId"), 1L, 1);

                    b.Property<int>("TemplateFonctionnelEntityId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateFonctionnelId")
                        .HasColumnType("int");

                    b.Property<string>("TemplateFonctionnelPropertyDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateFonctionnelPropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateFonctionnelPropertyTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateFonctionnelPropertyVersionEF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateFonctionnelPropertyVersionNET")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TemplateFonctionnelPropertyId");

                    b.HasIndex("TemplateFonctionnelEntityId");

                    b.ToTable("TemplateFonctionnelProperty");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateProject", b =>
                {
                    b.Property<int>("TemplateProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TemplateProjectId"), 1L, 1);

                    b.Property<string>("TemplateProjectDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateProjectTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateProjectVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateProjectVersionNet")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TemplateProjectId");

                    b.ToTable("TemplateProject");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateResult", b =>
                {
                    b.Property<int>("TemplateResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TemplateResultId"), 1L, 1);

                    b.Property<int>("TemplateProjectId")
                        .HasColumnType("int");

                    b.Property<string>("TemplateResultDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateResultName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateResultTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateResultVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateResultVersionNET")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TemplateResultId");

                    b.ToTable("TemplateResult");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateResultItem", b =>
                {
                    b.Property<int>("TemplateResultItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TemplateResultItemId"), 1L, 1);

                    b.Property<int>("TemplateFonctionnelId")
                        .HasColumnType("int");

                    b.Property<string>("TemplateResultFinalContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemplateResultId")
                        .HasColumnType("int");

                    b.Property<string>("TemplateResultInitialContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateResultItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateResultItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateResultItemTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateResultItemVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateResultItemVersionNET")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemplateTechniqueId")
                        .HasColumnType("int");

                    b.HasKey("TemplateResultItemId");

                    b.HasIndex("TemplateResultId");

                    b.ToTable("TemplateResultItem");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateSolution", b =>
                {
                    b.Property<int>("TemplateSolutionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TemplateSolutionId"), 1L, 1);

                    b.Property<string>("TemplateSolutionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateSolutionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateSolutionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateSolutionVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateSolutionVersionNet")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TemplateSolutionId");

                    b.ToTable("TemplateSolution");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateTechnique", b =>
                {
                    b.Property<int>("TemplateTechniqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TemplateTechniqueId"), 1L, 1);

                    b.Property<int>("TemplateProjectId")
                        .HasColumnType("int");

                    b.Property<string>("TemplateTechniqueDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateTechniqueName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateTechniqueTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateTechniqueVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateTechniqueVersionNET")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TemplateTechniqueId");

                    b.ToTable("TemplateTechnique");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateTechniqueItem", b =>
                {
                    b.Property<int>("TemplateTechniqueItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TemplateTechniqueItemId"), 1L, 1);

                    b.Property<string>("TemplateTechniqueFinalContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemplateTechniqueId")
                        .HasColumnType("int");

                    b.Property<string>("TemplateTechniqueInitialFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateTechniqueItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateTechniqueItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateTechniqueItemTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateTechniqueItemVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateTechniqueItemVersionNET")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TemplateTechniqueItemId");

                    b.HasIndex("TemplateTechniqueId");

                    b.ToTable("TemplateTechniqueItem");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.ProjectResult", b =>
                {
                    b.HasOne("_4___E_CODING_DAL.Models.TemplateProject", "TemplateProject")
                        .WithMany("ProjectResult")
                        .HasForeignKey("TemplateProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_4___E_CODING_DAL.Models.TemplateResult", "TemplateResult")
                        .WithMany("ProjectResult")
                        .HasForeignKey("TemplateResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TemplateProject");

                    b.Navigation("TemplateResult");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.ProjectTechnique", b =>
                {
                    b.HasOne("_4___E_CODING_DAL.Models.TemplateProject", "TemplateProject")
                        .WithMany("ProjectTechnique")
                        .HasForeignKey("TemplateProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_4___E_CODING_DAL.Models.TemplateTechnique", "TemplateTechnique")
                        .WithMany("ProjectTechnique")
                        .HasForeignKey("TemplateTechniqueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TemplateProject");

                    b.Navigation("TemplateTechnique");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.SolutionProject", b =>
                {
                    b.HasOne("_4___E_CODING_DAL.Models.TemplateProject", "TemplateProject")
                        .WithMany("SolutionProject")
                        .HasForeignKey("TemplateProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_4___E_CODING_DAL.Models.TemplateSolution", "TemplateSolution")
                        .WithMany("SolutionProject")
                        .HasForeignKey("TemplateSolutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TemplateProject");

                    b.Navigation("TemplateSolution");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TechniqueParameter", b =>
                {
                    b.HasOne("_4___E_CODING_DAL.Models.TemplateTechnique", "TemplateTechnique")
                        .WithMany("TechniqueParameter")
                        .HasForeignKey("TemplateTechniqueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TemplateTechnique");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateFonctionnel", b =>
                {
                    b.HasOne("_4___E_CODING_DAL.Models.TemplateProject", "TemplateProject")
                        .WithOne("TemplateFonctionnel")
                        .HasForeignKey("_4___E_CODING_DAL.Models.TemplateFonctionnel", "TemplateProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TemplateProject");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateFonctionnelEntity", b =>
                {
                    b.HasOne("_4___E_CODING_DAL.Models.TemplateFonctionnel", "TemplateFonctionnel")
                        .WithMany("TemplateFonctionnelEntity")
                        .HasForeignKey("TemplateFonctionnelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TemplateFonctionnel");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateFonctionnelProperty", b =>
                {
                    b.HasOne("_4___E_CODING_DAL.Models.TemplateFonctionnelEntity", "TemplateFonctionnelEntity")
                        .WithMany("TemplateFonctionnelProperty")
                        .HasForeignKey("TemplateFonctionnelEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TemplateFonctionnelEntity");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateResultItem", b =>
                {
                    b.HasOne("_4___E_CODING_DAL.Models.TemplateResult", "TemplateResult")
                        .WithMany("TemplateResultItem")
                        .HasForeignKey("TemplateResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TemplateResult");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateTechniqueItem", b =>
                {
                    b.HasOne("_4___E_CODING_DAL.Models.TemplateTechnique", "TemplateTechnique")
                        .WithMany("TemplateTechniqueItem")
                        .HasForeignKey("TemplateTechniqueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TemplateTechnique");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateFonctionnel", b =>
                {
                    b.Navigation("TemplateFonctionnelEntity");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateFonctionnelEntity", b =>
                {
                    b.Navigation("TemplateFonctionnelProperty");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateProject", b =>
                {
                    b.Navigation("ProjectResult");

                    b.Navigation("ProjectTechnique");

                    b.Navigation("SolutionProject");

                    b.Navigation("TemplateFonctionnel");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateResult", b =>
                {
                    b.Navigation("ProjectResult");

                    b.Navigation("TemplateResultItem");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateSolution", b =>
                {
                    b.Navigation("SolutionProject");
                });

            modelBuilder.Entity("_4___E_CODING_DAL.Models.TemplateTechnique", b =>
                {
                    b.Navigation("ProjectTechnique");

                    b.Navigation("TechniqueParameter");

                    b.Navigation("TemplateTechniqueItem");
                });
#pragma warning restore 612, 618
        }
    }
}
