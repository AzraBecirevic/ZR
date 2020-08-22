using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventiApplication.WebAPI.Database
{
    public partial class MojContext : DbContext
    {
        public MojContext()
        {
        }

        public MojContext(DbContextOptions<MojContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<Karta> Karta { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Kupovina> Kupovina { get; set; }
        public virtual DbSet<KupovinaTip> KupovinaTip { get; set; }
        public virtual DbSet<Like> Like { get; set; }
        public virtual DbSet<Organizator> Organizator { get; set; }
        public virtual DbSet<PozivNaEvent> PozivNaEvent { get; set; }
        public virtual DbSet<Prijateljstvo> Prijateljstvo { get; set; }
        public virtual DbSet<ProdajaTip> ProdajaTip { get; set; }
        public virtual DbSet<ProstorOdrzavanja> ProstorOdrzavanja { get; set; }  
        public virtual DbSet<Recenzija> Recenzija { get; set; }
        public virtual DbSet<Sjediste> Sjediste { get; set; }
     
        public virtual DbSet<TipProstoraOdrzavanja> TipProstoraOdrzavanja { get; set; }
        public virtual DbSet<TipKarte> TipKarte { get; set; }
        public virtual DbSet<Kategorija> Kategorija { get; set; }
        public virtual DbSet<Ocjena> Ocjena { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasIndex(e => e.GradId);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Administrator)
                    .HasForeignKey(d => d.GradId);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasIndex(e => e.AdministratorId);

                entity.HasIndex(e => e.OrganizatorId);

                entity.HasIndex(e => e.ProstorOdrzavanjaId);

                entity.HasOne(d => d.Administrator)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.AdministratorId);

                entity.HasOne(d => d.Organizator)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.OrganizatorId);

                entity.HasOne(d => d.ProstorOdrzavanja)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.ProstorOdrzavanjaId);
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.HasIndex(e => e.DrzavaId);

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Grad)
                    .HasForeignKey(d => d.DrzavaId);
            });


            modelBuilder.Entity<Karta>(entity =>
            {
                entity.HasIndex(e => e.KupovinaTipId);

                entity.HasOne(d => d.KupovinaTip)
                    .WithMany(p => p.Karta)
                    .HasForeignKey(d => d.KupovinaTipId);
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.HasIndex(e => e.GradId);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.GradId);
            });

            modelBuilder.Entity<Kupovina>(entity =>
            {
                entity.HasIndex(e => e.EventId);

                entity.HasIndex(e => e.KorisnikId);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Kupovina)
                    .HasForeignKey(d => d.EventId);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Kupovina)
                    .HasForeignKey(d => d.KorisnikId);
            });

            modelBuilder.Entity<KupovinaTip>(entity =>
            {
                entity.HasIndex(e => e.KupovinaId);

                entity.HasIndex(e => e.ProdajaTipId);

                entity.HasOne(d => d.Kupovina)
                    .WithMany(p => p.KupovinaTip)
                    .HasForeignKey(d => d.KupovinaId);

                entity.HasOne(d => d.ProdajaTip)
                    .WithMany(p => p.KupovinaTip)
                    .HasForeignKey(d => d.ProdajaTipId);
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasIndex(e => e.EventId);

                entity.HasIndex(e => e.KorisnikId);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Like)
                    .HasForeignKey(d => d.EventId);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Like)
                    .HasForeignKey(d => d.KorisnikId);
            });

            modelBuilder.Entity<Organizator>(entity =>
            {
                entity.HasIndex(e => e.GradId);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Organizator)
                    .HasForeignKey(d => d.GradId);
            });

            modelBuilder.Entity<PozivNaEvent>(entity =>
            {
                entity.HasIndex(e => e.KorisnikPozivalacId);

                entity.HasIndex(e => e.KorisnikPozvaniId);

                entity.HasOne(d => d.KorisnikPozivalac)
                    .WithMany(p => p.PozivNaEventKorisnikPozivalac)
                    .HasForeignKey(d => d.KorisnikPozivalacId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.KorisnikPozvani)
                    .WithMany(p => p.PozivNaEventKorisnikPozvani)
                    .HasForeignKey(d => d.KorisnikPozvaniId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Prijateljstvo>(entity =>
            {
                entity.HasIndex(e => e.KorisnikPosiljalacId);

                entity.HasIndex(e => e.KorisnikPrimalacId);

                entity.HasOne(d => d.KorisnikPosiljalac)
                    .WithMany(p => p.PrijateljstvoKorisnikPosiljalac)
                    .HasForeignKey(d => d.KorisnikPosiljalacId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.KorisnikPrimalac)
                    .WithMany(p => p.PrijateljstvoKorisnikPrimalac)
                    .HasForeignKey(d => d.KorisnikPrimalacId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProdajaTip>(entity =>
            {
                entity.HasIndex(e => e.EventId);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.ProdajaTip)
                    .HasForeignKey(d => d.EventId);
            });

            modelBuilder.Entity<ProstorOdrzavanja>(entity =>
            {
                entity.HasIndex(e => e.GradId);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.ProstorOdrzavanja)
                    .HasForeignKey(d => d.GradId);
            });

       

            modelBuilder.Entity<Recenzija>(entity =>
            {
                entity.HasIndex(e => e.KupovinaId);

                entity.HasOne(d => d.Kupovina)
                    .WithMany(p => p.Recenzija)
                    .HasForeignKey(d => d.KupovinaId);
            });

            modelBuilder.Entity<Sjediste>(entity =>
            {
                entity.HasIndex(e => e.KartaId);

                entity.HasOne(d => d.Karta)
                    .WithMany(p => p.Sjediste)
                    .HasForeignKey(d => d.KartaId);
            });

        

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
