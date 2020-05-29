namespace CIPSA.Util.ConsoleApp.Class.M_X.III
{
    public class Donut
    {
        #region Properties
        public double Price { get; set; }
        public bool HasHole { get; set; }
        #endregion

        #region Ctors
        public Donut()
        {
            Price = double.MinValue;
            HasHole = true;
        }

        public Donut(double price, bool hasHole)
        {
            Price = price;
            HasHole = hasHole;
        }
        #endregion

        #region Methods        
        public override string ToString()
        {
            var hasHole = HasHole ? "Si" : "No";
            return $"Precio: {Price}, Lleva agujeros: {hasHole}.";
        }
        #endregion
    }
}
