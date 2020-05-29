using System;

namespace CIPSA.Util.ConsoleApp.Class.M_X.II
{
    public class Square : GeometricFigure
    {
        #region Ctors.
        public Square()
        {
        }

        public Square(double radio, int a, int b, int c, int side) 
            : base(radio, a, b, c, side)
        {
        }
        #endregion

        #region Methods
        public override double CalculateArea()
        {
            return Math.Pow(Side, 2);
        }

        public override double CalculatePerimeter()
        {
            return Side * 4;
        }

        public override void Draw()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
