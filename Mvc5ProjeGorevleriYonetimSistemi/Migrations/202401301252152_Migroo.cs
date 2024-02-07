namespace Mvc5ProjeGorevleriYonetimSistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migroo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonelBilgileris",
                c => new
                    {
                        PersonelBilgileriId = c.Int(nullable: false, identity: true),
                        Eposta = c.String(),
                        Sifre = c.String(maxLength: 25),
                        Yetki = c.String(maxLength: 15),
                        AdSoyad = c.String(maxLength: 50),
                        PersonelGörseli = c.String(),
                        TCNO = c.String(maxLength: 15),
                        Departman = c.String(),
                        Gorev = c.String(maxLength: 25),
                        PozisyonAciklama = c.String(),
                        TelNo = c.String(maxLength: 15),
                        Adres = c.String(),
                        MedeniHal = c.String(maxLength: 25),
                        YakinBilgisi = c.String(maxLength: 25),
                        YakinTC = c.String(maxLength: 25),
                        YakinAdSoyad = c.String(maxLength: 25),
                        YakinTel = c.String(maxLength: 25),
                        DogumTarihi = c.DateTime(nullable: false),
                        IseGirisTarihi = c.DateTime(),
                    })
                .PrimaryKey(t => t.PersonelBilgileriId);
            
            CreateTable(
                "dbo.PersonelProjeleris",
                c => new
                    {
                        PersonelProjeId = c.Int(nullable: false, identity: true),
                        ProjeBaslik = c.String(maxLength: 150),
                        ProjeAciklama = c.String(),
                        OlusturmaTarihi = c.DateTime(nullable: false),
                        OncelikDurumu = c.String(maxLength: 25),
                        TamamlanmaOrani = c.Int(nullable: false),
                        TamamlanmaTarihi = c.DateTime(),
                        TamamlanmaDurumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonelProjeId);
            
            CreateTable(
                "dbo.PersonelProjeleriPersonelBilgileris",
                c => new
                    {
                        PersonelProjeleri_PersonelProjeId = c.Int(nullable: false),
                        PersonelBilgileri_PersonelBilgileriId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonelProjeleri_PersonelProjeId, t.PersonelBilgileri_PersonelBilgileriId })
                .ForeignKey("dbo.PersonelProjeleris", t => t.PersonelProjeleri_PersonelProjeId, cascadeDelete: true)
                .ForeignKey("dbo.PersonelBilgileris", t => t.PersonelBilgileri_PersonelBilgileriId, cascadeDelete: true)
                .Index(t => t.PersonelProjeleri_PersonelProjeId)
                .Index(t => t.PersonelBilgileri_PersonelBilgileriId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonelProjeleriPersonelBilgileris", "PersonelBilgileri_PersonelBilgileriId", "dbo.PersonelBilgileris");
            DropForeignKey("dbo.PersonelProjeleriPersonelBilgileris", "PersonelProjeleri_PersonelProjeId", "dbo.PersonelProjeleris");
            DropIndex("dbo.PersonelProjeleriPersonelBilgileris", new[] { "PersonelBilgileri_PersonelBilgileriId" });
            DropIndex("dbo.PersonelProjeleriPersonelBilgileris", new[] { "PersonelProjeleri_PersonelProjeId" });
            DropTable("dbo.PersonelProjeleriPersonelBilgileris");
            DropTable("dbo.PersonelProjeleris");
            DropTable("dbo.PersonelBilgileris");
        }
    }
}
