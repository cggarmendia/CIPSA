namespace CIPSA.M_XI.Domain.Entities.Exercise.Shop
{
    public class Game : Article, IEntity
    {
        /// <summary>
        /// Juego.
        /// </summary>
        #region Ctor.
        public Game()
        {
        }
        #endregion

        #region Properties.
        public string Platform { get; set; }
        #endregion
    }

}
