using CIPSA.Util.ConsoleApp.Enum.M_X.III;

namespace CIPSA.Util.ConsoleApp.Class.M_X.III
{
    public class Employee
    {
        #region Properties
        public string Name { get; set; }
        public int EmployeeNumber { get; set; }
        public TurnEnum Turn { get; set; }
        #endregion

        #region Ctors
        public Employee()
        {
            Name = string.Empty;
            Turn = TurnEnum.Noche;
            EmployeeNumber = 0;
        }

        public Employee(string name, int employeeNumber, TurnEnum turn)
        {
            Name = name;
            EmployeeNumber = employeeNumber;
            Turn = turn;
        }
        #endregion

        #region Methods        
        public override string ToString()
        {
            return $"Nombre: {Name}, # de empleado: {EmployeeNumber}, Turno: {Turn}.";
        }
        #endregion
    }
}
