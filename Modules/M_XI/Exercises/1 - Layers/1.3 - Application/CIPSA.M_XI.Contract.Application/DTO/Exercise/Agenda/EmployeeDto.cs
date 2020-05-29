using System;

namespace CIPSA.M_XI.Contract.Application.DTO.Exercise.Agenda
{
    public class EmployeeDto
    {
        #region Ctor.
        public EmployeeDto()
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
