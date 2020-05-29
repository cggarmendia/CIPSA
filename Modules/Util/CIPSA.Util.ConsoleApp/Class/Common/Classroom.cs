using System.Collections.Generic;
using System.Linq;

namespace CIPSA.Util.ConsoleApp.Class.Common
{
    public class Classroom
    {
        #region Properties
        public ICollection<Student> Students { get; set; }
        #endregion

        #region Ctors
        public Classroom()
        {
            Students = new HashSet<Student>();
        }
        #endregion

        #region Methods

        public decimal GetExaminationNoteAverageOfStudents() {
            return Students.Sum(alumno=> alumno.ExaminationNote)/Students.Count();
        }

        public decimal GetNumberOfStudents(char sex)
        {
            return Students.Count(alumno => alumno.Sex == sex);
        }

        #endregion
    }
}
