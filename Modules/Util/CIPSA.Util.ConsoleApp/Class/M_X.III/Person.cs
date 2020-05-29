using CIPSA.Util.ConsoleApp.Enum.M_X.III;

namespace CIPSA.Util.ConsoleApp.Class.M_X.III
{
    public class Person
    {
        #region Properties
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public AccreditationEnum Accreditation { get; set; }
        public SexEnum Sex { get; set; }
        #endregion

        #region Ctors
        public Person()
        {
            Name = string.Empty;
            LastName = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;
            Accreditation = AccreditationEnum.Especializada;
            Sex = SexEnum.Femenino;
        }

        public Person(string name, string lastName, string phoneNumber, string email, 
            AccreditationEnum accreditation, SexEnum sex)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Accreditation = accreditation;
            Sex = sex;
        }
        #endregion

        #region Methods        
        public override string ToString()
        {
            return $"Nombre: {Name}, Apellidos: {LastName}, Teléfono: {PhoneNumber}, Email: {Email}, Acreditación: {Accreditation}, Sexo: {Sex}.";
        }
        #endregion
    }
}
