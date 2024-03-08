﻿// <auto-generated />
using System;
using HOTELNAPOLI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HOTELNAPOLI.Migrations
{
    [DbContext(typeof(HOTELNAPOLIContext))]
    partial class HOTELNAPOLIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HOTELNAPOLI.Models.Camere", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Descrizione")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Disponibilita")
                        .HasColumnType("bit");

                    b.Property<bool>("Doppia")
                        .HasColumnType("bit");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Camere");
                });

            modelBuilder.Entity("HOTELNAPOLI.Models.CheckoutViewModel", b =>
                {
                    b.Property<int>("PrenotazioneID")
                        .HasColumnType("int");

                    b.HasIndex("PrenotazioneID");

                    b.ToTable("CheckoutViewModel");
                });

            modelBuilder.Entity("HOTELNAPOLI.Models.Clienti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cellulare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Citta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodiceFiscale")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clienti");
                });

            modelBuilder.Entity("HOTELNAPOLI.Models.Login", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("HOTELNAPOLI.Models.Pensioni", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal?>("Prezzo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tipologia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Pensioni");
                });

            modelBuilder.Entity("HOTELNAPOLI.Models.Prenotazioni", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<double>("Acconto")
                        .HasColumnType("float");

                    b.Property<string>("Anno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataFineSoggiorno")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInizioSoggiorno")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrenotazione")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDCamera")
                        .HasColumnType("int");

                    b.Property<int>("IDCliente")
                        .HasColumnType("int");

                    b.Property<int>("IDPensione")
                        .HasColumnType("int");

                    b.Property<double>("Prezzo")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("IDCamera");

                    b.HasIndex("IDCliente");

                    b.HasIndex("IDPensione");

                    b.ToTable("Prenotazioni");
                });

            modelBuilder.Entity("HOTELNAPOLI.Models.Servizi", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DataRichiestaServizio")
                        .HasColumnType("datetime2");

                    b.Property<int>("Descrizione")
                        .HasColumnType("int");

                    b.Property<int>("IDPrenotazione")
                        .HasColumnType("int");

                    b.Property<double?>("Prezzo")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("IDPrenotazione");

                    b.ToTable("Servizi");
                });

            modelBuilder.Entity("HOTELNAPOLI.Models.CheckoutViewModel", b =>
                {
                    b.HasOne("HOTELNAPOLI.Models.Prenotazioni", "Prenotazione")
                        .WithMany()
                        .HasForeignKey("PrenotazioneID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prenotazione");
                });

            modelBuilder.Entity("HOTELNAPOLI.Models.Prenotazioni", b =>
                {
                    b.HasOne("HOTELNAPOLI.Models.Camere", "Camera")
                        .WithMany()
                        .HasForeignKey("IDCamera")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HOTELNAPOLI.Models.Clienti", "Cliente")
                        .WithMany()
                        .HasForeignKey("IDCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HOTELNAPOLI.Models.Pensioni", "Pensione")
                        .WithMany()
                        .HasForeignKey("IDPensione")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camera");

                    b.Navigation("Cliente");

                    b.Navigation("Pensione");
                });

            modelBuilder.Entity("HOTELNAPOLI.Models.Servizi", b =>
                {
                    b.HasOne("HOTELNAPOLI.Models.Prenotazioni", "Prenotazione")
                        .WithMany()
                        .HasForeignKey("IDPrenotazione")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prenotazione");
                });
#pragma warning restore 612, 618
        }
    }
}
