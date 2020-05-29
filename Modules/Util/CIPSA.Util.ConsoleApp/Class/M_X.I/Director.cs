namespace CIPSA.Util.ConsoleApp.Class.M_X.I
{
    public class Director : Person
    {
        #region Properties
        public string College { get; set; }
        public int Seniority { get; set; }
        #endregion

        #region Ctors
        public Director()
            : base()
        {
            College = string.Empty;
            Seniority = 0;
        }

        public Director(string name, string lastName, string college, int seniority)
            : base(name, lastName)
        {
            College = college;
            Seniority = seniority;
        }
        #endregion

        #region Methods
        public override string GetInfo()
        {
            return $"Nombre: {Name}, Apellidos: {LastName}, Antigüeda: {Seniority}, Colegio: {College}";
        }
        #endregion
    }
}
