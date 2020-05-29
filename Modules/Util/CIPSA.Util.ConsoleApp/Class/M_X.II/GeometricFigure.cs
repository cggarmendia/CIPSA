namespace CIPSA.Util.ConsoleApp.Class.M_X.II
{
    public abstract class GeometricFigure
    {
        #region Properties
        public double Radio { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int Side { get; set; }
        #endregion

        #region Ctors
        public GeometricFigure()
        {
            Radio = double.MinValue;
            A = 0;
            B = 0;
            C = 0;
            Side = 0;
        }

        public GeometricFigure(double radio, int a, int b, int c, int side)
        {
            Radio = radio;
            A = a;
            B = b;
            C = c;
            Side = side;
        }
        #endregion

        #region Methods
        public abstract double CalculatePerimeter();
        public abstract double CalculateArea();
        public abstract void Draw();
        #endregion
    }
}
