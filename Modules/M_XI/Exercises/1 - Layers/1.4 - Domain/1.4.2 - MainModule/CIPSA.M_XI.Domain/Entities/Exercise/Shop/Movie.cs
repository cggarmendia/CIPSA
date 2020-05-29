namespace CIPSA.M_XI.Domain.Entities.Exercise.Shop
{
    public class Movie : Article, IEntity
    {
        /// <summary>
        /// Película.
        /// </summary>
        #region Ctor.
        public Movie()
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
