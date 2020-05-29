using System;

namespace CIPSA.M_XI.Domain.Entities.Exercise.Agenda
{
    /// <summary>
    /// Empleado.
    /// </summary>
    public class Employee : IEntity
    {
        #region Ctor.
        public Employee()
        {
            CreatedOn = DateTime.Now;
            Birthday = DateTime.Now;
        }
        #endregion

        #region Properties.
        public int Id { get; set; }
        public string DNI { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreatedOn { get; set; }
        #endregion
    }
}
