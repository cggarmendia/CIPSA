using System.Collections.Generic;

namespace CIPSA.M_XI.Domain.Entities.Exercise.Shop
{
    /// <summary>
    /// Artículo.
    /// </summary>
    public abstract class Article : IEntity
    {
        #region Properties.
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdult { get; set; }
        public bool IsRented { get; set; }
        #endregion

        #region Navigation_Properties.
        public virtual ICollection<Rental> Rentals { get; set; }
        #endregion
    }
}
