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
                        cursID = c.Int(nullable: false, identity: true),
                        cursName = c.String(),
                        IDProfesor = c.Int(nullable: false),
                        Student_ID = c.Int(),
                    })
                .PrimaryKey(t => t.cursID)
                .ForeignKey("dbo.Students", t => t.Student_ID)
                .ForeignKey("dbo.Profesors", t => t.IDProfesor, cascadeDelete: true)
                .Index(t => t.IDProfesor)
                .Index(t => t.Student_ID);
            
            CreateTable(
                "dbo.Grupas",
                c => new
                    {
                        grupaID = c.Int(nullable: false, identity: true),
                        grupaNume = c.String(maxLength: 255),
                        Profesor_ID = c.Int(),
                    })
                .PrimaryKey(t => t.grupaID)
                .ForeignKey("dbo.Profesors", t => t.Profesor_ID)
                .Index(t => t.Profesor_ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        idStudent = c.Int(nullable: false, identity: true),
                        studentName = c.String(maxLength: 255),
                        IDGrupa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idStudent)
                .ForeignKey("dbo.Grupas", t => t.IDGrupa, cascadeDelete: true)
                .Index(t => t.IDGrupa);
            
            CreateTable(
                "dbo.Profesors",
                c => new
                    {
                        profesorID = c.Int(nullable: false, identity: true),
                        ProfesorName = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.profesorID);
            
            CreateTable(
                "dbo.CursGrupa",
                c => new
                    {
                        grupaID = c.Int(nullable: false),
                        cursID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.grupaID, t.cursID })
                .ForeignKey("dbo.Curs", t => t.grupaID, cascadeDelete: true)
                .ForeignKey("dbo.Grupas", t => t.cursID, cascadeDelete: true)
                .Index(t => t.grupaID)
                .Index(t => t.cursID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grupas", "Profesor_ID", "dbo.Profesors");
            DropForeignKey("dbo.Curs", "IDProfesor", "dbo.Profesors");
            DropForeignKey("dbo.CursGrupa", "cursID", "dbo.Grupas");
            DropForeignKey("dbo.CursGrupa", "grupaID", "dbo.Curs");
            DropForeignKey("dbo.Students", "IDGrupa", "dbo.Grupas");
            DropForeignKey("dbo.Curs", "Student_ID", "dbo.Students");
            DropIndex("dbo.CursGrupa", new[] { "cursID" });
            DropIndex("dbo.CursGrupa", new[] { "grupaID" });
            DropIndex("dbo.Students", new[] { "IDGrupa" });
            DropIndex("dbo.Grupas", new[] { "Profesor_ID" });
            DropIndex("dbo.Curs", new[] { "Student_ID" });
            DropIndex("dbo.Curs", new[] { "IDProfesor" });
            DropTable("dbo.CursGrupa");
            DropTable("dbo.Profesors");
            DropTable("dbo.Students");
            DropTable("dbo.Grupas");
            DropTable("dbo.Curs");
        }
    }
}
