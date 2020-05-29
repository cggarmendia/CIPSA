namespace CIPSA.Util.ConsoleApp.Class.M_X.II
{
    public class Triangle : GeometricFigure
    {
        #region Ctors.
        public Triangle()
        {
        }

        public Triangle(double radio, int a, int b, int c, int side) 
            : base(radio, a, b, c, side)
        {
        }
        #endregion

        #region Methods

        public override double CalculateArea()
        {
            return (A * B) / 2;
        }

        public override double CalculatePerimeter()
        {
            return A + B + C;
        }

        public override void Draw()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
