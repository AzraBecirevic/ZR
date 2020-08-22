using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventiApplication.WebAPI.Migrations
{
    public partial class Prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipKarte",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipKarte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipProstoraOdrzavanja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipProstoraOdrzavanja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    DrzavaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzava",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    GradId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    Uloga = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrator_Grad_GradId",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    GradId = table.Column<int>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    Slika = table.Column<byte[]>(nullable: true),
                    SlikaThumb = table.Column<byte[]>(nullable: true),
                    IsAktivan = table.Column<bool>(nullable: false),
                    Uloga = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnik_Grad_GradId",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Organizator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    GradId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    Uloga = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizator_Grad_GradId",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProstorOdrzavanja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    TipProstoraOdrzavanjaId = table.Column<int>(nullable: true),
                    GradId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProstorOdrzavanja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProstorOdrzavanja_Grad_GradId",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProstorOdrzavanja_TipProstoraOdrzavanja_TipProstoraOdrzavanjaId",
                        column: x => x.TipProstoraOdrzavanjaId,
                        principalTable: "TipProstoraOdrzavanja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prijateljstvo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikPosiljalacId = table.Column<int>(nullable: false),
                    KorisnikPrimalacId = table.Column<int>(nullable: false),
                    DatumSlanjaZahtjeva = table.Column<DateTime>(nullable: false),
                    IsPrihvaceno = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prijateljstvo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prijateljstvo_Korisnik_KorisnikPosiljalacId",
                        column: x => x.KorisnikPosiljalacId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prijateljstvo_Korisnik_KorisnikPrimalacId",
                        column: x => x.KorisnikPrimalacId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    DatumOdrzavanja = table.Column<DateTime>(nullable: false),
                    VrijemeOdrzavanja = table.Column<string>(nullable: true),
                    KategorijaId = table.Column<int>(nullable: true),
                    IsOdobren = table.Column<bool>(nullable: false),
                    IsOtkazan = table.Column<bool>(nullable: false),
                    OrganizatorId = table.Column<int>(nullable: false),
                    AdministratorId = table.Column<int>(nullable: true),
                    ProstorOdrzavanjaId = table.Column<int>(nullable: false),
                    Slika = table.Column<byte[]>(nullable: true),
                    SlikaThumb = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Administrator_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Event_Kategorija_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Event_Organizator_OrganizatorId",
                        column: x => x.OrganizatorId,
                        principalTable: "Organizator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_ProstorOdrzavanja_ProstorOdrzavanjaId",
                        column: x => x.ProstorOdrzavanjaId,
                        principalTable: "ProstorOdrzavanja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kupovina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupovina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kupovina_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kupovina_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    DatumLajka = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Like_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Like_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ocjena",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    OcjenaEventa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjena", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ocjena_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocjena_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PozivNaEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(nullable: false),
                    KorisnikPozivalacId = table.Column<int>(nullable: false),
                    KorisnikPozvaniId = table.Column<int>(nullable: false),
                    IsPrihvacen = table.Column<bool>(nullable: false),
                    IsOdbijen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PozivNaEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PozivNaEvent_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PozivNaEvent_Korisnik_KorisnikPozivalacId",
                        column: x => x.KorisnikPozivalacId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PozivNaEvent_Korisnik_KorisnikPozvaniId",
                        column: x => x.KorisnikPozvaniId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProdajaTip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipKarteId = table.Column<int>(nullable: true),
                    UkupnoKarataTip = table.Column<int>(nullable: false),
                    BrojProdatihKarataTip = table.Column<int>(nullable: false),
                    CijenaTip = table.Column<float>(nullable: false),
                    PostojeSjedista = table.Column<bool>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdajaTip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdajaTip_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdajaTip_TipKarte_TipKarteId",
                        column: x => x.TipKarteId,
                        principalTable: "TipKarte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recenzija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Komentar = table.Column<string>(nullable: true),
                    KupovinaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recenzija_Kupovina_KupovinaId",
                        column: x => x.KupovinaId,
                        principalTable: "Kupovina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KupovinaTip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KupovinaId = table.Column<int>(nullable: false),
                    BrojKarata = table.Column<int>(nullable: false),
                    Cijena = table.Column<float>(nullable: false),
                    ProdajaTipId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KupovinaTip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KupovinaTip_Kupovina_KupovinaId",
                        column: x => x.KupovinaId,
                        principalTable: "Kupovina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KupovinaTip_ProdajaTip_ProdajaTipId",
                        column: x => x.ProdajaTipId,
                        principalTable: "ProdajaTip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Karta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipKarteId = table.Column<int>(nullable: true),
                    Cijena = table.Column<float>(nullable: false),
                    KupovinaTipId = table.Column<int>(nullable: false),
                    DatumKupovine = table.Column<DateTime>(nullable: false),
                    QrCode = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Karta_KupovinaTip_KupovinaTipId",
                        column: x => x.KupovinaTipId,
                        principalTable: "KupovinaTip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Karta_TipKarte_TipKarteId",
                        column: x => x.TipKarteId,
                        principalTable: "TipKarte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sjediste",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojSjedista = table.Column<int>(nullable: false),
                    KartaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sjediste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sjediste_Karta_KartaId",
                        column: x => x.KartaId,
                        principalTable: "Karta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_GradId",
                table: "Administrator",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_AdministratorId",
                table: "Event",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_KategorijaId",
                table: "Event",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_OrganizatorId",
                table: "Event",
                column: "OrganizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_ProstorOdrzavanjaId",
                table: "Event",
                column: "ProstorOdrzavanjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaId",
                table: "Grad",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_KupovinaTipId",
                table: "Karta",
                column: "KupovinaTipId");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_TipKarteId",
                table: "Karta",
                column: "TipKarteId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_GradId",
                table: "Korisnik",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Kupovina_EventId",
                table: "Kupovina",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Kupovina_KorisnikId",
                table: "Kupovina",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KupovinaTip_KupovinaId",
                table: "KupovinaTip",
                column: "KupovinaId");

            migrationBuilder.CreateIndex(
                name: "IX_KupovinaTip_ProdajaTipId",
                table: "KupovinaTip",
                column: "ProdajaTipId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_EventId",
                table: "Like",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_KorisnikId",
                table: "Like",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_EventId",
                table: "Ocjena",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_KorisnikId",
                table: "Ocjena",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizator_GradId",
                table: "Organizator",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_PozivNaEvent_EventId",
                table: "PozivNaEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_PozivNaEvent_KorisnikPozivalacId",
                table: "PozivNaEvent",
                column: "KorisnikPozivalacId");

            migrationBuilder.CreateIndex(
                name: "IX_PozivNaEvent_KorisnikPozvaniId",
                table: "PozivNaEvent",
                column: "KorisnikPozvaniId");

            migrationBuilder.CreateIndex(
                name: "IX_Prijateljstvo_KorisnikPosiljalacId",
                table: "Prijateljstvo",
                column: "KorisnikPosiljalacId");

            migrationBuilder.CreateIndex(
                name: "IX_Prijateljstvo_KorisnikPrimalacId",
                table: "Prijateljstvo",
                column: "KorisnikPrimalacId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdajaTip_EventId",
                table: "ProdajaTip",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdajaTip_TipKarteId",
                table: "ProdajaTip",
                column: "TipKarteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProstorOdrzavanja_GradId",
                table: "ProstorOdrzavanja",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_ProstorOdrzavanja_TipProstoraOdrzavanjaId",
                table: "ProstorOdrzavanja",
                column: "TipProstoraOdrzavanjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_KupovinaId",
                table: "Recenzija",
                column: "KupovinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sjediste_KartaId",
                table: "Sjediste",
                column: "KartaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Ocjena");

            migrationBuilder.DropTable(
                name: "PozivNaEvent");

            migrationBuilder.DropTable(
                name: "Prijateljstvo");

            migrationBuilder.DropTable(
                name: "Recenzija");

            migrationBuilder.DropTable(
                name: "Sjediste");

            migrationBuilder.DropTable(
                name: "Karta");

            migrationBuilder.DropTable(
                name: "KupovinaTip");

            migrationBuilder.DropTable(
                name: "Kupovina");

            migrationBuilder.DropTable(
                name: "ProdajaTip");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "TipKarte");

            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Kategorija");

            migrationBuilder.DropTable(
                name: "Organizator");

            migrationBuilder.DropTable(
                name: "ProstorOdrzavanja");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "TipProstoraOdrzavanja");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
