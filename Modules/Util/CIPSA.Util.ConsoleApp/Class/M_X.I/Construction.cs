namespace CIPSA.Util.ConsoleApp.Class.M_X.I
{
    public class Construction
    {
        #region Properties
        public int Surface { get; set; }
        public int Plants { get; set; }
        public int Habitations { get; set; }
        #endregion

        #region Ctors
        public Construction()
        {
            Surface = 0;
            Plants = 0;
            Habitations = 0;
        }
        
        public Construction(int surface, int plants, int habitations)
        {
            Surface = surface;
            Plants = plants;
            Habitations = habitations;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Superficies: {Surface}, Plantas: {Plants}, Habitaciones: {Habitations}.";
        }
        #endregion
    }
}
