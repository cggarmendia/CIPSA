namespace CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop
{
    public class MovieDto : ArticleDto
    {
        #region Ctor.
        public MovieDto()
        {
        }
        #endregion

        #region Properties.
        public string Device { get; set; }
        #endregion
    }

    public enum DeviceEnum
    {
        DVD,
        BluRay
    }
}
