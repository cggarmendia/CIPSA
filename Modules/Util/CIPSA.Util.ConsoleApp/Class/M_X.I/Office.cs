namespace CIPSA.Util.ConsoleApp.Class.M_X.I
{
    public class Office : Construction
    {
        #region Properties
        public int FireExtinguishers { get; set; }
        public int Phones { get; set; }
        #endregion
        
        #region Ctors
        public Office()
            : base()
        {
            FireExtinguishers = 0;
            Phones = 0;
        }

        public Office(int fireExtinguishers, int phones, int surface, int plants, int habitations)
            : base(surface, plants, habitations)
        {
            FireExtinguishers = fireExtinguishers;
            Phones = phones;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Extintores: {FireExtinguishers}, Teléfonos: {Phones}, {base.ToString()}";
        }
        #endregion
    }
}
