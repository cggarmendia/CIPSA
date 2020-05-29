namespace CIPSA.Util.ConsoleApp.Class.M_X.I
{
    public abstract class Person
    {
        #region Properties
        public string Name { get; set; }
        public string LastName { get; set; }
        #endregion

        #region Ctors
        public Person()
        {
            Name = string.Empty;
            LastName = string.Empty;
        }

        public Person(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
        #endregion

        #region Methods
        public abstract string GetInfo();
        #endregion
    }
}
