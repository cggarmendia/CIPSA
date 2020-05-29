using System.Collections.Generic;

namespace CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop
{
    public class ArticleDto
    {
        #region Properties.
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdult { get; set; }
        public bool IsRented { get; set; }
        #endregion

        #region Navigation_Properties.
        public virtual ICollection<RentalDto> Rentals { get; set; }
        #endregion
    }
}
