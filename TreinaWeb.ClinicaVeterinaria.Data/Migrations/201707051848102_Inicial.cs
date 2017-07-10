namespace TreinaWeb.ClinicaVeterinaria.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animais",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Raca = c.String(nullable: false, maxLength: 50),
                        NomeDono = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.AnimalId);
            
            CreateTable(
                "dbo.Prontuarios",
                c => new
                    {
                        ProntuarioId = c.Int(nullable: false, identity: true),
                        DataHoraAtendimento = c.DateTime(nullable: false),
                        Observacoes = c.String(nullable: false, maxLength: 250),
                        medicoVetId = c.Int(nullable: false),
                        animalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProntuarioId)
                .ForeignKey("dbo.Animais", t => t.animalId, cascadeDelete: true)
                .ForeignKey("dbo.MedicosVeterinarios", t => t.medicoVetId, cascadeDelete: true)
                .Index(t => t.medicoVetId)
                .Index(t => t.animalId);
            
            CreateTable(
                "dbo.MedicosVeterinarios",
                c => new
                    {
                        MedicoVetId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150),
                        NumeroCRV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicoVetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prontuarios", "medicoVetId", "dbo.MedicosVeterinarios");
            DropForeignKey("dbo.Prontuarios", "animalId", "dbo.Animais");
            DropIndex("dbo.Prontuarios", new[] { "animalId" });
            DropIndex("dbo.Prontuarios", new[] { "medicoVetId" });
            DropTable("dbo.MedicosVeterinarios");
            DropTable("dbo.Prontuarios");
            DropTable("dbo.Animais");
        }
    }
}
