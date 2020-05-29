using System;
using System.Collections.Generic;

namespace CIPSA.M_XI.Domain.Entities.Exercise.Shop
{
    /// <summary>
    /// Cliente.
    /// </summary>
    public class Client : IEntity
    {
        #region Ctor.
        public Client()
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
        public virtual ICollection<Rental> Rentals { get; set; }
        #endregion
    }
}
