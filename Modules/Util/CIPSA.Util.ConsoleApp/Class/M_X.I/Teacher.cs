namespace CIPSA.Util.ConsoleApp.Class.M_X.I
{
    public class Teacher : Person
    {
        #region Properties
        public string AssignedClassroom { get; set; }
        public bool IsTutor { get; set; }
        #endregion

        #region Ctors
        public Teacher()
            : base()
        {
            AssignedClassroom = string.Empty;
            IsTutor = false;
        }

        public Teacher(string name, string lastName, string assignedClassroom, bool isTutor)
            : base(name, lastName)
        {
            AssignedClassroom = assignedClassroom;
            IsTutor = isTutor;
        }
        #endregion

        #region Methods
        public override string GetInfo()
        {
            return $"Nombre: {Name}, Apellidos: {LastName}, Es tutor: {GetIsTutorText()}, Aula asignada: {AssignedClassroom}.";
        }

        private string GetIsTutorText() {
            return IsTutor ? "Si" : "No";
        }
        #endregion
    }
}
