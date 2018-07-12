namespace FluentApiUniver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Curs", "Student_ID", "dbo.Students");
            DropIndex("dbo.Curs", new[] { "Student_ID" });
            CreateTable(
                "dbo.StudentCUrses",
                c => new
                    {
                        cursID = c.Int(nullable: false),
                        studentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.cursID, t.studentID })
                .ForeignKey("dbo.Students", t => t.cursID, cascadeDelete: true)
                .ForeignKey("dbo.Curs", t => t.studentID, cascadeDelete: true)
                .Index(t => t.cursID)
                .Index(t => t.studentID);
            
            DropColumn("dbo.Curs", "Student_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Curs", "Student_ID", c => c.Int());
            DropForeignKey("dbo.StudentCUrses", "studentID", "dbo.Curs");
            DropForeignKey("dbo.StudentCUrses", "cursID", "dbo.Students");
            DropIndex("dbo.StudentCUrses", new[] { "studentID" });
            DropIndex("dbo.StudentCUrses", new[] { "cursID" });
            DropTable("dbo.StudentCUrses");
            CreateIndex("dbo.Curs", "Student_ID");
            AddForeignKey("dbo.Curs", "Student_ID", "dbo.Students", "idStudent");
        }
    }
}
