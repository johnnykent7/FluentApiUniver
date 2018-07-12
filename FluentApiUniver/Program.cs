using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FluentApiUniver
{

    public class Profesor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Grupa> GetGrupas { get; set; }
        public List<Curs> GetCurs { get; set; }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Curs> GetCurs { get; set; }
        public Grupa GetGrupa { get; set; }
    }

    public class Curs
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Grupa> GetGrupas { get; set; }
        public Profesor GetProfesor { get; set; }
        public int IDProfesor { get; set; }
    }

    public class Grupa
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public List<Student> GetStudents { get; set; }
        public List<Curs> GetCurses { get; set; }
    }

    public class FluentContext : DbContext
    {
        public DbSet<Profesor> GetProfesors { get; set; }
        public DbSet<Student> GetStudents { get; set; }
        public DbSet<Curs> GetCurs { get; set; }
        public DbSet<Grupa> GetGrupas { get; set; }
        public FluentContext()
            :base("name=DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Profesor>()
                .HasKey(p=>p.ID)
                .Property(p => p.Name)
                .HasColumnName("ProfesorName")
                .HasMaxLength(255);

            modelBuilder
                .Entity<Profesor>()
                .Property(p => p.ID)
                .HasColumnName("profesorID")
                .HasColumnOrder(2);

            modelBuilder
                .Entity<Profesor>()
                .HasMany(p => p.GetCurs)
                .WithRequired(c => c.GetProfesor)
                .HasForeignKey(c => c.IDProfesor);

            modelBuilder
                .Entity<Profesor>()
                .HasMany(p => p.GetGrupas);


                
                

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
