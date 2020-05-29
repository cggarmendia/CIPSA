using System;
using System.Collections.Generic;

namespace CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop
{
    public class ClientDto
    {
        #region Ctor.
        public ClientDto()
        {
            Birthday = DateTime.Now;
        }
        #endregion

        #region Properties.
        public int Id { get; set; }
        public string NIF { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        #endregion

        #region Navigation_Properties.
        public virtual ICollection<RentalDto> Rentals { get; set; }
        #endregion
    }
}
