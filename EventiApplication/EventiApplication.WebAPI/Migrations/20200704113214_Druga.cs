using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventiApplication.WebAPI.Migrations
{
    public partial class Druga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Drzava",
                columns: new[] { "Id", "Naziv" },
                values: new object[] { 1, "BiH" });

            migrationBuilder.InsertData(
                table: "Kategorija",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Muzika" },
                    { 2, "Kultura" },
                    { 3, "Sport" }
                });

            migrationBuilder.InsertData(
                table: "TipKarte",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "VIP" },
                    { 2, "Parter" },
                    { 3, "Tribina" },
                    { 4, "Obicna" }
                });

            migrationBuilder.InsertData(
                table: "TipProstoraOdrzavanja",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Sala" },
                    { 2, "Dvorana" },
                    { 3, "Stadion" }
                });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "Id", "DrzavaId", "Naziv" },
                values: new object[] { 1, 1, "Sarajevo" });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "Id", "DrzavaId", "Naziv" },
                values: new object[] { 2, 1, "Mostar" });

            migrationBuilder.InsertData(
                table: "Administrator",
                columns: new[] { "Id", "Email", "GradId", "Ime", "PasswordHash", "PasswordSalt", "Prezime", "Telefon", "Uloga", "Username" },
                values: new object[] { 1, "admin1@mail.com", 1, "Admin1", "yxMZirz3bBUdgji6aVYI8bkBHXs=", "vFyyMXXLf87wKxdw0gH3Dg==", "Prezime1", "063444555", "Administrator", "desktop" });

            migrationBuilder.InsertData(
                table: "Korisnik",
                columns: new[] { "Id", "Adresa", "Email", "GradId", "Ime", "IsAktivan", "PasswordHash", "PasswordSalt", "PostanskiBroj", "Prezime", "Slika", "SlikaThumb", "Telefon", "Uloga", "Username" },
                values: new object[,]
                {
                    { 1, "Adresa1", "testiranjeslanjamaila@gmail.com", 1, "Korisnik1", true, "wJra1wIk1iH7fLYbNEF3u8c5Q4k=", "4ep+DNUB0ML5U4Dsy3+kiw==", "71000", "Prezime1", null, null, "061222333", "Korisnik", "mobile" },
                    { 2, "Adresa2", "testiranjeslanjamaila@gmail.com", 1, "Korisnik2", true, "tNSptZALZQ1pTULttvZNg34WI3Y=", "0E60R1/uuINBbNREFJqXQQ==", "71000", "Prezime2", null, null, "062333444", "Korisnik", "Korisnik2" },
                    { 3, "Adresa3", "testiranjeslanjamaila@gmail.com", 1, "Korisnik3", true, "gsfJmTdTY1dIr03VnSa5o/W8K44=", "Qs66TbGxDGBQOX96QSojQQ==", "71000", "Prezime3", null, null, "062888999", "Korisnik", "Korisnik3" },
                    { 4, "Adresa4", "testiranjeslanjamaila@gmail.com", 1, "Korisnik4", true, "h6mnNJjq2sCSkw8wVOiKaklki08=", "og2x/h6oRC9CvFOPCUk33A==", "71000", "Prezime4", null, null, "061222333", "Korisnik", "Korisnik4" },
                    { 5, "Adresa5", "testiranjeslanjamaila@gmail.com", 1, "Korisnik5", true, "788P+omp+lKbUHtVmrpAwiS8MtE=", "og2x/h6oRC9CvFOPCUk33A==", "71000", "Prezime5", null, null, "061666333", "Korisnik", "Korisnik5" }
                });

            migrationBuilder.InsertData(
                table: "Organizator",
                columns: new[] { "Id", "Email", "GradId", "Naziv", "PasswordHash", "PasswordSalt", "Telefon", "Uloga", "Username" },
                values: new object[,]
                {
                    { 1, "org1@mail.com", 1, "Org1", null, null, "061222222", "Organizator", null },
                    { 2, "org2@mail.com", 1, "Org2", null, null, "061555555", "Organizator", null },
                    { 3, "org3@mail.com", 1, "Org3", null, null, "061333333", "Organizator", null }
                });

            migrationBuilder.InsertData(
                table: "ProstorOdrzavanja",
                columns: new[] { "Id", "Adresa", "GradId", "Naziv", "TipProstoraOdrzavanjaId" },
                values: new object[,]
                {
                    { 1, "Obala Kulina bana 9, Sarajevo", 1, "Narodno pozorište Sarajevo", 1 },
                    { 2, "Alipašina bb, Sarajevo 71000", 1, "Zetra", 2 },
                    { 3, "Zvornička 27 Sarajevo 71000", 1, "Stadion Grbavica", 3 }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "AdministratorId", "DatumOdrzavanja", "IsOdobren", "IsOtkazan", "KategorijaId", "Naziv", "Opis", "OrganizatorId", "ProstorOdrzavanjaId", "Slika", "SlikaThumb", "VrijemeOdrzavanja" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 8, 3, 13, 32, 13, 508, DateTimeKind.Local).AddTicks(8630), true, false, 2, "Event1", "...", 1, 1, null, null, "20:00" },
                    { 2, 1, new DateTime(2020, 8, 3, 13, 32, 13, 512, DateTimeKind.Local).AddTicks(2943), true, false, 1, "Event2", "...", 2, 2, null, null, "20:00" },
                    { 3, 1, new DateTime(2020, 8, 3, 13, 32, 13, 512, DateTimeKind.Local).AddTicks(3091), true, false, 3, "Event3", "...", 1, 3, null, null, "20:00" }
                });

            migrationBuilder.InsertData(
                table: "Prijateljstvo",
                columns: new[] { "Id", "DatumSlanjaZahtjeva", "IsPrihvaceno", "KorisnikPosiljalacId", "KorisnikPrimalacId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 7, 4, 13, 32, 13, 512, DateTimeKind.Local).AddTicks(8497), true, 1, 2 },
                    { 2, new DateTime(2020, 7, 4, 13, 32, 13, 512, DateTimeKind.Local).AddTicks(9367), true, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Kupovina",
                columns: new[] { "Id", "EventId", "KorisnikId" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "PozivNaEvent",
                columns: new[] { "Id", "EventId", "IsOdbijen", "IsPrihvacen", "KorisnikPozivalacId", "KorisnikPozvaniId" },
                values: new object[,]
                {
                    { 1, 1, false, false, 2, 1 },
                    { 2, 2, false, false, 1, 2 },
                    { 3, 3, false, true, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProdajaTip",
                columns: new[] { "Id", "BrojProdatihKarataTip", "CijenaTip", "EventId", "PostojeSjedista", "TipKarteId", "UkupnoKarataTip" },
                values: new object[,]
                {
                    { 1, 0, 15f, 1, true, 1, 100 },
                    { 2, 1, 10f, 2, false, 2, 1000 },
                    { 3, 0, 10f, 3, false, 3, 1000 }
                });

            migrationBuilder.InsertData(
                table: "KupovinaTip",
                columns: new[] { "Id", "BrojKarata", "Cijena", "KupovinaId", "ProdajaTipId" },
                values: new object[] { 1, 1, 10f, 1, 2 });

            migrationBuilder.InsertData(
                table: "Karta",
                columns: new[] { "Id", "Cijena", "DatumKupovine", "KupovinaTipId", "QrCode", "TipKarteId" },
                values: new object[] { 1, 10f, new DateTime(2020, 7, 4, 13, 32, 13, 513, DateTimeKind.Local).AddTicks(7831), 1, null, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Grad",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Karta",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Organizator",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PozivNaEvent",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PozivNaEvent",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PozivNaEvent",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prijateljstvo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prijateljstvo",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProdajaTip",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProdajaTip",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipKarte",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "KupovinaTip",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipKarte",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipKarte",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kategorija",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kategorija",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kupovina",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizator",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProdajaTip",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProstorOdrzavanja",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProstorOdrzavanja",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipKarte",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipProstoraOdrzavanja",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipProstoraOdrzavanja",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kategorija",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizator",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProstorOdrzavanja",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Grad",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipProstoraOdrzavanja",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drzava",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
