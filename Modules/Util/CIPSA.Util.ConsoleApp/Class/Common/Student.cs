using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CIPSA.Util.ConsoleApp.Class.Common
{
    public class Student
    {
        #region Properties
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int ExaminationNote { get; set; }
        public char Sex { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        #endregion

        #region Ctors
        public Student()
        {
            Name = string.Empty;
            LastName = string.Empty;
            Age = 0;
            ExaminationNote = 0;
            Sex = ' ';
            Subjects = new HashSet<Subject>();
        }

        public Student(string name, string lastName, int age)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            ExaminationNote = 0;
            Sex = ' ';
            Subjects = new HashSet<Subject>();
        }

        public Student(string name, string lastName, int age, int examinationNote)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            ExaminationNote = examinationNote;
            Sex = ' ';
            Subjects = new HashSet<Subject>();
        }

        public Student(string name, string lastName, int age, int examinationNote, char sex)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            ExaminationNote = examinationNote;
            Sex = sex;
            Subjects = new HashSet<Subject>();
        }
        #endregion

        #region Methods
        public StringBuilder GetSubjectsStringBuilder() {
            var show = new StringBuilder();
            show.AppendLine("------Asignaturas------");
            var index = 1;
            Subjects.ToList().ForEach(subject => show.AppendLine($"{index++} - {subject}"));
            return show;
        }

        public override string ToString()
        {
            return ExaminationNote == 0
                ? $"Nombre: {Name}, Apellidos: {LastName}, Edad: {Age}"
                : Sex == ' ' 
                    ? $"Nombre: {Name}, Apellidos: {LastName}, Edad: {Age}, Nota de examen: {ExaminationNote}"
                    : $"Nombre: {Name}, Apellidos: {LastName}, Edad: {Age}, Nota de examen: {ExaminationNote}, Sexo: {Sex}";
        }
        #endregion
    }
}
