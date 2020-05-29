namespace CIPSA.Util.ConsoleApp.Class.M_X.II
{
    public class Person
    {
        #region Properties
        public string Name { get; set; }
        public int Age { get; set; }
        public char Sex { get; set; }
        #endregion

        #region Ctors
        public Person()
        {
            Name = string.Empty;
            Age = 0;
            Sex = 'M';
        }

        public Person(string name, int age, char sex)
        {
            Name = name;
            Age = age;
            Sex = sex;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Nombre: {Name}, Edad: {Age}, Sexo: {Sex}"; 
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static string operator > (Person person1, Person person2)
        {
            return person1.Age >= person2.Age ? person1.Name : person2.Name;
        }

        public static string operator < (Person person1, Person person2)
        {
            return person1.Age <= person2.Age ? person1.Name : person2.Name;
        }

        public static bool operator == (Person person1, Person person2)
        {
            return person1.Sex == person2.Sex;
        }

        public static bool operator != (Person person1, Person person2)
        {
            return person1.Sex != person2.Sex;
        }
        #endregion
    }
}
