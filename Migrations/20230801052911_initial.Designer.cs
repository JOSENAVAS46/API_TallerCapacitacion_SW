﻿// <auto-generated />
using System;
using API_TallerCapacitacion_SW.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_TallerCapacitacion_SW.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230801052911_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.6.23329.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_TallerCapacitacion_SW.Models.Asistencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("ParticipanteId")
                        .HasColumnType("int");

                    b.Property<int>("TallerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParticipanteId");

                    b.HasIndex("TallerId");

                    b.ToTable("Asistencias");
                });

            modelBuilder.Entity("API_TallerCapacitacion_SW.Models.Participante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Participantes");
                });

            modelBuilder.Entity("API_TallerCapacitacion_SW.Models.Taller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CupoMaximo")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Talleres");
                });

            modelBuilder.Entity("ParticipanteTaller", b =>
                {
                    b.Property<int>("ParticipanteId")
                        .HasColumnType("int");

                    b.Property<int>("TallerId")
                        .HasColumnType("int");

                    b.HasKey("ParticipanteId", "TallerId");

                    b.HasIndex("TallerId");

                    b.ToTable("ParticipanteTaller");
                });

            modelBuilder.Entity("API_TallerCapacitacion_SW.Models.Asistencia", b =>
                {
                    b.HasOne("API_TallerCapacitacion_SW.Models.Participante", "Participante")
                        .WithMany("Asistencias")
                        .HasForeignKey("ParticipanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_TallerCapacitacion_SW.Models.Taller", "Taller")
                        .WithMany("Asistencias")
                        .HasForeignKey("TallerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participante");

                    b.Navigation("Taller");
                });

            modelBuilder.Entity("ParticipanteTaller", b =>
                {
                    b.HasOne("API_TallerCapacitacion_SW.Models.Participante", null)
                        .WithMany()
                        .HasForeignKey("ParticipanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_TallerCapacitacion_SW.Models.Taller", null)
                        .WithMany()
                        .HasForeignKey("TallerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API_TallerCapacitacion_SW.Models.Participante", b =>
                {
                    b.Navigation("Asistencias");
                });

            modelBuilder.Entity("API_TallerCapacitacion_SW.Models.Taller", b =>
                {
                    b.Navigation("Asistencias");
                });
#pragma warning restore 612, 618
        }
    }
}