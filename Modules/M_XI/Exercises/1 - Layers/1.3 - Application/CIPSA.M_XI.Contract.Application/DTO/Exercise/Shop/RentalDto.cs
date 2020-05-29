using System;

namespace CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop
{
    public class RentalDto
    {
        #region Ctor.
        public RentalDto()
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
        public virtual ClientDto Client { get; set; }
        public virtual ArticleDto Article { get; set; }
        #endregion
    }
}
