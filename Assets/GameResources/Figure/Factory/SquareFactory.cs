namespace Sorter.Figure
{
    public class SquareFactory : BaseFactory
    {
        protected override FigureType Type => FigureType.Square;

        public SquareFactory(Setting setting, Spawner.Settings spawnSetting, MonoPool<FigureView> pool) : base(setting, spawnSetting, pool)
        {
        }
    }
}
