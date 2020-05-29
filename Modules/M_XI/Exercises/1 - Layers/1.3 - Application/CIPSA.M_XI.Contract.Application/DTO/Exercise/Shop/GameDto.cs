namespace CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop
{
    public class GameDto : ArticleDto
    {
        #region Ctor.
        public GameDto()
        {
        }
        #endregion

        #region Properties.
        public string Platform { get; set; }
        #endregion
    }

    public enum PlatformEnum
    {
        XBOX360,
        PS3,
        WII
    }
}
