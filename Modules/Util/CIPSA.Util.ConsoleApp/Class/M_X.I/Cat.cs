using CIPSA.Util.ConsoleApp.Enum;

namespace CIPSA.Util.ConsoleApp.Class.M_X.I
{
    public class Cat : Animal
    {
        #region Properties
        public string Raza { get; set; }
        #endregion

        #region Ctors
        public Cat()
            : base()
        {
            Raza = string.Empty;
        }

        public Cat(string raza, string scientificName, FeedingEnum alimentacion, int velocidad)
            : base(scientificName, alimentacion, velocidad)
        {
            Raza = raza;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Raza: {Raza}, {base.ToString()}";
        }
        #endregion
    }
}
