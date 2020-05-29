namespace CIPSA.Util.ConsoleApp.Class.M_X.III
{
    public class Muffin
    {
        #region Properties
        public double Price { get; set; }
        public string SpecificName { get; set; }
        #endregion

        #region Ctors
        public Muffin()
        {
            Price = double.MinValue;
            SpecificName = string.Empty;
        }

        public Muffin(double price, string specificName)
        {
            Price = price;
            SpecificName = specificName;
        }
        #endregion

        #region Methods        
        public override string ToString()
        {
            return $"Precio: {Price}, Nombre específico: {SpecificName}.";
        }
        #endregion
    }
}
