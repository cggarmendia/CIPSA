using System;

namespace CIPSA.Util.ConsoleApp.Class.M_X.II
{
    public class Circle : GeometricFigure
    {
        #region Ctors.
        public Circle()
        {
        }

        public Circle(int radio, int a, int b, int c, int side) 
            : base(radio, a, b, c, side)
        {
        }
        #endregion

        #region Methods
        public override double CalculateArea()
        {
            return (Math.PI * Math.Pow(Radio, 2));
        }

        public override double CalculatePerimeter()
        {
            return Math.PI * ( 2 * Radio);
        }

        public override void Draw()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
