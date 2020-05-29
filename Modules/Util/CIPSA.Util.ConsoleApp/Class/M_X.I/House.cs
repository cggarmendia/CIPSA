namespace CIPSA.Util.ConsoleApp.Class.M_X.I
{
    public class House : Construction
    {
        #region Properties
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        #endregion

        #region Ctors
        public House()
            : base()
        {
            Bedrooms = 0;
            Bathrooms = 0;
        }

        public House(int bedrooms, int bathrooms, int surface, int plants, int habitations)
            : base(surface, plants, habitations)
        {
            Bedrooms = bedrooms;
            Bathrooms = bathrooms;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Dormitorios: {Bedrooms}, Baños: {Bathrooms}, {base.ToString()}";
        }
        #endregion
    }
}
