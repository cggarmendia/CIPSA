namespace CIPSA.Util.ConsoleApp.Interface.M_X.II
{
    public interface IShip
    {
        int X { get; set; }
        int Y { get; set; }
        int Life { get; set; }
        void Shoot();
        void MoveToPosition(int x, int y);
    }
}
