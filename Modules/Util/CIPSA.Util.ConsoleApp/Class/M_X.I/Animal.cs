using CIPSA.Util.ConsoleApp.Enum;

namespace CIPSA.Util.ConsoleApp.Class.M_X.I
{
    public class Animal
    {
        #region Properties
        public string ScientificName { get; set; }
        public FeedingEnum Feeding { get; set; }
        public int Speed { get; set; }
        #endregion

        #region Ctors
        public Animal()
        {
            ScientificName = "";
            Feeding = FeedingEnum.Desconocido;
            Speed = 0;
        }

        public Animal(string scientificName, FeedingEnum feeding, int speed)
        {
            ScientificName = scientificName;
            Feeding = feeding;
            Speed = speed;
        }
        #endregion

        #region Methods
        public string Run() {
            return Speed < 50 ? "Corre poco" : "Corre mucho";
        }

        public string Jump()
        {
            return Speed < 50 ? "Corre poco" : "Corre mucho";
        }

        public override string ToString()
        {
            return $"Nombre científico: {ScientificName}, Alimentación: {Feeding}, Velocidad: {Speed}.";
        }
        #endregion
    }
}
