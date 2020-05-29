using CIPSA.Util.ConsoleApp.Enum;

namespace CIPSA.Util.ConsoleApp.Class.M_X.I
{
    public class Dog : Animal
    {
        #region Properties
        public string Color { get; set; }
        #endregion

        #region Ctors
        public Dog()
            : base()
        {
            Color = string.Empty;
        }

        public Dog(string color, string scientificName, FeedingEnum feeding, int speed)
            : base(scientificName, feeding, speed)
        {
            Color = color;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Color: {Color}, {base.ToString()}";
        }
        #endregion
    }
}
