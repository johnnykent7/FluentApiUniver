namespace FluentApiUniver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Curs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Student_ID = c.Int(),
                        GetProfesor_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.Student_ID)
                .ForeignKey("dbo.Profesors", t => t.GetProfesor_ID)
                .Index(t => t.Student_ID)
                .Index(t => t.GetProfesor_ID);
            
            CreateTable(
                "dbo.Grupas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                        Profesor_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Profesors", t => t.Profesor_ID)
                .Index(t => t.Profesor_ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GetGrupa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Grupas", t => t.GetGrupa_ID)
                .Index(t => t.GetGrupa_ID);
            
            CreateTable(
                "dbo.Profesors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GrupaCurs",
                c => new
                    {
                        Grupa_ID = c.Int(nullable: false),
                        Curs_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Grupa_ID, t.Curs_ID })
                .ForeignKey("dbo.Grupas", t => t.Grupa_ID, cascadeDelete: true)
                .ForeignKey("dbo.Curs", t => t.Curs_ID, cascadeDelete: true)
                .Index(t => t.Grupa_ID)
                .Index(t => t.Curs_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grupas", "Profesor_ID", "dbo.Profesors");
            DropForeignKey("dbo.Curs", "GetProfesor_ID", "dbo.Profesors");
            DropForeignKey("dbo.Students", "GetGrupa_ID", "dbo.Grupas");
            DropForeignKey("dbo.Curs", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.GrupaCurs", "Curs_ID", "dbo.Curs");
            DropForeignKey("dbo.GrupaCurs", "Grupa_ID", "dbo.Grupas");
            DropIndex("dbo.GrupaCurs", new[] { "Curs_ID" });
            DropIndex("dbo.GrupaCurs", new[] { "Grupa_ID" });
            DropIndex("dbo.Students", new[] { "GetGrupa_ID" });
            DropIndex("dbo.Grupas", new[] { "Profesor_ID" });
            DropIndex("dbo.Curs", new[] { "GetProfesor_ID" });
            DropIndex("dbo.Curs", new[] { "Student_ID" });
            DropTable("dbo.GrupaCurs");
            DropTable("dbo.Profesors");
            DropTable("dbo.Students");
            DropTable("dbo.Grupas");
            DropTable("dbo.Curs");
        }
    }
}
