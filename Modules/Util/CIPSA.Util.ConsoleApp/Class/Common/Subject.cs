namespace CIPSA.Util.ConsoleApp.Class.Common
{
    public class Subject
    {
        #region Properties
        public string Name { get; set; }
        public string Area { get; set; }
        #endregion

        #region Ctors
        public Subject()
        {
            Name = string.Empty;
            Area = string.Empty;
        }

        public Subject(string name, string area)
        {
            Name = name;
            Area = area;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Nombre: {Name}, Area: {Area}";
        }
        #endregion
    }
}
