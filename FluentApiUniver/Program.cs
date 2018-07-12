using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }

    public class Grupa
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public List<Student> GetStudents { get; set; }
        public List<Curs> GetCurses { get; set; }
    }

    

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
