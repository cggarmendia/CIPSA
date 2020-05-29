using System.Collections.Generic;
using System.Linq;

namespace CIPSA.Util.ConsoleApp.Class.Common
{
    public class Academy
    {
        #region Properties
        public ICollection<Classroom> Classrooms { get; set; }
        #endregion

        #region Ctors
        public Academy()
        {
            Classrooms = new HashSet<Classroom>();
        }
        #endregion

        #region Methods

        public IEnumerable<string> GetAverageOfTheClassrooms()
        {
            int index = 1;
            return Classrooms.Select(aula => $"Aula-{index++}: {aula.GetExaminationNoteAverageOfStudents()}");
        }

        public decimal GetNumberOfAlumno(char sex)
        {
            return Classrooms.Sum(aula => aula.GetNumberOfStudents(sex));
        }

        #endregion
    }
}
