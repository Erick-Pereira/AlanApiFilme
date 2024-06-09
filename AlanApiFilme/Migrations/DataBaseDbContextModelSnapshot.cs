﻿// <auto-generated />
using System;
using AlanApiFilme;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlanApiFilme.Migrations
{
    [DbContext(typeof(DataBaseDbContext))]
    partial class DataBaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AlanApiFilme.Model.Filme", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoriaID")
                        .IsUnicode(false)
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ClassificacaoID")
                        .IsUnicode(false)
                        .HasColumnType("char(36)");

                    b.Property<Guid>("GeneroID")
                        .IsUnicode(false)
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MidiaID")
                        .IsUnicode(false)
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("longtext");

                    b.Property<Guid>("TipoMidiaID")
                        .IsUnicode(false)
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.ToTable("FILMES", (string)null);
                });

            modelBuilder.Entity("AlanApiFilme.Model.Participante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Participante");
                });

            modelBuilder.Entity("AlanApiFilme.Model.ParticipanteFilme", b =>
                {
                    b.Property<Guid>("ParticipanteID")
                        .IsUnicode(false)
                        .HasColumnType("char(36)");

                    b.Property<Guid>("FilmeID")
                        .IsUnicode(false)
                        .HasColumnType("char(36)");

                    b.HasKey("ParticipanteID", "FilmeID");

                    b.HasIndex("FilmeID");

                    b.ToTable("PARTICIPANTE_FILME", (string)null);
                });

            modelBuilder.Entity("AlanApiFilme.Model.ParticipanteFilme", b =>
                {
                    b.HasOne("AlanApiFilme.Model.Filme", "Filme")
                        .WithMany("Participantes")
                        .HasForeignKey("FilmeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlanApiFilme.Model.Participante", "Participante")
                        .WithMany("Filmes")
                        .HasForeignKey("ParticipanteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filme");

                    b.Navigation("Participante");
                });

            modelBuilder.Entity("AlanApiFilme.Model.Filme", b =>
                {
                    b.Navigation("Participantes");
                });

            modelBuilder.Entity("AlanApiFilme.Model.Participante", b =>
                {
                    b.Navigation("Filmes");
                });
#pragma warning restore 612, 618
        }
    }
}
