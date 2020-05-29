using System;

namespace CIPSA.M_XI.Domain.Entities.Exercise.Shop
{
    /// <summary>
    /// Aquiler.
    /// </summary>
    public class Rental : IEntity
    {
        #region Ctor.
        public Rental()
        {
            Date = DateTime.Now;
        }
        #endregion

        #region Properties
        public int ArticleId { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        #endregion

        #region Navigation_Properties
        public virtual Client Client { get; set; }
        public virtual Article Article { get; set; }
        #endregion
    }

}
