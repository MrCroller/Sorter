namespace Sorter.Figure
{
    public class FigureData
    {
        readonly FigureType type;
        readonly float speed;

        public FigureData(float speed, FigureType type)
        {
            this.speed = speed;
            this.type = type;
        }
    }
}
