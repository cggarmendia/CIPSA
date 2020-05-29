using CIPSA.Util.ConsoleApp.Enum.M_X.III;

namespace CIPSA.Util.ConsoleApp.Class.M_X.III
{
    public class Cake
    {
        #region Properties
        public SizeEnum Size { get; set; }
        public int NumberOfCandles { get; set; }
        public string CustomText { get; set; }
        #endregion

        #region Ctors
        public Cake()
        {
            Size = SizeEnum.Mediano;
            NumberOfCandles = 0;
            CustomText = string.Empty;
        }

        public Cake(SizeEnum size, int numberOfCandles, string customText)
        {
            Size = size;
            NumberOfCandles = numberOfCandles;
            CustomText = customText;
        }
        #endregion

        #region Methods        
        public override string ToString()
        {
            return $"Texto personalizado: {CustomText}, # de velas: {NumberOfCandles}, Tamaño: {Size}.";
        }
        #endregion
    }
}
